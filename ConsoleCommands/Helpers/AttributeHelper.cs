#region Title Header

// Name: Phillip Smith
// 
// Solution: ConsoleCommands
// Project: ConsoleCommands
// File Name: AttributeHelper.cs
// 
// Current Data:
// 2020-06-16 2:10 PM
// 
// Creation Date:
// 2020-06-16 8:03 AM

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ConsoleCommands.Helpers
{
  internal static class AttributeHelper
  {
    /// <summary>
    ///   Returns a list of all classes as <see cref="Type" /> implementing the attribute <typeparamref name="TAttribute" />.
    /// </summary>
    /// <typeparam name="TAttribute"></typeparam>
    /// <param name="assemblies"></param>
    /// <returns></returns>
    public static IEnumerable<Type> GetTypesWithAttribute<TAttribute>(this IEnumerable<Assembly> assemblies)
      where TAttribute : Attribute
    {
      return assemblies.SelectMany(x => x.GetTypes())
        .Where(type => type.GetCustomAttributes(typeof(TAttribute), true).Length > 0);
    }

    public static IEnumerable<Type> GetTypesWithAttribute<TAttribute>(this Assembly assembly)
      where TAttribute : Attribute
    {
      return assembly.GetTypes()
        .Where(type => type.GetCustomAttributes(typeof(TAttribute), true).Length > 0);
    }

    public static IEnumerable<Type> GetTypesWithAttribute<TAttribute>() where TAttribute : Attribute
    {
      return GetTypesWithAttribute<TAttribute>(AppDomain.CurrentDomain.GetAssemblies());
    }

    public static IEnumerable<Type> GetCommandsWithAttribute<TAttribute>() where TAttribute : Attribute
    {
      var commandsWithAttribute = GetTypesWithAttribute<TAttribute>()
        .Where(x => typeof(IConsoleCommand).IsAssignableFrom(x));

      return commandsWithAttribute.Where(x => Attribute.IsDefined(x, typeof(TAttribute)));
    }

    public static bool HasAttribute<TAttribute>(this MemberInfo obj, out IEnumerable<TAttribute> attributes)
      where TAttribute : Attribute
    {
      if (!Attribute.IsDefined(obj, typeof(TAttribute)))
      {
        attributes = new List<TAttribute>();
        return false;
      }

      attributes = Attribute.GetCustomAttributes(obj, typeof(TAttribute)).Cast<TAttribute>();
      return true;
    }
  }
}