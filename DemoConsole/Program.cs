#region Title Header

// Name: Phillip Smith
// 
// Solution: ConsoleCommands
// Project: DemoConsole
// File Name: Program.cs
// 
// Current Data:
// 2020-06-16 2:10 PM
// 
// Creation Date:
// 2020-06-16 9:40 AM

#endregion

using System;
using System.Text;
using ConsoleCommands;

namespace DemoConsole
{
  public static class Program
  {
    public static void Main()
    {
      Console.OutputEncoding = Encoding.UTF8;

      var shell = CommandShell.Run();

      while (true)
      {
        shell.AcceptCommand();
      }
    }
  }
}