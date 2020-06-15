﻿#region Title Header

// Name: Phillip Smith
// 
// Solution: ConsoleCommands
// Project: ConsoleCommands
// File Name: CommandHelp.cs
// 
// Current Data:
// 2020-06-16 8:17 AM
// 
// Creation Date:
// 2020-06-16 8:17 AM

#endregion

using System;
using System.Linq;
using ConsoleCommands.CommandAttributes;
using ConsoleCommands.Helpers;

namespace ConsoleCommands.DefaultCommands
{
  [CommandAlias("?")]
  [CommandAlias("help")]
  [CommandDescription("Use \"help <command>\" to see more information about the command.")]
  internal class CommandHelp : IConsoleCommand
  {
    public void Execute(params string[] args)
    {
      Console.WriteLine();

      if (args.Length == 0)
      {
        Console.WriteLine("Use \"help <command>\" to see more information about the command." + Environment.NewLine);
        return;
      }

      var commandName = args[0];

      // Find command with same alias
      var aliases = commandName.GetWithAlias();
      if (aliases is null)
      {
        Console.WriteLine("No command found" + Environment.NewLine);
        return;
      }

      // Output aliases
      var aliasNames = Attribute.GetCustomAttributes(aliases, typeof(CommandAliasAttribute))
        .Cast<CommandAliasAttribute>()
        .Select(x => x.OverrideAlias);

      Console.WriteLine($"Command aliases: {string.Join(", ", aliasNames)}" + Environment.NewLine);

      var commands = AttributeHelper.GetTypesWithAttribute<CommandDescriptionAttribute>();
      foreach (var command in commands)
      {
        var containsAlias = Attribute.GetCustomAttributes(command, typeof(CommandAliasAttribute))
          .Cast<CommandAliasAttribute>()
          .Select(x => x.OverrideAlias)
          .Any(x => x == commandName);

        // Output description
        if (containsAlias && command.HasAttribute<CommandDescriptionAttribute>(out var descriptions))
        {
          foreach (var description in descriptions)
          {
            Console.WriteLine(description.Description);
          }

          Console.WriteLine();
          break;
        }
      }
    }
  }
}