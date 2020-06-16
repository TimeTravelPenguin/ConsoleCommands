#region Title Header

// Name: Phillip Smith
// 
// Solution: ConsoleCommands
// Project: ConsoleCommands
// File Name: ConsoleHelperExtensions.cs
// 
// Current Data:
// 2020-06-16 2:10 PM
// 
// Creation Date:
// 2020-06-16 1:38 PM

#endregion

using System;
using System.Collections.Generic;

namespace ConsoleCommands.Helpers
{
  internal static class ConsoleHelperExtensions
  {
    public static void WriteLine(this IEnumerable<string> list)
    {
      Console.WriteLine(string.Join(", ", list));
    }
  }
}