#region Title Header

// Name: Phillip Smith
// 
// Solution: ConsoleCommands
// Project: ConsoleCommands
// File Name: CommandAbout.cs
// 
// Current Data:
// 2020-06-16 2:10 PM
// 
// Creation Date:
// 2020-06-16 9:51 AM

#endregion

using System;
using ConsoleCommands.CommandAttributes;

namespace ConsoleCommands.DefaultCommands
{
  [CommandAlias("about")]
  [CommandDescription("Displays about information.")]
  internal class CommandAbout : IConsoleCommand
  {
    public void Execute(params string[] args)
    {
      Console.WriteLine("This library was made by TimeTravelPenguin 2020" + Environment.NewLine);
    }
  }
}