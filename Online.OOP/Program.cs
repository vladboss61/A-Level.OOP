using static Online.OOP.Program;

namespace Online.OOP;


//C# 9 > default implementation.
public interface IMachine
{
    public void Start();

    public void Stop();
}

public interface IMaker
{
    public void Setup();
}


public interface IEngine
{
    public void Start();

    public void Stop();
}

public class Car : IMachine, IEngine, IDisposable
{
    public void Start()
    {
        Console.WriteLine("Default Start");
    }

    public void Stop()
    {
        Console.WriteLine("Default Stop");
    }

    public void Dispose()
    {
        Console.WriteLine("Dispose");
    }
}


public class CoffeeMachine
{
    public CoffeeMachine()
    {
        Console.WriteLine("CoffeeMachine - 1");
    }

    public string MachineName { get; set; }

    public string MachineSerialNumber { get; set; }
    
    private string PrivateMemberExampleForExtention { get; set; }

    public virtual void MakeCoffee()
    {
        Console.WriteLine(PrivateMemberExampleForExtention);
        Console.WriteLine("Make coffee using CoffeeMachine class");
    }
}

public class CappuccinoMachine : CoffeeMachine
{
    public CappuccinoMachine()
    {
        Console.WriteLine(" CappuccinoMachine -2");
    }

    public int MilkVolume { get; set; }

    public override void MakeCoffee()
    {
        base.MakeCoffee();
        Console.WriteLine($"Create coffee using milk: {MilkVolume}");
    }

    public void RefillWater()
    {
        base.MakeCoffee();
        Console.WriteLine("Refilling Water....");
    }

    public override string ToString()
    {
        return $"Cappuccino Machine {MachineSerialNumber}";
    }
}

public class House
{
   public Room LivingRoom { get; set; }

   public Room NightRoom { get; set; }
}

public class Room
{
    public Door[] Doors { get; set; }
}


public class Door
{
    public string Color { get; set; }
}

internal sealed class AmericanoMachine : CoffeeMachine, IMachine, IMaker
{
    public override void MakeCoffee()
    {
        base.MakeCoffee();
        Console.WriteLine("Americano Coffee");
    }

    public void Setup()
    {
        Console.WriteLine("Clear water, prepare coffee beans.");
    }

    public void Start()
    {
        throw new NotImplementedException();
    }

    public void Stop()
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return $"=== Americano Machine {MachineSerialNumber} ===";
    }
}


public class TeaMachine : CoffeeMachine
{
    public override void MakeCoffee()
    {
        base.MakeCoffee();
        Console.WriteLine("Prepare Tea.");
    }
}


public abstract class Animal
{
    protected Animal()
    {

    }

    public string Name { get; set; }

    public string GetDescription()
    {
        return "Some Animal";
    }

    public void LifeActivity()
    {
        Console.WriteLine("LifeActivity");
        Voice();
        Move();
    }

    public abstract void Voice();

    public abstract void Move();
}


public sealed class Dog : Animal
{
    public override void Move()
    {
    }

    public override void Voice()
    {
        Console.WriteLine("Bark Bark");
    }
}

public sealed class Cat : Animal
{
    public override void Move()
    {
    }

    public override void Voice()
    {
        Console.WriteLine("Meow Meow");
    }
}

public class A
{
    public virtual void Display()
    {
        Console.WriteLine("Write A");
    }
}

public class B : A
{
    public new void Display()
    {
        Console.WriteLine("Write B");
    }
}


public class User
{
    public virtual bool IsAlive() 
    {
        return true;
    }
}

public class DeadUser : User
{
    public override bool IsAlive()
    {
        base.IsAlive();

        return false;
    }
}


internal class Program
{
    public static void DeterminateType(IResult result)
    {
        switch (result)
        {
            case FileResult:
                Console.WriteLine("FileResult");
                break;

            case GithubResult:
                Console.WriteLine("GithubResult");
                break;

            default:
                break;
        }
    }

    static void Main(string[] args)
    {

        var person = new Person { Age = 25, Name = "Vlad" };

        (string name, int age) = person; //person.Deconstruct(out string name, out int age)

        Console.WriteLine(name);
        Console.WriteLine(age);



        new PatrialClass() { };

        var fileRepository = new FileSystemRepository();
        var githubRepository = new GithubRepository(new HttpClient());

        var random = new Random();

        if (random.Next(0, 1000) < 500)
        {
            new Application(fileRepository).Run();
        }
        else
        {
            new Application(githubRepository).Run();
        }

        var repositories = new IRepository[] { fileRepository, githubRepository };
        
        for (int i = 0; i < repositories.Length; i++)
        {
            Console.WriteLine("Start working with repositories");
            IResult result = repositories[i].GetItem();
            
            DeterminateType(result);
            DeterminateType(result);

            var newArray =  new[] { random.Next(0, 1000), random.Next(0, 1000) };

            for (int j = 0; j < newArray.Length; j++)
            {
                Console.WriteLine();
            }
        }






        PrepareCoffee(new AmericanoMachine());
        PrepareCoffee(new CappuccinoMachine());
        PrepareCoffee(new TeaMachine());


        var house = new House()
        {
            LivingRoom = new Room()
            {
                Doors = new Door[] { new Door() { Color = "White" }, new Door() { Color = "Black" } }
            },
            NightRoom = new Room()
            {
                Doors = new Door[] { new Door() { Color = "Yellow" } }
            },
        };


        CappuccinoMachine cappuccinoMachine = new CappuccinoMachine();
        IMachine machine = new Car();

        machine.Start();
        machine.Stop();

        IEngine engin = new Car();

        engin.Start();
        engin.Stop();

        A a = new B();
        a.Display();

        B b = new B();
        b.Display();

        Animal animal1 = new Dog() {  Name = "Dog John" };
        Animal animal2 = new Cat() { Name = "Dog Tom" };

        animal1.LifeActivity();
        animal2.LifeActivity();

        var number = new Random().Next(0, 100);
        CoffeeMachine coffeeMachine = number > 40 
            ? new AmericanoMachine() {  MachineSerialNumber = "#980" }
            : new CappuccinoMachine() { MachineSerialNumber = "#777", MilkVolume = 199 };


        //Extension Method
        coffeeMachine.AddSugar(10); // Extensions.AddSugar(coffeeMachine, 10); // Extension method.
        Extensions.AddSugar(coffeeMachine, 10);

        //new int[] {1, 24, 5, 6}.Where(x => x % 2 == 0).Select(x => x * 2);

        var castedCappuccinoMachine = coffeeMachine as CappuccinoMachine;
        if (castedCappuccinoMachine == null)
        {
            Console.WriteLine("Okey You have something another behind");
        } else
        {
            Console.WriteLine("Milk: " + castedCappuccinoMachine.MilkVolume);
        }

        var exceptionCastedCappuccinoMachine = (CappuccinoMachine)coffeeMachine;

        //C# 9
        switch(coffeeMachine)
        {
            case AmericanoMachine:
                break;

            case CappuccinoMachine:
                break;

            case null:
                Console.WriteLine();
                break;
        }

        var str = coffeeMachine.ToString();

        coffeeMachine.MakeCoffee();

        Shipping(new AmericanoMachine() { MachineSerialNumber = "123" });
        Shipping(new Car());


        #region
        //var machine = new CoffeeMachine() {
        //    MachineName = "General Coffee Machine",
        //    MachineSerialNumber = "#12456"};

        //machine.MakeCoffee();

        //var cappuccinoMachine = new CappuccinoMachine() { 
        //    MachineName = "Cappuccino Coffee Machine",
        //    MachineSerialNumber = "#99999",
        //    MilkVolume = 50
        //};

        //cappuccinoMachine.MakeCoffee();

        #endregion
        //Serilog.
        Console.WriteLine("Hello, World!");
    }


    public static void PrepareCoffee(CoffeeMachine coffeeMachine)
    {
        Console.WriteLine("Loading....");
        coffeeMachine.MakeCoffee();
        Console.WriteLine("Coffee is ready, have a good day.");
    }




    public interface IResult
    {
        public string Name { get; set; }
    }

    public class GithubResult : IResult
    {
        public string Name { get; set; } = "Github";
    }


    public class FileResult : IResult
    {
        public string Name { get; set; } = "File System";
    }


    public interface IRepository
    {
        public IResult GetItem();
    }


    public class GithubRepository : IRepository
    {
        private readonly HttpClient _httpClient;

        public GithubRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IResult GetItem()
        {
            var result = _httpClient.GetAsync("...").Result;
            return new GithubResult { Name = result.ToString() };
        }
    }

    public class FileSystemRepository : IRepository
    {
        public IResult GetItem()
        {
            return new FileResult();
        }
    }

    public class Application
    {
        private readonly IRepository _repository;

        public Application(IRepository repository)
        {
            _repository = repository;
        }

        public void Run()
        {
            Console.WriteLine(_repository.GetItem());
        }
    }





    public static int CalculatePrice(int count, string name)
    {
        var price = count * 25;
        return price + name.Length;
    }

    public static int CalculatePrice(int count, string name, double weight)
    {
        int result = CalculatePrice(count, name) + (int)weight / 2;
        return result;
    }

    public static void Shipping(IMachine coffeeMachine)
    {
        Console.WriteLine("Shipping");
    }
}
