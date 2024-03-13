using DistinctWebAPI.Database;
using DistinctWebAPI.Models.BatchingStrategy;
using DistinctWebAPI.Models.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddLogging();
builder.Services.AddSwaggerGen();

// controllers
builder.Services.AddControllers();

// database
builder.Services.AddScoped<TextDbContext>();

// injection
builder.Services.AddScoped<IBatchingStrategy, GroupByFirstLetterBatchingStrategy>(); // scoped lifetime
builder.Services.AddScoped<IDatabaseService, BulkDatabaseService>(); // scoped lifetime

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();