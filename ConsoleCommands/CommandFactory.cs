#region Title Header

// Name: Phillip Smith
// 
// Solution: ConsoleCommands
// Project: ConsoleCommands
// File Name: CommandFactory.cs
// 
// Current Data:
// 2020-06-16 2:10 PM
// 
// Creation Date:
// 2020-06-16 8:01 AM

#endregion

using System;
using System.Collections.Generic;
using ConsoleCommands.Exceptions;

namespace ConsoleCommands
{
  internal class CommandFactory
  {
    private readonly IDictionary<string, Func<IConsoleCommand>> _registry =
      new Dictionary<string, Func<IConsoleCommand>>();

    public IConsoleCommand Create(string commandName)
    {
      if (_registry.ContainsKey(commandName))
      {
        return _registry[commandName].Invoke();
      }

      throw new ConsoleCommandException($"The key \"{commandName}\" does not exist", new ArgumentException());
    }

    public bool Contains(string commandName)
    {
      return _registry.ContainsKey(commandName);
    }

    public void Register(string commandName, Type consoleCommandType)
    {
      if (_registry.ContainsKey(commandName))
      {
        throw new ConsoleCommandException($"The key \"{commandName}\" already exists", new ArgumentException());
      }

      if (!typeof(IConsoleCommand).IsAssignableFrom(consoleCommandType))
      {
        throw new ConsoleCommandException(
          $"{nameof(IConsoleCommand)} is not assignable from {consoleCommandType.FullName}",
          new InvalidOperationException());
      }

      _registry.Add(commandName,
        () => Activator.CreateInstance(consoleCommandType) as IConsoleCommand ?? throw new NullReferenceException());
    }

    public void Register<TConsoleCommand>(string commandName) where TConsoleCommand : IConsoleCommand
    {
      Register(commandName, typeof(TConsoleCommand));
    }
  }
}