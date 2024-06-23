public class Program
{
    public static List<Soldier> Soldiers = new List<Soldier>();
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

        Soldiers.AddRange(royalGuards);
        Soldiers.AddRange(footmen);

        foreach (var soldier in Soldiers)
        {
            soldier.Death += (sender, args) =>
            {
                Soldiers.Remove((Soldier)sender);
            };
        }

        king.UnderAttack += (sender, args) =>
        {
            OutputBuffer.Add($"King {king.Name} is under attack!");
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
                king.OnAttack();
            }
            else if (tokens[0] == "Kill")
            {
                var nameToKill = tokens[1];
                var soldier = Soldiers.FirstOrDefault(s => s.Name == nameToKill);
                soldier?.TakeDamage();
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
    public bool IsAlive { get; protected set; } = true;
    public abstract int HitsToKill { get; }
    private int hitPoints;

    public event EventHandler Death;

    protected Soldier(string name)
    {
        Name = name;
        hitPoints = HitsToKill;
    }

    public abstract void RespondToAttack();

    public void TakeDamage()
    {
        hitPoints--;
        if (hitPoints <= 0)
        {
            IsAlive = false;
            Death?.Invoke(this, EventArgs.Empty);
        }
    }
}

public class RoyalGuard : Soldier
{
    public override int HitsToKill => 3;

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
    public override int HitsToKill => 2;

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
