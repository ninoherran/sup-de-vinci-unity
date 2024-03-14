using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace.saveManager
{
    public static class SaveManager
    {
        private static string _savePath = Application.persistentDataPath + Path.DirectorySeparatorChar + "sasave.json";
        
        public static void Save(string saveName, int playerScore, int botScore)
        {
            var saves = GetSaves();
            SaveData saveData = new SaveData(saveName, playerScore, botScore);
            saves.Add(saveData);
            
            string json = JsonUtility.ToJson(saveData);
            File.WriteAllText(_savePath, json);
        }

        public static IList<SaveData> GetSaves()
        {
            if (!File.Exists(_savePath))
            {
                File.Create(_savePath);
                return new List<SaveData>();
            }
            string json = File.ReadAllText(_savePath);
            return JsonUtility.FromJson<IList<SaveData>>(json);
        }
    }

    public class SaveData
    {
        public string Name { get; }
        public int PlayerScore { get; }
        public int BotScore { get; }

        public SaveData(string name, int playerScore, int botScore)
        {
            Name = name;
            PlayerScore = playerScore;
            BotScore = botScore;
        }
    }
}