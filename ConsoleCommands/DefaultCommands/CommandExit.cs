#region Title Header

// Name: Phillip Smith
// 
// Solution: ConsoleCommands
// Project: ConsoleCommands
// File Name: CommandExit.cs
// 
// Current Data:
// 2020-06-16 8:13 AM
// 
// Creation Date:
// 2020-06-16 8:13 AM

#endregion

using System;
using ConsoleCommands.CommandAttributes;

namespace ConsoleCommands.DefaultCommands
{
  [CommandAlias("exit")]
  [CommandDescription("Exits the application.")]
  internal class CommandExit : IConsoleCommand
  {
    public void Execute(params string[] args)
    {
      Environment.Exit(0);
    }
  }
}