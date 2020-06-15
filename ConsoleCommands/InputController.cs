#region Title Header

// Name: Phillip Smith
// 
// Solution: ConsoleCommands
// Project: ConsoleCommands
// File Name: InputController.cs
// 
// Current Data:
// 2020-06-16 9:41 AM
// 
// Creation Date:
// 2020-06-16 9:40 AM

#endregion

using System;
using System.Linq;
using System.Text.RegularExpressions;
using ConsoleCommands.Exceptions;

namespace ConsoleCommands
{
  internal class InputController
  {
    private readonly CommandFactory _commandFactory;

    public InputController(CommandFactory commandFactory)
    {
      _commandFactory = commandFactory;
    }

    private void Parse(in string? input)
    {
      if (input is null)
      {
        throw new ArgumentNullException(nameof(input));
      }

      if (string.IsNullOrWhiteSpace(input))
      {
        return;
      }

      var split = Regex.Split(input.Trim(), @"\s+");
      var command = split[0].ToLowerInvariant();
      var args = split.Skip(1).ToArray();

      try
      {
        if (_commandFactory.Contains(command))
        {
          var consoleCommand = _commandFactory.Create(command);
          consoleCommand.Execute(args);
          return;
        }

        Console.WriteLine($"No command named \"{command}\" exists." + Environment.NewLine);
      }
      catch (ConsoleCommandException e)
      {
        Console.WriteLine(e.Message + Environment.NewLine);
      }
    }

    public void AcceptCommand()
    {
      var input = AwaitInput();
      Parse(input);
    }

    private static string? AwaitInput()
    {
      Console.Write(Characters.Point + ": ");
      return Console.ReadLine();
    }
  }
}