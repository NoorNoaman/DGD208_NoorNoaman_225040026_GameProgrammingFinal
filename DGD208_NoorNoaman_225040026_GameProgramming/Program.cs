using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;

namespace DGD208_NoorNoaman_225040026_GameProgramming
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Player player = new Player("Adventurer", 100);
            player.CurrentLocation = new Village();

            NPC npc = new NPC("Merchant", "Magic Amulet");
            player.CurrentLocation.NPC = npc;

            Console.WriteLine("Welcome to the Final Game Programming Project!");

            // Start the game loop
            await GameLoop(player);
        }

        static async Task GameLoop(Player player)
        {
            bool isRunning = true;
            string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Player Saved Info.txt");

            // Ensure the log file is created and cleared at the start
            using (StreamWriter writer = new StreamWriter(logFilePath, false))
            {
                await writer.WriteLineAsync("Game Started");
            }

            while (isRunning)
            {
                Console.WriteLine("\nChoose an action: [look, move, inventory, health, interact, quit]");
                string input = await GetUserInputAsync();

                // Log user input
                await GameLogger.LogInputAsync(logFilePath, input);

                switch (input.ToLower())
                {
                    case "look":
                        await player.LookAroundAsync();
                        break;
                    case "move":
                        await player.MoveAsync();
                        break;
                    case "inventory":
                        player.ShowInventory();
                        break;
                    case "health":
                        player.ShowHealth();
                        break;
                    case "interact":
                        await player.InteractAsync();
                        break;
                    case "quit":
                        isRunning = false;
                        Console.WriteLine("Thanks for playing!");
                        await GameLogger.LogInputAsync(logFilePath, "Game Ended");
                        break;
                    default:
                        Console.WriteLine("Invalid action. Try again.");
                        break;
                }
            }
        }

        static async Task<string> GetUserInputAsync()
        {
            return await Task.Run(() => Console.ReadLine());
        }
    }
}