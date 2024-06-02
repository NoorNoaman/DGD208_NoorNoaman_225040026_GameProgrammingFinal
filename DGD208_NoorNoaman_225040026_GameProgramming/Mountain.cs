using System;

class Mountain : Location
{
    public Mountain()
    {
        Name = "Mountain";
    }

    public override async Task DescribeAsync()
    {
        await Task.Delay(1000);
        Console.WriteLine("You are on a steep mountain. The view is breathtaking.");
    }
}
