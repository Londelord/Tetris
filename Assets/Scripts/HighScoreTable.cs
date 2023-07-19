using System;
using System.IO;
using UnityEngine;

public class HighScoreTable : MonoBehaviour
{
    string[] tableOfRecords = File.ReadAllLines(@"C:\Users\Londelord\Tetris 2.0\Assets\Scripts\High Score Table.txt");

    public void CheckRecord()
    {
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
       
        for (int i = 0; i < tableOfRecords.Length; i++)
        {
            tableOfRecords[i] = records[i].ToString();
        }

        File.WriteAllLines(@"C:\Users\Londelord\Tetris 2.0\Assets\Scripts\High Score Table.txt", tableOfRecords);
    }
}
