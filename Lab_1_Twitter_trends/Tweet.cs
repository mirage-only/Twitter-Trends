namespace Lab_1_Twitter_trends;


using System.Diagnostics.Tracing;



public class Tweet
{
    public string massage { get; set; }
    public string data { get; set; }
    public List<string> words { get; set; }
    public string coordinates { get; set; }
    
    public string state { get; set; }
    
    public double? emotionalParametr { get; set; }
    
}
