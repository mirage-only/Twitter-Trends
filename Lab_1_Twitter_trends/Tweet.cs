namespace Lab_1_Twitter_trends;


using System.Diagnostics.Tracing;



public class Tweet
{
    public string massage { get; set; } //текстовая часть твита
    public string data { get; set; } //дата и время, потом мб сделею dataTime
    public List<string> words { get; set; } //отфильтрованные слова твитта
    public string coordinates { get; set; }
    
    public string state { get; set; }  //штат, к которому относится твит по координатам
    public double emotionalParametr { get; set; } // вычесленный коэффициент настроя твитта
    
}
