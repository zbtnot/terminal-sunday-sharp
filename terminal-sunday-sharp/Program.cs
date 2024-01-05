using System.Diagnostics;

namespace terminal_sunday_sharp;

internal static class Program
{
    public static int Main(string[] args)
    {
        DateTime birthday;
        string name;
        if (args.Length < 1)
        {
            var binName = Process.GetCurrentProcess().ProcessName;
            Console.WriteLine($"Usage: {binName} birthdate [username]");
            Console.WriteLine($"Example: {binName} 1988-02-23 Gio");
            return 1;
        }

        try
        {
            birthday = Convert.ToDateTime(args[0]);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid date format. Use YYYY-MM-DD.");
            return 1;
        }

        try
        {
            name = args.Length >= 2
                ? args[1]
                : Environment.GetEnvironmentVariable("USER") ?? throw new ArgumentNullException();
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Missing a username and USER is not set.");
            return 1;
        }

        var dreadRenderer = new ExistentialDreadRenderer(name, birthday);
        foreach (var command in dreadRenderer.Render())
        {
            switch (command.Item2)
            {
                case ConsoleColorCommand.Green:
                    Console.BackgroundColor = ConsoleColor.Green;
                    break;
                case ConsoleColorCommand.Red:
                    Console.BackgroundColor = ConsoleColor.Red;
                    break;
                case ConsoleColorCommand.Reset:
                    Console.ResetColor();
                    break;
            }
            Console.Write(command.Item1);
        }

        return 0;
    }
}
