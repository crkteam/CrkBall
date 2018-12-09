using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Csv
{
    private TextAsset _textAsset;

    private List<string[]> data;

    public Csv(string csv)
    {
        _textAsset = Resources.Load<TextAsset>("Data/" + csv);
        data = new List<string[]>();
        init();
    }

    private void init()
    {
        foreach (var value in _textAsset.text.Split('\n'))
        {
            string[] buffer = value.Split(',');
            data.Add(buffer);
        }
    }

    public string get(int row, int column)
    {
        return data[row][column];
    }
}