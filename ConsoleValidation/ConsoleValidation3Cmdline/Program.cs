if (args.Length != 2)
{
  Console.WriteLine("Please pass name and age.");
  return;
}

string? name = args[0];
string? age = args[1];

if (string.IsNullOrWhiteSpace(name))
{
  Console.WriteLine("You did not enter a name.");
  return;
}

if (string.IsNullOrWhiteSpace(age))
{
  Console.WriteLine("You did not enter an age.");
  return;
}

if (!int.TryParse(age, out int ageValue))
{
  Console.WriteLine("You did not enter a valid age.");
  return;
}

if (ageValue < 0)
{
  Console.WriteLine("You did not enter a valid age.");
  return;
}

Console.WriteLine($"Hello {name}! Age {ageValue}.");