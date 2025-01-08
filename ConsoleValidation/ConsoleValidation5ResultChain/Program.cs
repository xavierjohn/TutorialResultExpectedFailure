using FunctionalDdd;

if (args.Length != 2)
{
  Console.WriteLine("Please pass name and age.");
  return;
}

ValidateName(args[0])
.Combine(ValidateAge(args[1]))
.Tap((name, age) => { Console.WriteLine($"Hello {name}! Age {age}.");})
.TapError(e => {
  ValidationError validationError = (ValidationError)e;
  foreach (ValidationError.FieldDetails detail in validationError.Errors)
    Console.WriteLine(detail.Details[0]);
});


static Result<string> ValidateName(string? name)
{
  if (string.IsNullOrWhiteSpace(name))
    return Error.Validation("You did not enter a name.");

  return name;
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