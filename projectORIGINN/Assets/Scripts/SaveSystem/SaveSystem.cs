using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Originn.Game.SaveSystem
{
    public class SaveSystem : MonoBehaviour
    {
        public static Dictionary<string, string> data1 {get; private set; } = new();
        public static Dictionary<string, string> data2 {get; private set; } = new();
        public static Dictionary<string, string> data3 {get; private set; } = new();
        public static Dictionary<string, string> currentData {get; private set; } = data1;
        public static int currentSave = 1;

        public static void SaveTheGame(string path)
        {
            Debug.Log("Saving...");

            string json = JsonUtility.ToJson(currentData);
            File.WriteAllText(path, json);
        }   

        public static void LoadTheGame(string path)
        {
            Debug.Log("Loading...");
            
            string json = File.ReadAllText(path);

            currentData = JsonUtility.FromJson<Dictionary<string, string>>(json) ?? new();
        }   
    }
}
