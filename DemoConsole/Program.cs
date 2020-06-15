#region Title Header

// Name: Phillip Smith
// 
// Solution: ConsoleCommands
// Project: DemoConsole
// File Name: Program.cs
// 
// Current Data:
// 2020-06-16 8:56 AM
// 
// Creation Date:
// 2020-06-16 8:08 AM

#endregion

using ConsoleCommands;

namespace DemoConsole
{
  public static class Program
  {
    public static void Main()
    {
      var shell = CommandShell.Run();

      while (true)
      {
        shell.AcceptCommand();
      }
    }
  }
}