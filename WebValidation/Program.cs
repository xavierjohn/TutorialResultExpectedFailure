using FunctionalDdd;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/hello/{name}/{age}", (string name, string age) =>
  ValidateName(name)
  .Combine(ValidateAge(age))
  .Bind((name, age) => Result.Success($"Hello {name}! Age {age}."))
  .ToHttpResult());


app.Run();

static Result<string> ValidateName(string? name)
{
  if (string.IsNullOrWhiteSpace(name))
    return Error.Validation("You did not enter a name.", nameof(name));

  return name;
}

static Result<int> ValidateAge(string? age)
{
  if (string.IsNullOrWhiteSpace(age)
    || !int.TryParse(age, out int ageValue)
    || ageValue < 0)
  {
    return Error.Validation("You did not enter a valid age.", nameof(age));
  }

  return ageValue;
}