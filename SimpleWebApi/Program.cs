var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.MapGet("/", () => "API running...");

app.MapGet("/load", async (int tasks = 10, int delayInMs = 1000) =>
{
    await RunConcurrentTasksAsync(tasks, delayInMs);
    return Results.Ok($"{tasks} tarefas executadas simultaneamente com ({delayInMs}ms cada)");
});

app.Run();

static async Task RunConcurrentTasksAsync(int numberOfTasks, int delayMilliseconds)
{
    var tasks = new List<Task>();

    for (int i = 0; i < numberOfTasks; i++)
    {
        tasks.Add(Task.Run(async () =>
        {
            await Task.Delay(delayMilliseconds);
        }));
    }

    await Task.WhenAll(tasks);
}
