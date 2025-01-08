Console.WriteLine("Enter your name: ");
string? name = Console.ReadLine();

if (string.IsNullOrWhiteSpace(name))
{
  Console.WriteLine("You did not enter a name.");
  return;
}

Console.WriteLine("Enter your age: ");
string? age = Console.ReadLine();

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