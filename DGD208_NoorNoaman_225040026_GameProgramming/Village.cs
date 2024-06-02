using System;

class Village : Location
{
    public Village()
    {
        Name = "Village";
    }

    public override async Task DescribeAsync()
    {
        await Task.Delay(1000);
        Console.WriteLine("You are in a peaceful village with friendly inhabitants, there is a merchant here, you can interact with him.");
    }
}