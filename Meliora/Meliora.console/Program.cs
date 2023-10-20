// Count 1 to 50

Console.WriteLine("================= Count 1 to 50 =====================");

for (var i = 1; i <= 50; i++)
{
    if (i % 7 == 0 && i % 3 == 0)
    {
        Console.WriteLine("Nursing Meliora");
    }
    else if (i % 3 == 0)
    {
        Console.WriteLine("Nursing");
    }
    else if (i % 7 == 0)
    {
        Console.WriteLine("Meliora");
    }
    else
    {
        Console.WriteLine(i.ToString());
    }
}

Console.WriteLine("============= End Count 1 to 50 =====================");