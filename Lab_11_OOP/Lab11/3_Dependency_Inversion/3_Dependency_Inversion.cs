
public delegate void StrategyChangeEventHandler(char operatorChar);

public interface IStrategy
{
    int Calculate(int firstOperand, int secondOperand);
}

public class AdditionStrategy : IStrategy
{
    public int Calculate(int firstOperand, int secondOperand) => firstOperand + secondOperand;
}

public class SubtractionStrategy : IStrategy
{
    public int Calculate(int firstOperand, int secondOperand) => firstOperand - secondOperand;
}

public class MultiplicationStrategy : IStrategy
{
    public int Calculate(int firstOperand, int secondOperand) => firstOperand * secondOperand;
}

public class DivisionStrategy : IStrategy
{
    public int Calculate(int firstOperand, int secondOperand) => firstOperand / secondOperand;
}

public class PrimitiveCalculator
{
    private IStrategy strategy;
    public event StrategyChangeEventHandler StrategyChange;

    public PrimitiveCalculator()
    {
        this.strategy = new AdditionStrategy();

        this.StrategyChange += OnStrategyChange;
    }

    protected virtual void OnStrategyChange(char operatorChar)
    {
        switch (operatorChar)
        {
            case '+':
                this.strategy = new AdditionStrategy();
                break;
            case '-':
                this.strategy = new SubtractionStrategy();
                break;
            case '*':
                this.strategy = new MultiplicationStrategy();
                break;
            case '/':
                this.strategy = new DivisionStrategy();
                break;
        }
    }

    public void ChangeStrategy(char @operator)
    {
        StrategyChange?.Invoke(@operator);
    }

    public int PerformCalculation(int firstOperand, int secondOperand)
    {
        return this.strategy.Calculate(firstOperand, secondOperand);
    }
}

public class Program
{
    public static void Main()
    {
        var calculator = new PrimitiveCalculator();
        var results = new List<int>();

        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            string[] parts = command.Split(' ');

            if (parts[0] == "mode")
            {
                calculator.ChangeStrategy(parts[1][0]);
            }
            else
            {
                int firstOperand = int.Parse(parts[0]);
                int secondOperand = int.Parse(parts[1]);
                int result = calculator.PerformCalculation(firstOperand, secondOperand);
                results.Add(result);
            }
        }

        foreach (int result in results)
        {
            Console.WriteLine(result);
        }
    }
}
