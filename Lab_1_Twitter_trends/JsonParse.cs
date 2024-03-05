using Newtonsoft.Json;

namespace Lab_1_Twitter_trends;

public class JsonParse
{
    public void t()
    { 
        /*Tweet tweet = new Tweet();
            
        tweet.coordinates = "fefw";
        tweet.massage = "хууууууууй";
        tweet.emotionalParametr = 325.123;

        string json = JsonConvert.SerializeObject(tweet);

        Tweet r = new Tweet();

        r = JsonConvert.DeserializeObject<Tweet>(json);*/
    }

    public void ReadJsonFile()
    {
        
        Dictionary<string, List<List<List<double>>>> pairIndexCoordynates = new Dictionary<string, List<List<List<double>>>>();
        
        const string filePath = "D:\\University\\OOP technology\\Lab_1_Twitter_trends\\Lab_1_Twitter_trends\\CoordinatesOfStates.json";

        StreamReader reader = new StreamReader(filePath);

        string jsonData = reader.ReadToEnd();

        pairIndexCoordynates = JsonConvert.DeserializeObject<Dictionary<string, List<List<List<double>>>>>(jsonData);

        Console.WriteLine(pairIndexCoordynates["WA"][0][0][1]);
    }
    
}