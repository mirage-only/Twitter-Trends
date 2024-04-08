using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;


namespace Lab_1_Twitter_trends;

public class MapOfStates
{
    public void DrawningMap()
    {
        JsonParse jsonParse = new JsonParse();
        Dictionary<string, List<List<List<float>>>> allPolygons = jsonParse.ReadJsonFile();
        
        Bitmap bitmap = new Bitmap(2000, 1000);
        using (Graphics graphics = Graphics.FromImage(bitmap))
        {


            Pen pen = new Pen(Color.Black, 3);
            graphics.Clear(Color.Azure);
            
            
            foreach (var pair in allPolygons)
            {
                foreach (var polygon in pair.Value)
                {
                    List<PointF> pointsInPolygon = new List<PointF>();

                    foreach (var coordPoint in polygon)
                    {
                        PointF point = new PointF();
                        
                        if (pair.Key == "HI")
                        {
                            point.X = coordPoint[0]*30 + 5600; 
                            point.Y = -coordPoint[1]*30 + 1300; 
                        }
            
                        else
                        {
                            if (pair.Key == "AK")
                            {
                                point.X = coordPoint[0]*10 + 2100; 
                                point.Y = -coordPoint[1]*10 + 1300; 
                            }
                            else
                            {
                                point.X = coordPoint[0]*20 + 3000; 
                                point.Y = -coordPoint[1]*20 + 1200;   
                            }
                            
                        }

                        pointsInPolygon.Add(point);
                    }
                    
                    graphics.DrawPolygon(pen, pointsInPolygon.ToArray());
                }
            }
        }
        
        bitmap.Save("D:\\University\\OOP technology\\Lab_1_Twitter_trends\\Lab_1_Twitter_trends\\map.png", ImageFormat.Png);
    }
}