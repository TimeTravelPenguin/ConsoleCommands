#region Title Header

// Name: Phillip Smith
// 
// Solution: ConsoleCommands
// Project: DemoConsole
// File Name: AddCommand.cs
// 
// Current Data:
// 2020-06-16 8:55 AM
// 
// Creation Date:
// 2020-06-16 8:18 AM

#endregion

using System;
using System.Linq;
using ConsoleCommands;
using ConsoleCommands.CommandAttributes;
using ConsoleCommands.Exceptions;

namespace DemoConsole.Commands
{
  [CommandAlias("add")]
  [CommandAlias("plus")]
  [CommandAlias("sum")]
  [CommandDescription("Adds a sequence of numbers.")]
  public class AddCommand : IConsoleCommand
  {
    public void Execute(params string[] args)
    {
      try
      {
        var doubles = args.Select(double.Parse);
        Console.WriteLine(doubles.Sum() + Environment.NewLine);
      }
      catch (Exception e)
      {
        throw new ConsoleCommandException("This command can only add numbers", e);
      }
    }
  }
}