public class Program
{
    public static List<string> OutputBuffer = new List<string>();

    public static void Main()
    {
        var king = new King(Console.ReadLine());

        var royalGuards = Console.ReadLine()
                                 .Split()
                                 .Select(name => new RoyalGuard(name))
                                 .ToList();

        var footmen = Console.ReadLine()
                             .Split()
                             .Select(name => new Footman(name))
                             .ToList();

        king.UnderAttack += (sender, args) =>
        {
            foreach (var guard in royalGuards.Where(g => g.IsAlive))
            {
                guard.RespondToAttack();
            }

            foreach (var footman in footmen.Where(f => f.IsAlive))
            {
                footman.RespondToAttack();
            }
        };

        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            var tokens = command.Split();
            if (tokens[0] == "Attack")
            {
                OutputBuffer.Add($"King {king.Name} is under attack!");
                king.OnAttack();
            }
            else if (tokens[0] == "Kill")
            {
                var nameToKill = tokens[1];
                var royalGuard = royalGuards.FirstOrDefault(g => g.Name == nameToKill);
                var footman = footmen.FirstOrDefault(f => f.Name == nameToKill);

                if (royalGuard != null)
                {
                    royalGuard.IsAlive = false;
                }
                else if (footman != null)
                {
                    footman.IsAlive = false;
                }
            }
        }

        foreach (var line in OutputBuffer)
        {
            Console.WriteLine(line);
        }
    }
}

public class King
{
    public string Name { get; }
    public event EventHandler UnderAttack;

    public King(string name)
    {
        Name = name;
    }

    public void OnAttack()
    {
        UnderAttack?.Invoke(this, EventArgs.Empty);
    }
}

public abstract class Soldier
{
    public string Name { get; }
    public bool IsAlive { get; set; } = true;

    protected Soldier(string name)
    {
        Name = name;
    }

    public abstract void RespondToAttack();
}

public class RoyalGuard : Soldier
{
    public RoyalGuard(string name) : base(name)
    {
    }

    public override void RespondToAttack()
    {
        if (IsAlive)
        {
            Program.OutputBuffer.Add($"Royal Guard {Name} is defending!");
        }
    }
}

public class Footman : Soldier
{
    public Footman(string name) : base(name)
    {
    }

    public override void RespondToAttack()
    {
        if (IsAlive)
        {
            Program.OutputBuffer.Add($"Footman {Name} is panicking!");
        }
    }
}
