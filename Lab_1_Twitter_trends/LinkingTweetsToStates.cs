using System.Drawing;
using System.Globalization;

namespace Lab_1_Twitter_trends;

public class LinkingTweetsToStates
{
    IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
    
    private Dictionary<string, List<Tweet>>
        CreateDictionaryOfTweetsInPolygons() //создание словаря, гже будут храниться ключами индиксы, значениями твиты, котоыре по координатам принадлежат штату
    {
        Dictionary<string, List<Tweet>> dictionary = new Dictionary<string, List<Tweet>>();

        JsonParser temp = new JsonParser();

        Dictionary<string, List<List<List<float>>>> dictionaryForTakeIndexes = temp.ReadJsonFile();

        foreach (var index in dictionaryForTakeIndexes)
        {
            dictionary.Add(index.Key, new List<Tweet>());
        }

        return dictionary;
    }
    

    private static bool IsPointInPolygon(List<PointF> polygon, PointF testPoint)
    {
        bool result = false;
        int j = polygon.Count - 1;
        for (int i = 0; i < polygon.Count; i++)
        {
            if (polygon[i].Y < testPoint.Y && polygon[j].Y >= testPoint.Y || 
                polygon[j].Y < testPoint.Y && polygon[i].Y >= testPoint.Y)
            {
                if (polygon[i].X + (testPoint.Y - polygon[i].Y) /
                    (polygon[j].Y - polygon[i].Y) *
                    (polygon[j].X - polygon[i].X) < testPoint.X)
                {
                    result = !result;
                }
            }
            j = i;
        }
        return result;
    }
    
    public Dictionary<string, List<Tweet>> SearchStateOfTweet() 
    {
     
        Dictionary<string, List<Tweet>> resultDictionary = CreateDictionaryOfTweetsInPolygons();
     
        EmotionalityOfTweets temp = new EmotionalityOfTweets();
        List<Tweet> tweets = temp.CalculatingOfTheEmotionalParametr();
     
        JsonParser temp1 = new JsonParser();
        Dictionary<string, List<List<List<float>>>> pairs = temp1.ReadJsonFile();
     
        for (int i = 0; i < tweets.Count; i++)
        {
            bool result = false;
                 
            string[] strCoord = new string[2];
     
            strCoord = tweets[i].coordinates.Split(',');
     
            strCoord[0] = strCoord[0].Remove(0, 1);
            strCoord[1] = strCoord[1].Remove(strCoord[1].Length - 1);
     
            PointF point = new PointF();
     
            point.X = float.Parse(strCoord[0], formatter);
            point.Y = float.Parse(strCoord[1], formatter);
     
            foreach (var pair in pairs)
            {
                foreach (var polygon in pair.Value)
                {
                    List<PointF> pointsOfPolygon = new List<PointF>();
     
                    foreach (var coord in polygon)
                    {
                        PointF pointPolygon = new PointF();
     
                        pointPolygon.Y = coord[0];
                        pointPolygon.X = coord[1];
     
                        pointsOfPolygon.Add(pointPolygon);
                    }
     
                    result = IsPointInPolygon(pointsOfPolygon, point);
     
                    if (result)
                    {
                        resultDictionary[pair.Key].Add(tweets[i]);
                        tweets[i].state = pair.Key;
     
                        break;
                    }
                }
     
                if (result)
                {
                    break;
                }
            }
        }
             
        return resultDictionary; 
    }
    
}