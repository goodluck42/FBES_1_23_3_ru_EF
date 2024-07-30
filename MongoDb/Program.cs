using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization.Attributes;


var client = new MongoClient("mongodb://localhost:27017");
var db = client.GetDatabase("ItBottle");

db.CreateCollection("Accounts");

var bsonAccountCollection = db.GetCollection<BsonDocument>("Accounts");
var accountCollection = db.GetCollection<Account>("Accounts");

// CREATE (insert)
{
	//// #1
	// accountCollection.InsertOne(new Account
	// {
	// 	Login = "my_login",
	// 	Password = "my_pass"
	// });


	//// #2
	// accountCollection.InsertMany([new()
	// {
	// 	Login = "my_login2",
	// 	Password = "my_password2"
	// }, new()
	// {
	// 	Login = "my_login3",
	// 	Password = "my_password3"
	// }]);
}

// READ (get) /1
{
	// var filter1 = Builders<Account>.Filter.Eq(a => a.Login, "my_login");
	// var filter2 = Builders<Account>.Filter.Eq(a => a.Password, "my_pass");
	// var result = accountCollection.Find(filter1 & filter2);
	//
	// foreach (var account in result.ToEnumerable())
	// {
	// 	Console.WriteLine(account.Id);
	// 	Console.WriteLine(account.Login);
	// 	Console.WriteLine(account.Password);
	// }
}


// READ (get) /2
{
	// var result = accountCollection
	// 	.AsQueryable()
	// 	.Where(a => a.Login == "my_login" && a.Password == "my_pass") // <- IEnumerable<Account>;
	// 	.Select(a => new // <- IEnumerable<?>
	// 	{
	// 		Login = a.Login,
	// 		Password = a.Password
	// 	});
	//
	// foreach (var account in result)
	// {
	// 	// Console.WriteLine(account.Id);
	// 	Console.WriteLine(account.Login);
	// 	Console.WriteLine(account.Password);
	// }
}


// UPDATE (update)
{
	// var loginFilterDefinition = Builders<Account>.Filter.Eq(a => a.Login, "my_login");
	// var updateDefinition = Builders<Account>.Update.Set(a => a.Password, "my_new_pass");
	// var result = accountCollection.UpdateOne(loginFilterDefinition, updateDefinition);
	//
	// Console.WriteLine($"MatchedCount = {result.MatchedCount}");
	// Console.WriteLine($"ModifiedCount = {result.ModifiedCount}");
}

// DELETE (delete)

{
	// var filterDefinition = Builders<Account>.Filter.Eq(a => a.Login, "my_login3"); // account.Login == "my_login3"
	// var result = accountCollection.DeleteOne(filterDefinition);
	//
	// Console.WriteLine($"DeletedCount = {result.DeletedCount}");
	//
	// if (result.DeletedCount == 0)
	// {
	// 	Console.WriteLine("Account not found!");
	// }
}

// UPSERT (UPDATE + INSERT) 
{
	// var filterDef = Builders<Account>.Filter.Eq(a => a.Login, "my_login");
	// ObjectId oldId;
	//
	// try
	// {
	// 	oldId = accountCollection.Find(filterDef).First().Id;
	// }
	// catch
	// {
	// 	oldId = new ObjectId();
	// }
	//
	// accountCollection.ReplaceOne(filterDef, new Account
	// {
	// 	Id = oldId,
	// 	Login = "my_new_login1337",
	// 	Password = "my_super_secret_password42"
	// }, new ReplaceOptions
	// {
	// 	IsUpsert = true
	// });
}

///////////////////////////////////

// CREATE (insert)

{
	var newAccount = new BsonDocument
	{
		{ "login", "new_bson_login123" },
		{ "password", "new_bson_password456" },
		{ "is_banned", new BsonBoolean(false) },
		{ "old_passwords", new BsonArray
		{
			"old_pass1", "old_pass2", new BsonDocument()
			{
				{"old", "old_pass_4"},
				{"new", "new_pass"},
			}
		} }
	};

	// Console.WriteLine(newAccount.ToJson(new JsonWriterSettings
	// {
	// 	Indent = true
	// }));
	
	bsonAccountCollection.InsertOne(newAccount);
}


class Account
{
	[BsonId] public ObjectId Id { get; set; }

	[BsonElement("login")] public string? Login { get; set; }

	[BsonElement("password")] public string? Password { get; set; }
}