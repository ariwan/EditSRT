public class Program
{
    static void Main(string[] args)
    {
        var srtPath = "C:\\Users\\Arivan\\Downloads\\SUBDL.com__the.lord.of.the.rings.the.return.of.the.king58648\\deze.srt";
        var fileContent = File.ReadAllLines(srtPath); // Hiermee readen we alle lines in een string[]
        if (fileContent.Length <= 0) // indien de lengte van string[] <= 0 is, dan zeggen we nevermind bruh. 
            return;
        string test = "hoi";

        var segments = new List<string[]>(); // This is the LIST that contains string[]. It must be a list, as each string[] does not have to be the same size. 
        var tempArray = new List<string>(); // This list is to to create individual segments. 


        foreach(var entree in fileContent)
        {
            if (entree == "")
            {
                segments.Add(tempArray.ToArray());
                tempArray.Clear();
            }
            else
            {
                tempArray.Add(entree);
            }

        }

        foreach(var entree in segments)
        {
            if (entree.Length == 4)
            { entree[2] = entree[2] + "\n" + entree[3]; }
                
        }

        var index = new string[segments.Count];
        var startTime = new string[segments.Count];
        var startTimeMs = new string[segments.Count];
        var EndTime = new string[segments.Count];
        var EndTimeMs = new string[segments.Count];
        var subs = new string[segments.Count];


        for (int i = 0; i < segments.Count; i++)
        {
            index[i] = segments[i][0];
            startTime[i] = segments[i][1].Split(" --> ").First().Split(",").First();
            startTimeMs[i] = segments[i][1].Split(" --> ").First().Split(",").Last();
            EndTime[i] = segments[i][1].Split(" --> ").Last().Split(",").First();
            EndTimeMs[i] = segments[i][1].Split(" --> ").Last().Split(",").Last();
            subs[i] = segments[i][2];
        }


        TimeSpan TimeToAdd = new TimeSpan(0, 2, 54);


        for(int i = 0; i < startTime.Length; i++)
        {
            startTime[i] = (TimeSpan.Parse(startTime[i]) + TimeToAdd).ToString();
            EndTime[i] = (TimeSpan.Parse(EndTime[i]) + TimeToAdd).ToString();

        }

        string[] newFileContent = new string[fileContent.Length];

        for(int i = 0;i < segments.Count; i++)
        {
            newFileContent[4 * i] = index[i];
            newFileContent[4 * i +1] = startTime[i] + "," + startTimeMs[i]+ " --> " + EndTime[i] + "," + EndTimeMs[i];
            newFileContent[4 * i + 2] = subs[i]; 
            //newFileContent[4 * i + 3] = "\n"; 
        }

        File.WriteAllLines("C:\\Users\\Arivan\\Downloads\\srtding\\IsDezeNice.srt", newFileContent);

    }

   
    
}