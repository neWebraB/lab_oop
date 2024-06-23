public interface IEmployee
{
    string Name { get; }
    int WorkHoursPerWeek { get; }
}

public class StandardEmployee : IEmployee
{
    public string Name { get; }
    public int WorkHoursPerWeek { get; } = 40;

    public StandardEmployee(string name)
    {
        Name = name;
    }
}

public class PartTimeEmployee : IEmployee
{
    public string Name { get; }
    public int WorkHoursPerWeek { get; } = 20;

    public PartTimeEmployee(string name)
    {
        Name = name;
    }
}

public class JobDoneEventArgs : EventArgs
{
    public string JobName { get; set; }
}

public class Job
{
    public string Name { get; }
    public int HoursOfWorkRequired { get; private set; }
    private readonly IEmployee employee;

    public event EventHandler<JobDoneEventArgs> JobDone;

    public Job(string name, int hoursOfWorkRequired, IEmployee employee)
    {
        Name = name;
        HoursOfWorkRequired = hoursOfWorkRequired;
        this.employee = employee;
    }

    public void Update()
    {
        HoursOfWorkRequired -= employee.WorkHoursPerWeek;
        if (HoursOfWorkRequired <= 0)
        {
            JobDone?.Invoke(this, new JobDoneEventArgs { JobName = this.Name });
        }
    }
}

public class JobCollection
{
    private readonly List<Job> jobs = new List<Job>();
    private readonly List<string> outputMessages = new List<string>();

    public void AddJob(Job job)
    {
        jobs.Add(job);
        job.JobDone += JobOnJobDone;
    }

    private void JobOnJobDone(object sender, JobDoneEventArgs e)
    {
        outputMessages.Add($"Job {e.JobName} done!");
        jobs.Remove(sender as Job);
    }

    public void PassWeek()
    {
        foreach (var job in new List<Job>(jobs))
        {
            job.Update();
        }
    }

    public void Status()
    {
        foreach (var job in jobs)
        {
            outputMessages.Add($"Job: {job.Name} Hours Remaining: {job.HoursOfWorkRequired}");
        }
    }

    public IEnumerable<string> GetOutput()
    {
        return outputMessages;
    }
}

class Program
{
    static void Main()
    {
        JobCollection jobCollection = new JobCollection();
        Dictionary<string, IEmployee> employees = new Dictionary<string, IEmployee>();
        List<string> commands = new List<string>();

        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            commands.Add(command);
        }

        foreach (var cmd in commands)
        {
            var tokens = cmd.Split();
            switch (tokens[0])
            {
                case "StandardEmployee":
                    employees[tokens[1]] = new StandardEmployee(tokens[1]);
                    break;
                case "PartTimeEmployee":
                    employees[tokens[1]] = new PartTimeEmployee(tokens[1]);
                    break;
                case "Job":
                    var job = new Job(tokens[1], int.Parse(tokens[2]), employees[tokens[3]]);
                    jobCollection.AddJob(job);
                    break;
                case "Pass":
                    jobCollection.PassWeek();
                    break;
                case "Status":
                    jobCollection.Status();
                    break;
            }
        }

        foreach (var message in jobCollection.GetOutput())
        {
            Console.WriteLine(message);
        }
    }
}
