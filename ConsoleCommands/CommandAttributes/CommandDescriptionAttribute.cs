#region Title Header

// Name: Phillip Smith
// 
// Solution: ConsoleCommands
// Project: ConsoleCommands
// File Name: CommandDescriptionAttribute.cs
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
  [AttributeUsage(AttributeTargets.Class)]
  public class CommandDescriptionAttribute : Attribute
  {
    public string Description;

    public CommandDescriptionAttribute(string description)
    {
      if (string.IsNullOrWhiteSpace(description))
      {
        throw new ArgumentException("Description must have a value");
      }

      Description = description;
    }
  }
}