Stack<double> result = new Stack<double>();

Console.Write("Enter an operation with Polish notation: ");
string inputExpression = Console.ReadLine().Trim();

// List<string> expression = new List<string> { "4", "7", "7", "+", "*" };  //  4 * (7 + 7) = 56

string[] expression = inputExpression.Split(' ');

try
{
    foreach (var token in expression)
    {
        double currentResult;

        if (double.TryParse(token, out double currentNumber))
        {
            result.Push(currentNumber);
            continue;
        }

        if(result.Count < 2) 
            throw new Exception($"Not enough operands for operator '{token}'.");

        double secondNumber = result.Pop();
        double firstNumber = result.Pop();

        currentResult = token switch
        {
            "+" => firstNumber + secondNumber,
            "-" => firstNumber - secondNumber,
            "*" => firstNumber * secondNumber,
            "/" when secondNumber == 0 => throw new Exception("Division by zero"),
            "/" => firstNumber / secondNumber,
            _ => throw new ArgumentException($"Unknown operator: '{token}'")
        };
        result.Push(currentResult);

    }

    if (result.Count > 1)
        throw new Exception("Invalid expression: too many operands.");

    Console.WriteLine($"Result: {result.Peek()} ");
}
catch (Exception ex)
{ Console.WriteLine($"ERROR: {ex.Message}"); }

Console.ReadLine();