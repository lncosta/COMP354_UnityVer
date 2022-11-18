using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ParsingTool {
    [MenuItem("Assets/Generate Books", false, 5)]
    public static void ParseAndGenerate() {
        string filePath = EditorUtility.OpenFilePanel("Select Input File", "Assets/", "txt, csv");

        if(filePath == null || filePath == string.Empty) { return; }
        if(!System.IO.File.Exists(filePath)) {
            Debug.LogWarning($"No file exists at target location: '{filePath}'");
            return;
        }

        Debug.Log("\nParsing: " + filePath);
        string output = string.Empty;

        IEnumerable<string> textData = System.IO.File.ReadLines(filePath);
        foreach (var line in textData) {
            string[] values = line.Split(',');
            Book.Create(values[0], values[1], values[2], float.Parse(values[3]), 0);
            output += $"\n - Book ({line})";
        }

        Debug.Log("Success.\nCreated file(s):" + output);

        // :)
    }
}