using System;

class Forest : Location
{
    public Forest()
    {
        Name = "Forest";
    }

    public override async Task DescribeAsync()
    {
        await Task.Delay(1000);
        Console.WriteLine("You are surrounded by tall trees and hear the sounds of nature.");
    }
}
