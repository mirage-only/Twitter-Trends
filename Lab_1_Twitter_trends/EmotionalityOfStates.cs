namespace Lab_1_Twitter_trends;

public class EmotionalityOfStates
{
    public Dictionary<string, double?> CalculateAverageEmotionalityOfTweet()
    {
        LinkingTweetsToStates temp = new LinkingTweetsToStates();

        Dictionary<string, List<Tweet>> tweetsOfStates = temp.SearchStateOfTweet();

        Dictionary<string, double?> averageEmotionalMean = new Dictionary<string, double?>();

        double? average;
        double? sumEmotion;
        
        foreach (var pair in tweetsOfStates)
        {
            average = 0.0;
            sumEmotion = 0.0;
            
            foreach (var VARIABLE in pair.Value)
            {
                if (VARIABLE.emotionalParametr != null)
                {
                    sumEmotion += VARIABLE.emotionalParametr;
                }
            }

            if (pair.Value.Count != 0)
            {
                average = sumEmotion / pair.Value.Count;
            }
            else
            {
                average = null;
            }

            averageEmotionalMean.Add(pair.Key, average);
        }
        
        return averageEmotionalMean;
    }
}