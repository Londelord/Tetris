using System;
using System.IO;
using UnityEngine;

public class HighScoreTable : MonoBehaviour
{
    string[] tableOfRecords;   

    string path;
    string fileName = "HighScoreTable.txt";

    public void CheckRecord()
    {
        path = $"{Application.streamingAssetsPath}/{fileName}";

        tableOfRecords = File.ReadAllText(path).Split();

        int[] records = new int[tableOfRecords.Length];
        for (int i = 0; i < tableOfRecords.Length; i++)
        {

            records[i] = int.Parse(tableOfRecords[i]);
        }

        foreach(int i in records)
        {
            if (Data.score >= i)
            {
                SetRecord(records);
                return;
            }
        }
    }

    private void SetRecord(int[] records)
    {
        records[^1] = Data.score;
        Array.Sort(records);
        Array.Reverse(records);
        string newRecords = "";

        for (int i = 0; i < tableOfRecords.Length - 1; i++)
        {
            tableOfRecords[i] = records[i].ToString();
            newRecords += tableOfRecords[i] + " ";
        }

        newRecords += tableOfRecords[^1].ToString();

        File.WriteAllText(path, newRecords);
    }
}
