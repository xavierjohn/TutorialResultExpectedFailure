// Multiple failures.
if (args.Length != 2)
{
  Console.WriteLine("Please pass name and age.");
  return;
}

string? name = args[0];
string? age = args[1];
List<string> errors = [];

if (string.IsNullOrWhiteSpace(name))
{
  errors.Add("You did not enter a name.");
}

int ageValue = 0;
if (string.IsNullOrWhiteSpace(age)
  || !int.TryParse(age, out ageValue)
  || ageValue < 0)
{
  errors.Add("You did not enter a valid age.");
}

if (errors.Count > 0)
{
  foreach (string error in errors)
    Console.WriteLine(error);
}
else
  Console.WriteLine($"Hello {name}! Age {ageValue}.");
