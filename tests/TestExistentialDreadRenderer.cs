using terminal_sunday_sharp;

namespace tests;

[TestClass]
public class TestExistentialDreadRenderer
{
    [TestMethod]
    [DynamicData(nameof(RenderLinesProvider))]
    public void TestRendererRendersLines(string name, DateTime birthday, DateTime today,
        (string, ConsoleColorCommand?) richMessageTuple)
    {
        var dreadRenderer = new ExistentialDreadRenderer(name, birthday, today);
        var lines = dreadRenderer.Render();
        Assert.IsTrue(lines.Contains(richMessageTuple));
    }

    public static IEnumerable<object[]> RenderLinesProvider
    {
        get
        {
            var name = "gio";
            var birthday = new DateTime(1988, 2, 23);
            var today = new DateTime(1989, 2, 23);
            var weeksRemaining = 79 * 52;
            var expectancy = birthday.Year + 79;

            return new[]
            {
                new object[]
                {
                    name, birthday, today, ValueTuple.Create<string, ConsoleColorCommand?>($"{birthday.Year}\n", null),
                },
                new object[]
                {
                    name, birthday, today,
                    ValueTuple.Create<string, ConsoleColorCommand?>($"{name}, only {weeksRemaining} Sundays remain\n\n",
                        null),
                },
                new object[]
                {
                    name, birthday, today,
                    ValueTuple.Create<string, ConsoleColorCommand?>("  ", ConsoleColorCommand.Green),
                },
                new object[]
                {
                    name, birthday, today,
                    ValueTuple.Create<string, ConsoleColorCommand?>("  ", ConsoleColorCommand.Red),
                },
                new object[]
                {
                    name, birthday, today,
                    ValueTuple.Create<string, ConsoleColorCommand?>(" ", ConsoleColorCommand.Reset),
                },
                new object[]
                {
                    name, birthday, today, ValueTuple.Create<string, ConsoleColorCommand?>($"{expectancy}\n", null),
                },
                new object[]
                {
                    name, birthday, today, ValueTuple.Create<string, ConsoleColorCommand?>($"How are you going to spend these Sundays, {name}?\n", null),
                },
            };
        }
    }
}
