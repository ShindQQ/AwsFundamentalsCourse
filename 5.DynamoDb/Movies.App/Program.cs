using System.Text.Json;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Movies.App;

await new DataSeeder().ImportDataAsync();

// var dynamoDb = new AmazonDynamoDBClient();
//
// var queryRequest = new QueryRequest
// {
//     TableName = "movies",
//     IndexName = "year-rotten-index",
//     KeyConditionExpression = "ReleaseYear = :v_Year and RottenTomatoesPercentage >= :v_Rotten",
//     ExpressionAttributeValues = new Dictionary<string, AttributeValue>
//     {
//         { ":v_Year", new AttributeValue { N = "2018" } },
//         { ":v_Rotten", new AttributeValue { N = "88" } }
//     }
// };
//
// var response = await dynamoDb.QueryAsync(queryRequest);
//
// foreach (var itemAttributes in response.Items)
// {
//     var document = Document.FromAttributeMap(itemAttributes);
//     var json = document.ToJsonPretty();
//     Console.Write(json);
// }

var newMovie1 = new Movie1
{
    Id = new Guid(),
    Title = "21 Jump Street",
    AgeRestriction = 18,
    ReleaseYear = 2012,
    RottenTomatoesPercentage = 85
};

var newMovie2 = new Movie2
{
    Id = new Guid(),
    Title = "21 Jump Street",
    AgeRestriction = 18,
    ReleaseYear = 2012,
    RottenTomatoesPercentage = 85
};

var asJson1 = JsonSerializer.Serialize(newMovie1);
var attributeMap1 = Document.FromJson(asJson1).ToAttributeMap();

var asJson2 = JsonSerializer.Serialize(newMovie2);
var attributeMap2 = Document.FromJson(asJson2).ToAttributeMap();

var transactionRequest = new TransactWriteItemsRequest
{
    TransactItems = new List<TransactWriteItem>
    {
        new()
        {
            Put = new Put
            {
                TableName = "movies-year-title",
                Item = attributeMap1
            }
        },
        new()
        {
            Put = new Put
            {
                TableName = "movies-title-rotten",
                Item = attributeMap2
            }
        }
    }
};

var dynamoDb = new AmazonDynamoDBClient();

var response = await dynamoDb.TransactWriteItemsAsync(transactionRequest);