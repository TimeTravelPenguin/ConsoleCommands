#region Title Header

// Name: Phillip Smith
// 
// Solution: ConsoleCommands
// Project: ConsoleCommands
// File Name: CommandLog.cs
// 
// Current Data:
// 2020-06-19 5:13 PM
// 
// Creation Date:
// 2020-06-16 2:11 PM

#endregion

using System;
using ConsoleCommands.CommandAttributes;

namespace ConsoleCommands.DefaultCommands
{
  [CommandAlias("print")]
  [CommandAlias("log")]
  [CommandAlias("output")]
  [CommandAlias("echo")]
  [CommandUsage(typeof(string))]
  [CommandDescription("Logs a message to the screen")]
  internal class CommandLog : IConsoleCommand
  {
    public void Execute(params string[] args)
    {
      Console.WriteLine(string.Join(" ", args) + Environment.NewLine);
    }
  }
}