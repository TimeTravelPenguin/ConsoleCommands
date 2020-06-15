#region Title Header

// Name: Phillip Smith
// 
// Solution: ConsoleCommands
// Project: ConsoleCommands
// File Name: CommandClear.cs
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
  [CommandAlias("clear")]
  [CommandAlias("cls")]
  [CommandDescription("Clears the console screen.")]
  internal class CommandClear : IConsoleCommand
  {
    public void Execute(params string[] args)
    {
      Console.Clear();
    }
  }
}