#region Title Header

// Name: Phillip Smith
// 
// Solution: ConsoleCommands
// Project: ConsoleCommands
// File Name: IConsoleCommand.cs
// 
// Current Data:
// 2020-06-16 8:09 AM
// 
// Creation Date:
// 2020-06-16 8:00 AM

#endregion

namespace ConsoleCommands
{
  public interface IConsoleCommand
  {
    void Execute(params string[] args);
  }
}