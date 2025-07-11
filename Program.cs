using System;
using System.Collections.Generic;

namespace Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Invalid");
                return;
            }

            string xmlString = args[0];
            bool isValid = IsValidXml(xmlString);

            Console.WriteLine(isValid ? "Valid" : "Invalid");
        }

        /// <summary>
        /// Validates XML string according to the specified rules:
        /// 1. Each opening tag must have a corresponding closing tag
        /// 2. Tags must be well-nested (first opened, last closed)
        /// 3. Tags with attributes are treated as different from tags without attributes
        /// </summary>
        /// <param name="xmlString">The XML string to validate</param>
        /// <returns>True if valid XML, false otherwise</returns>
        static bool IsValidXml(string xmlString)
        {
            if (string.IsNullOrEmpty(xmlString))
                return false;

            var tagStack = new Stack<string>();
            int index = 0;

            while (index < xmlString.Length)
            {

                int openBracket = xmlString.IndexOf('<', index);
                if (openBracket == -1)
                    break;

                int closeBracket = xmlString.IndexOf('>', openBracket);
                if (closeBracket == -1)
                    return false;

                string tagContent = xmlString.Substring(openBracket + 1, closeBracket - openBracket - 1).Trim();

                if (string.IsNullOrEmpty(tagContent))
                    return false;


                if (tagContent.StartsWith("/"))
                {
                    string closingTag = tagContent.Substring(1).Trim();

                    if (tagStack.Count == 0)
                        return false;

                    string expectedTag = tagStack.Pop();
                    if (expectedTag != closingTag)
                        return false;
                }
                else
                {
                    tagStack.Push(tagContent);
                }

                index = closeBracket + 1;
            }

            return tagStack.Count == 0;
        }

        /// <summary>
        /// Extracts the tag name from a tag content, ignoring attributes.
        /// For example: "tutorial date=\"01/01/2000\"" returns "tutorial"
        /// </summary>
        /// <param name="tagContent">The content inside the tag brackets</param>
        /// <returns>The tag name without attributes</returns>
        static string ExtractTagName(string tagContent)
        {
            // Find the first space or end of string
            int spaceIndex = tagContent.IndexOf(' ');
            if (spaceIndex == -1)
                return tagContent.Trim();

            return tagContent.Substring(0, spaceIndex).Trim();
        }
    }
}