using MongoDB.Driver;
using MongoDB.Bson;
using rankingApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();
var client = new MongoClient("mongodb+srv://m220student:m220password@mflix.x7rlcqp.mongodb.net/?retryWrites=true&w=majority");
var database = client.GetDatabase("contest_players");
var collection = database.GetCollection<Player>("players");

// Configure the HTTP request pipeline.


app.UseHttpsRedirection();


//read all
app.MapGet("/players", () =>
{
	var players = collection.Find(player => true).ToList();
	return players;
});

//read a specific one
app.MapGet("/players/{id}", (string id) =>
{
	var player = collection.Find(player => player.Id == id).FirstOrDefault();
	return player;
});


//create
app.MapPost("/players", (string name, string score) =>
{
	var player = new Player(name, score);
	collection.InsertOne(player);
	return Results.Created($"/players/{player.Id}", player);
});

//update
app.MapPut("/players/{id}", (string id, Player player) =>
{
	collection.ReplaceOne(p => p.Id == id, player);
	return Results.Ok(player);
});

//delete
app.MapDelete("/players/{id}", (string id) =>
{
	collection.DeleteOne(p => p.Id == id);
	return Results.Ok();
});

app.Run();
