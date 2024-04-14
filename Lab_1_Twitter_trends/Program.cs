using System.Text.Json;
using Lab_1_Twitter_trends;
using JsonObject = System.Text.Json.Nodes.JsonObject;

/*Parse one = new Parse(); //чисто проверка функций с парсера
one.ReadingText();
one.SeparationIntoTweets();
one.ConvertDataToTweet();

List<Tweet> tm = new List<Tweet>();

tm = one.ConvertDataToTweet();

for (int i = 0; i < tm.Count; i++)
{
    Console.WriteLine(tm[i]);
}*/

/*
AnalazingOfEmotionalityOfTweets em = new AnalazingOfEmotionalityOfTweets();
Dictionary<string, string> tm = em.ReadAndConvertFileWithSentiments();

Console.WriteLine(tm["'hood"]);
*/



/*for (int i = 0; i < tm.Count; i++)
{
    Console.WriteLine(tm[i]);
}*/
//Console.WriteLine(em.ReadAndConvertFileWithSentiments());



AnalazingOfEmotionalityOfTweets temp = new AnalazingOfEmotionalityOfTweets();


Parse e = new Parse();
List<Tweet> tweets = new List<Tweet>();

tweets = temp.CalculatingOfTheEmotionalParametr();


for (int i = 0; i < tweets.Count; i++)
{
    Console.WriteLine(i+1 + " === " + tweets[i].emotionalParametr);
}

/*JsonParse jf = new JsonParse();

jf.ReadJsonFile();*/

/*MapOfStates map = new MapOfStates();

map.DrawningMap();*/

/*LinkingTweetsToStates temp = new LinkingTweetsToStates();

temp.SearchStateOfTweet();*/
//temp.CreateDictionaryOfTweetsInPolygons();

//temp.LinkingStatesWithTweetsInDictionary();
