using System.Text;

namespace terminal_sunday_sharp;

public class ExistentialDreadRenderer(string name, DateTime birthday, DateTime? today = null)
{
    private const int LifeExpectancy = 80;
    private const int TotalWeeks = LifeExpectancy * 52;
    private List<(string, ConsoleColorCommand?)> _renderer = new();
    private readonly DateTime _today = today ?? DateTime.Now;

    public List<(string, ConsoleColorCommand?)> Render()
    {
        var weeksPassed = (_today - birthday).Days / 7;
        var weeksRemaining = TotalWeeks - weeksPassed;
        var yearsPassed = _today.Year - birthday.Year;
        _renderer.Clear();

        _renderer.Add(($"{name}, only {weeksRemaining} Sundays remain\n\n", null));
        _renderer.Add(($"{birthday.Year}\n", null));
        for (int i = 0; i < LifeExpectancy; i++)
        {
            var color = i < yearsPassed ? ConsoleColorCommand.Red : ConsoleColorCommand.Green;
            _renderer.Add(("  ", color));
            _renderer.Add((" ", ConsoleColorCommand.Reset));

            if ((i + 1) % 20 != 0)
            {
                continue;
            }

            _renderer.Add(("\n", null));
            if (i != LifeExpectancy - 1)
            {
                _renderer.Add(("\n", null));
            }
        }

        var sb = new StringBuilder();
        for (int i = 0; i < 55; i++)
        {
            sb.Append(' ');
        }
        _renderer.Add((sb.ToString(), null));

        _renderer.Add(($"{birthday.Year + LifeExpectancy - 1}\n", null));
        _renderer.Add(($"How are you going to spend these Sundays, {name}?\n", null));

        return _renderer;
    }
}
