terminal-sunday-sharp
=====================

Inspired by [terminal-sunday](https://github.com/accessd/terminal-sunday), this utility provides you with a reminder of how much time you might have left.

Built with C#, this version runs a whopping 0.1 seconds faster than the Ruby version on my M2 Pro mac 😂 

## Build and run
- Clone the repo 
- Assemble with `dotnet build`
  -  run with `dotnet run --project ./terminal-sunday-sharp`

## Maximizing ~~dread~~ motivation
- Publish the aot-version with `dotnet publish`
- Locate the binary within `terminal-sunday-sharp/bin/` and stuff it somewhere in your PATH
  - Bonus points if you add it to your shell's run control script

## Tests
Rudimentary tests for MSTest are in the `tests` project. Run with `dotnet test`.
