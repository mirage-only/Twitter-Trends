namespace Lab_1_Twitter_trends;


public class AnalazingOfEmotionalityOfTweets
{
    private static Parse dataOfParse = new Parse();
    
    public Dictionary<string, string> ReadAndConvertFileWithSentiments()
    {
        string file;
        List<string> splittedStr = new List<string>();
        Dictionary<string, string> couplesOfSentiments = new Dictionary<string, string>();
        char[] splitSymbols = { ',', '\r', '\n'};
        
        StreamReader reader = new StreamReader("D:\\University\\OOP technology\\Lab_1_Twitter_trends\\Lab_1_Twitter_trends\\Sentiments.csv");

        file = reader.ReadToEnd();

        splittedStr = file.Split(splitSymbols).ToList();
        splittedStr.RemoveAt(splittedStr.Count - 1);

        for (int i = 0; i < splittedStr.Count; i++)
        {
            if (i % 2 == 0)
            {
                couplesOfSentiments.Add(splittedStr[i], null);
                continue;
            }
            
            if(i % 2 == 1)
            {
                couplesOfSentiments[splittedStr[i-1]] = splittedStr[i];
            }
        }
        
        return couplesOfSentiments;
    }

    public void CalculatingOfTheEmotionalParametr()
    {
        Parse parserData = new Parse();
        List<Tweet> tweets = parserData.ConvertDataToTweet();
        
        Dictionary<string, string> dataEmotionParametr = ReadAndConvertFileWithSentiments();

        for (int i = 0; i < tweets.Count; i++)
        {
            for (int j = 0; j < tweets[i].words.Count; j++)
            {
                foreach(KeyValuePair<string, string> word in dataEmotionParametr)
                {
                    if (word.Key == tweets[i].words[j])
                    {
                        tweets[i].emotionalParametr += Convert.ToDouble(word.Value);
                    }   
                }
            }
        }
    }

    
}
