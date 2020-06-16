#region Title Header

// Name: Phillip Smith
// 
// Solution: ConsoleCommands
// Project: ConsoleCommands
// File Name: CommandShowAll.cs
// 
// Current Data:
// 2020-06-16 2:10 PM
// 
// Creation Date:
// 2020-06-16 1:20 PM

#endregion

using System;
using System.Linq;
using ConsoleCommands.CommandAttributes;
using ConsoleCommands.Helpers;

namespace ConsoleCommands.DefaultCommands
{
  [CommandAlias("commands")]
  [CommandDescription("Outputs a list of all commands")]
  public class CommandShowAll : IConsoleCommand
  {
    public void Execute(params string[] args)
    {
      var commands = AttributeHelper.GetTypesWithAttribute<CommandAliasAttribute>()
        .Where(x => typeof(IConsoleCommand).IsAssignableFrom(x));

      foreach (var command in commands)
      {
        var aliases = Attribute.GetCustomAttributes(command, typeof(CommandAliasAttribute))
          .Cast<CommandAliasAttribute>()
          .Select(x => x.OverrideAlias);

        aliases.WriteLine();
      }

      Console.WriteLine();
    }
  }
}