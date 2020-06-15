#region Title Header

// Name: Phillip Smith
// 
// Solution: ConsoleCommands
// Project: ConsoleCommands
// File Name: CommandLog.cs
// 
// Current Data:
// 2020-06-16 8:17 AM
// 
// Creation Date:
// 2020-06-16 8:17 AM

#endregion

using System;
using ConsoleCommands.CommandAttributes;

namespace ConsoleCommands.DefaultCommands
{
  [CommandAlias("print")]
  [CommandAlias("log")]
  [CommandAlias("output")]
  [CommandAlias("echo")]
  [CommandDescription("Logs a message to the screen")]
  internal class CommandLog : IConsoleCommand
  {
    public void Execute(params string[] args)
    {
      Console.WriteLine(string.Join(" ", args) + Environment.NewLine);
    }
  }
}