#region Title Header

// Name: Phillip Smith
// 
// Solution: ConsoleCommands
// Project: DemoConsole
// File Name: AddCommand.cs
// 
// Current Data:
// 2020-06-19 5:26 PM
// 
// Creation Date:
// 2020-06-16 2:11 PM

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
  [CommandUsage(typeof(double[]))]
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