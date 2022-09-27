using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Driver;

namespace rankingApp.Models
{
	public class Player
	{
		public Player(string name, string score)
		{ 
			Name = name;
			Score = score;
		}

		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string? Id { get; set; }

		[BsonElement("name")]
		public string? Name { get; set; }

		[BsonElement("score")]
		public string? Score { get; set; }
	}
}
