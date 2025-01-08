using FunctionalDdd;

if (args.Length != 2)
{
  Console.WriteLine("Please pass name and age.");
  return;
}

string? name = args[0];
string? age = args[1];

Result<string> rName = string.IsNullOrWhiteSpace(name)
  ? Result.Failure<string>(Error.Validation("You did not enter a name."))
  : Result.Success(name);

Result<int> rAge = ValidateAge(age);


if (rName.IsSuccess && rAge.IsSuccess)
{
  Console.WriteLine($"Hello {rName.Value}! Age {rAge.Value}.");
}
else
{
  if (rName.IsFailure)
    Console.WriteLine(rName.Error.Detail);
  if (rAge.IsFailure)
    Console.WriteLine(rAge.Error.Detail);
}

static Result<int> ValidateAge(string? age)
{
  if (string.IsNullOrWhiteSpace(age)
    || !int.TryParse(age, out int ageValue)
    || ageValue < 0)
  {
    return Error.Validation("You did not enter a valid age.");
  }

  return ageValue;
}