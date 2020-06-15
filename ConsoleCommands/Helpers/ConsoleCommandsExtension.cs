#region Title Header

// Name: Phillip Smith
// 
// Solution: ConsoleCommands
// Project: ConsoleCommands
// File Name: ConsoleCommandsExtension.cs
// 
// Current Data:
// 2020-06-16 8:09 AM
// 
// Creation Date:
// 2020-06-16 8:02 AM

#endregion

#nullable enable
using System;
using System.Linq;
using ConsoleCommands.CommandAttributes;

namespace ConsoleCommands.Helpers
{
  internal static class ConsoleCommandExtensions
  {
    public static Type? GetWithAlias(this string alias)
    {
      var aliasCommands = AttributeHelper.GetCommandsWithAttribute<CommandAliasAttribute>();

      return aliasCommands.FirstOrDefault(command => Attribute
        .GetCustomAttributes(command, typeof(CommandAliasAttribute))
        .Cast<CommandAliasAttribute>()
        .Select(x => x.OverrideAlias)
        .Contains(alias));
    }
  }
}