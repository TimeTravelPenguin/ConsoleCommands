#region Title Header

// Name: Phillip Smith
// 
// Solution: ConsoleCommands
// Project: ConsoleCommands
// File Name: ConsoleCommandException.cs
// 
// Current Data:
// 2020-06-16 8:09 AM
// 
// Creation Date:
// 2020-06-16 8:06 AM

#endregion

using System;

namespace ConsoleCommands.Exceptions
{
  public class ConsoleCommandException : Exception
  {
    public ConsoleCommandException(string message, Exception inner) : base(message, inner)
    {
    }
  }
}