using System;

abstract class Location
{
    public string Name { get; protected set; }
    public NPC NPC { get; set; }

    public virtual async Task DescribeAsync()
    {
        await Task.Run(() => Console.WriteLine($"You are in {Name}."));
    }
}