#region Title Header

// Name: Phillip Smith
// 
// Solution: ConsoleCommands
// Project: ConsoleCommands
// File Name: CommandAliasAttribute.cs
// 
// Current Data:
// 2020-06-16 8:31 AM
// 
// Creation Date:
// 2020-06-16 8:04 AM

#endregion

using System;

namespace ConsoleCommands.CommandAttributes
{
  [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
  public class CommandAliasAttribute : Attribute
  {
    public string OverrideAlias;

    public CommandAliasAttribute(string overrideAlias)
    {
      if (string.IsNullOrWhiteSpace(overrideAlias))
      {
        throw new ArgumentException("Alias must have a value");
      }

      OverrideAlias = overrideAlias;
    }
  }
}