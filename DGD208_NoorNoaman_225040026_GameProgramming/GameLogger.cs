using System;

static class GameLogger
{
    public static async Task LogInputAsync(string filePath, string input)
    {
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            await writer.WriteLineAsync($"{DateTime.Now}: {input}");
        }
    }
}