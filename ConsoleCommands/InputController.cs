#region Title Header

// Name: Phillip Smith
// 
// Solution: ConsoleCommands
// Project: ConsoleCommands
// File Name: InputController.cs
// 
// Current Data:
// 2020-06-16 8:52 AM
// 
// Creation Date:
// 2020-06-16 8:00 AM

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

      var commands = Regex.Split(input.Trim(), @"\s+");

      try
      {
        var command = commands[0].ToLowerInvariant();
        if (_commandFactory.Contains(command))
        {
          var consoleCommand = _commandFactory.Create(commands[0].ToLowerInvariant());
          consoleCommand.Execute(commands.Skip(1).ToArray());
        }
        else
        {
          Console.WriteLine($"No command named \"{commands[0]}\" exists." + Environment.NewLine);
        }
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