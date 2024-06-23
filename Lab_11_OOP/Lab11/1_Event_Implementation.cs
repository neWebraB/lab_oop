public class NameChangeEventArgs : EventArgs
{
    public string Name { get; set; }

    public NameChangeEventArgs(string name)
    {
        Name = name;
    }
}

public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs args);

public class Dispatcher
{
    public string name;
    public event NameChangeEventHandler NameChange;

    public string Name
    {
        get { return name; }
        set
        {
            name = value;
            OnNameChange(new NameChangeEventArgs(value));
        }
    }

    public void OnNameChange(NameChangeEventArgs args)
    {
        NameChange?.Invoke(this, args);
    }
}

public class Handler
{
    public void OnDispatcherNameChange(object sender, NameChangeEventArgs args)
    {
        Console.WriteLine($"Dispatcher's name changed to {args.Name}.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Dispatcher dispatcher = new Dispatcher();
        Handler handler = new Handler();
        List<string> names = new List<string>();

        dispatcher.NameChange += handler.OnDispatcherNameChange;

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            names.Add(input);
        }

        foreach (var name in names)
        {
            dispatcher.Name = name;
        }
    }
}
