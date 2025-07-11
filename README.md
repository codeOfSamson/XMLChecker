# XML Validator - Pull Request Description

## Overview

This console application validates XML strings according to specific rules without using any XML libraries or regular expressions. The solution is designed to be simple, efficient, and maintainable.

The solution uses a **stack-based approach** to validate XML structure:

1. **Tag Parsing**: Iterate through the XML string character by character, identifying opening and closing tags
2. **Stack Management LIFO**:
   - Push opening tags onto the stack
   - Pop and validate closing tags against the stack

#### Methods

- IsValidXml - see Program.cs for details...
- ExtractTagName -- see Program.cs for details...

#### Tag Extraction

- **Opening Tags**: Extract tag name before the first space (ignoring attributes)
- **Closing Tags**: Remove leading `/` and trim whitespace
- **Whitespace Handling**: Tags are trimmed for consistency

## Build Instructions

As I am working on a mac this is how I was running my code, however, I ran dotnet publish so this project will contain a checker.exe in the publish folder.

```bash
dotnet build
dotnet run -- "<Design><Code>hello world</Code></Design>"
```

## Dependencies

- .NET 8.0
- .NET 9.0
- No external libraries or packages required
# XMLChecker
