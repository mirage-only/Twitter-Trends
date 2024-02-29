
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


using Lab_1_Twitter_trends;

AnalazingOfEmotionalityOfTweets temp = new AnalazingOfEmotionalityOfTweets();


Parse e = new Parse();
List<Tweet> tweets = new List<Tweet>();

tweets = e.ConvertDataToTweet();
temp.CalculatingOfTheEmotionalParametr();

for (int i = 0; i < tweets.Count; i++)
{
    Console.WriteLine(i+1 + "===" + tweets[i].emotionalParametr);
}