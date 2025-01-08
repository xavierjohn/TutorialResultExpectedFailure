Console.WriteLine("Enter your name: ");
string? name = Console.ReadLine();

if (string.IsNullOrWhiteSpace(name))
{
  Console.WriteLine("You did not enter a name.");
  return;
}

Console.WriteLine($"Hello {name}!");