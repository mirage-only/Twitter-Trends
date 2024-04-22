namespace Lab_1_Twitter_trends;

using System.Threading.Channels;

public class Parser
{
    private string filePath =
        "D:\\University\\OOP technology\\Lab_1_Twitter_trends\\Lab_1_Twitter_trends\\TweetsFile";

    private string ReadingText() //чтение твитов из файла
    {
        string file = null;
        
        StreamReader reader = new StreamReader(filePath);

        file = reader.ReadToEnd();
        
        reader.Close();
        
        return file;
    }

    private List<string> SeparationIntoTweets() //тут разбиваю вот эту большую строку конкретно на твиты, разбиваю по открывающейся квадратной скобке, которая всегда начинает координаты нового твита
    {
        string file = ReadingText();
        List<string> tweets = new List<string>();

        string temp = String.Empty;   
        
        for (int i = 0; i < file.Length; i++)
        {
            if (tweets.Count == 0 &&  i == 0)
            {
                temp += file[i];
                continue;
            }
            
            if (file[i] != '[')
            {
                temp += file[i];
            }
            else
            {
                tweets.Add(temp);
                
                temp = String.Empty;
                temp += file[i];
            }

            if (i == file.Length - 1)
            {
                tweets.Add(temp);
            }
        }

        return tweets;
    }

    public List<Tweet> ConvertDataToTweet() 
    {
        List<string> unsplittedTweets = SeparationIntoTweets();

        List<Tweet> tweets = new List<Tweet>();

        
        string[] tempSplit;
        List<string> SplittedTweet = new List<string>();
        string[] splittedMessage;
        

        
        for (int i = 0; i < unsplittedTweets.Count; i++)
        {
            Tweet tweet = new Tweet();
            tweet.words = new List<string>();
            
            string tempStr = string.Empty;
            
            tempSplit = unsplittedTweets[i].Split('\t');

            for (int j = 0; j < tempSplit.Length; j++)
            {
                SplittedTweet.Add(tempSplit[j]);
            }

           
            tweet.coordinates = SplittedTweet[0];
            tweet.data = SplittedTweet[2];
            tweet.massage = SplittedTweet[3];
            tweet.emotionalParametr = 0;
            
            for (int j = 0; j < tweet.massage.Length; j++)
            {
                    if (!char.IsPunctuation(tweet.massage[j]))
                    {
                        tempStr += tweet.massage[j];
                    }
            }

            splittedMessage = tempStr.Split();

            for (int j = 0; j < splittedMessage.Length; j++)
            {
                if (splittedMessage[j] != string.Empty)
                {
                    tweet.words.Add(splittedMessage[j].ToLower());
                }
            }

            tempSplit = [];
            SplittedTweet.Clear();
            tweets.Add(tweet);
        }
        
        return tweets;
    }
    
}
