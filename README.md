Tried few ways to parse LNZ file, in the end parsing seems simplest using attributes.

But in case custom parsing of line is needed, use the `LnzRowParser`.

# Running

`dotnet run`

# Usage
## 1. Annotate what fields will be parsed

The `LnzAttributeParser` will detect how to parse each field automatically based on type.

![chrome_DypBVW0tqc](https://github.com/user-attachments/assets/4c15d10a-50bc-40c5-a8ed-8b9746acd22f)

## 2. Parse them with LnzParser

`LnzParser` just loops trough lines and allows to detect and branch into the section ... To make this a simple example, parsing is assumed to just add to the List<T> ...

![chrome_RqgoC5i1Sx](https://github.com/user-attachments/assets/a7e2e84e-a731-4d54-a79e-a02b2c116998)

# Example usage
![chrome_7QVNwKaJDs](https://github.com/user-attachments/assets/9568caca-6e9d-4c36-98cf-05c46f136c79)
![rider64_Hbcf2dduVx](https://github.com/user-attachments/assets/6456c1ce-b4df-4de3-8545-6b37f5c69c86)
