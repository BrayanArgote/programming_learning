Stack<string> text = new Stack<string>();

Console.WriteLine("Text Editor (Ctrl + Z = Undo, Ctrl + B = Exit)");
Console.Write("\n> ");

string currentInput = "";

while (true)
{
    ConsoleKeyInfo key = Console.ReadKey(true);

    if (key.Key == ConsoleKey.Enter && !string.IsNullOrEmpty(currentInput))
    {
        text.Push(currentInput);
        currentInput = "";
        Console.WriteLine();
        foreach (var word in text.Reverse()) Console.Write($"{word} ");
        Console.Write("\n> ");
    }

    else if (key.Key == ConsoleKey.B && key.Modifiers.HasFlag(ConsoleModifiers.Control))
    {
        Console.WriteLine("\n=== Final text ===");
        foreach (var word in text.Reverse()) Console.Write($"{word} ");
        break;
    }

    else if (key.Key == ConsoleKey.Backspace && currentInput.Length > 0)
    {
        currentInput = currentInput[..^1];
        Console.Write("\b \b");
    }

    else if (key.Key == ConsoleKey.Z && key.Modifiers.HasFlag(ConsoleModifiers.Control) && text.Count > 0)
    {
        text.Pop();
        Console.WriteLine();
        foreach (var word in text.Reverse()) Console.Write($"{word} ");
        Console.Write("\n> ");
    }

    else if (!char.IsControl(key.KeyChar))
    {
        currentInput = currentInput + key.KeyChar;
        Console.Write(key.KeyChar);
    }
}

Console.ReadKey();



