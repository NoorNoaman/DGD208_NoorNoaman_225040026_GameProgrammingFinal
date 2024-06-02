using System;

class Player
{
    public string Name { get; private set; }
    public int Health { get; private set; }
    public Location CurrentLocation { get; set; }
    private List<string> Inventory { get; set; }

    public Player(string name, int health)
    {
        Name = name;
        Health = health;
        Inventory = new List<string> { "Sword", "Shield", "Potion" };
    }

    public async Task LookAroundAsync()
    {
        await CurrentLocation.DescribeAsync();
    }

    public async Task MoveAsync()
    {
        Console.WriteLine("Where would you like to go?");
        Console.WriteLine("1. Forest");
        Console.WriteLine("2. Mountain");
        Console.WriteLine("3. Village");

        string choice = await GetUserInputAsync();

        switch (choice)
        {
            case "1":
                CurrentLocation = new Forest();
                break;
            case "2":
                CurrentLocation = new Mountain();
                break;
            case "3":
                CurrentLocation = new Village();
                break;
            default:
                Console.WriteLine("Invalid choice. pick a number, where do you want to go?");
                return;
        }

        Console.WriteLine($"You moved to a new location: {CurrentLocation.Name}");

        // Set the NPC for the new location
        if (CurrentLocation is Village)
        {
            CurrentLocation.NPC = new NPC("Merchant", "Magic Amulet");
        }
        else
        {
            CurrentLocation.NPC = null;
        }
    }

    public void ShowInventory()
    {
        Console.WriteLine("Your inventory contains:");
        foreach (var item in Inventory)
        {
            Console.WriteLine($"- {item}");
        }
    }

    public void ShowHealth()
    {
        Console.WriteLine($"Your current health is: {Health}");
    }

    public async Task InteractAsync()
    {

        if (CurrentLocation.NPC != null)
        {
            Console.WriteLine($"He has a {CurrentLocation.NPC.Item}.");
            Console.WriteLine("Do you want to take the item? [yes/no]");
            string choice = await GetUserInputAsync();

            if (choice.ToLower() == "yes")
            {
                Inventory.Add(CurrentLocation.NPC.Item);
                Console.WriteLine($"You have taken the {CurrentLocation.NPC.Item} from {CurrentLocation.NPC.Name}, you won the game!\n\nYou can still move around and discover the place.");
                CurrentLocation.NPC = null; // NPC disappears after giving the item
            }
            else
            {
                Console.WriteLine("You decided not to take the item. Now the game makes no sense, thanks alot.");
            }
        }
        else
        {
            Console.WriteLine("There is no one to interact with here.");
        }
    }

    static async Task<string> GetUserInputAsync()
    {
        return await Task.Run(() => Console.ReadLine());
    }
}
