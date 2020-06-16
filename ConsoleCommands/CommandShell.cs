#region Title Header

// Name: Phillip Smith
// 
// Solution: ConsoleCommands
// Project: ConsoleCommands
// File Name: CommandShell.cs
// 
// Current Data:
// 2020-06-16 2:10 PM
// 
// Creation Date:
// 2020-06-16 9:40 AM

#endregion

using System;
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
      _controller = new InputController(_commandFactory);

      CreateCommands();
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
      var commandAttributes = AttributeHelper.GetTypesWithAttribute<CommandAliasAttribute>();
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