#region Title Header

// Name: Phillip Smith
// 
// Solution: ConsoleCommands
// Project: ConsoleCommands
// File Name: CommandShell.cs
// 
// Current Data:
// 2020-06-16 8:16 AM
// 
// Creation Date:
// 2020-06-16 8:02 AM

#endregion

using System;
using System.Text;
using ConsoleCommands.CommandAttributes;
using ConsoleCommands.Helpers;

namespace ConsoleCommands
{
  public class CommandShell
  {
    private readonly CommandFactory _commandFactory = new CommandFactory();
    private readonly InputController _controller;

    private CommandShell()
    {
      Console.OutputEncoding = Encoding.UTF8;

      _controller = new InputController(_commandFactory);

      CreateCommands();
    }

    public void AddCommand<TCommand>(string commandName) where TCommand : IConsoleCommand
    {
      _commandFactory.Register<TCommand>(commandName);
    }

    public static CommandShell Run()
    {
      return new CommandShell();
    }

    public void AcceptCommand()
    {
      _controller.AcceptCommand();
    }

    private void CreateCommands()
    {
      var commandAttributes = AttributeHelper.GetCommandsWithAttribute<CommandAliasAttribute>();
      foreach (var command in commandAttributes)
      {
        var aliasAttributes = Attribute.GetCustomAttributes(command, typeof(CommandAliasAttribute));
        foreach (var aliasAttribute in aliasAttributes)
        {
          if (aliasAttribute is CommandAliasAttribute alias)
          {
            _commandFactory.Register(alias.OverrideAlias.ToLowerInvariant(), command);
          }
        }
      }
    }
  }
}