#region Title Header

// Name: Phillip Smith
// 
// Solution: ConsoleCommands
// Project: ConsoleCommands
// File Name: CommandUsageAttribute.cs
// 
// Current Data:
// 2020-06-16 8:31 AM
// 
// Creation Date:
// 2020-06-16 8:04 AM

#endregion

using System;
using System.Linq;

namespace ConsoleCommands.CommandAttributes
{
  [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
  public class CommandUsageAttribute : Attribute
  {
    public string[] Arguments;

    public CommandUsageAttribute(params string[] args)
    {
      if (args.Any(string.IsNullOrWhiteSpace))
      {
        throw new ArgumentException("Arguments must have a value");
      }

      Arguments = args;
    }
  }
}