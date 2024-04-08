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

        JsonParse temp = new JsonParse();

        Dictionary<string, List<List<List<float>>>> dictionaryForTakeIndexes = temp.ReadJsonFile();

        foreach (var index in dictionaryForTakeIndexes)
        {
            dictionary.Add(index.Key, null!);
        }

        return dictionary;
    }

    /*public void ConvertPolygonsIntoListsOfPointF() //конвертирую просто листы флотов в поинт ф
    {
        JsonParse temp = new JsonParse();
        Dictionary<string, List<List<List<float>>>> pairs = temp.ReadJsonFile();

        Dictionary<string, List<List<PointF>>> resultDict = new Dictionary<string, List<List<PointF>>>();

        /*for (int i = 0; i < pairs.Count; i++)
        {
                resultDict.Add(, null!);

        }#1#

        /*foreach (var pair in pairs)
        {
                resultDict.Add(pair.Key, null!);

                foreach (var polygonsOfState in pair.Value)
                {
                        foreach (var coord in polygonsOfState)
                        {
                                PointF point = new PointF();

                                point.X = coord[0];
                                point.Y = coord[1];

                                resultDict[pair.Key].Add(point);
                        }
                }
        }#1#
    }*/

    

    private bool IsPointInPolygon(List<PointF> polygon, PointF testPoint) //проверка точки твита на вхождение в полигон штата
    {
        bool result = false;
        int j = polygon.Count - 1;
        for (int i = 0; i < polygon.Count; i++)
        {
            if (polygon[i].Y < testPoint.Y && polygon[j].Y >= testPoint.Y ||
                polygon[j].Y < testPoint.Y && polygon[i].Y >= testPoint.Y)
            {
                if (polygon[i].X + (testPoint.Y - polygon[i].Y) / (polygon[j].Y - polygon[i].Y) *
                    (polygon[j].X - polygon[i].X) < testPoint.X)
                {
                    result = !result;
                }
            }

            j = i;
        }

        return result;
    }
    
    public Dictionary<string, List<Tweet>> SearchStateOfTweet() //коннект штатов и твитов
    {
     
        Dictionary<string, List<Tweet>> resultDictionary = CreateDictionaryOfTweetsInPolygons();
     
        AnalazingOfEmotionalityOfTweets temp = new AnalazingOfEmotionalityOfTweets();
        List<Tweet> tweets = temp.CalculatingOfTheEmotionalParametr();
     
        JsonParse temp1 = new JsonParse();
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
     
                        pointPolygon.X = coord[0];
                        pointPolygon.Y = coord[1];
     
                        pointsOfPolygon.Add(pointPolygon);
                    }
     
                    result = IsPointInPolygon(pointsOfPolygon, point);
     
                    if (result)
                    {
                        resultDictionary[pair.Key].Add(tweets[i]);
     
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