#region Title Header

// Name: Phillip Smith
// 
// Solution: ConsoleCommands
// Project: ConsoleCommands
// File Name: CommandUsageAttribute.cs
// 
// Current Data:
// 2020-06-19 4:58 PM
// 
// Creation Date:
// 2020-06-16 2:10 PM

#endregion

using System;
using System.Linq;

namespace ConsoleCommands.CommandAttributes
{
  [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
  public class CommandUsageAttribute : Attribute
  {
    public object[] Arguments;

    public CommandUsageAttribute(params Type[] args)
    {
      // TODO
      if (args.Any(x => x is null))
      {
        throw new ArgumentNullException(nameof(args));
      }

      Arguments = args;
    }
  }
}