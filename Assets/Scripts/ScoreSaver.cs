using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class ScoreSaver
{
    //Score format
    //XXX - XX.XX

    public static void SaveTime(string name, float time)
    {
        if(!File.Exists("scores.txt"))
        {//File doesn't exist, create it before continuing
            File.Create("scores.txt");
        }

        string[] ScoreLines = File.ReadAllLines("scores.txt");

        List<string> ScoreList = new List<string>();
        ScoreList.AddRange(ScoreLines);
        ScoreList.Add(name + " "  + time);

        if (ScoreList.Count > 0)
        {
            ScoreList.OrderBy(score => score.Split(' ')[1]);
            var SortedList = from s in ScoreList orderby s.Split(' ')[1] select s;
            ScoreList = SortedList.ToList();
        }

        if (ScoreList.Count > 10)
        {
            ScoreList.RemoveRange(10, ScoreList.Count - 10);
        }

        using (StreamWriter output = new StreamWriter("scores.txt"))
        {
            foreach (string score in ScoreList)
            {
                output.WriteLine(score);
            }
        }
    }

    public static string[] GetScores()
    {
        return File.ReadAllLines("scores.txt");
    }
}
