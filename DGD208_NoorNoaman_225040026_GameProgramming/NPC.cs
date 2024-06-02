using System;

class NPC
{
    public string Name { get; private set; }
    public string Item { get; private set; }

    public NPC(string name, string item)
    {
        Name = name;
        Item = item;
    }
}