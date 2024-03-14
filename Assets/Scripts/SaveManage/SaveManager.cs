using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace SaveManage
{
    public static class SaveManager
    {
        private static readonly string SavePath = Application.persistentDataPath + "/savefile.json";

        public static void Save(string saveName, int playerScore, int botScore)
        {
            var currentSave = new SaveData(saveName, playerScore, botScore);

            var saves = RetrieveSaves();
            saves.Add(currentSave);

            var json = JsonUtility.ToJson(saves);
            File.WriteAllText(SavePath, json);
        }

        public static SaveData Load(string saveName)
            => RetrieveSaves().First(save => save.Name == saveName);

        private static IList<SaveData> RetrieveSaves()
        {
            string json = File.ReadAllText(SavePath);
            return JsonUtility.FromJson<IList<SaveData>>(json) ?? new List<SaveData>();
        }
    }

    public class SaveData
    {
        public string Name { get; set; }
        public int PlayerScore { get; set; }
        public int BotScore { get; set; }

        public SaveData(string name, int playerScore, int botScore)
        {
            Name = name;
            PlayerScore = playerScore;
            BotScore = botScore;
        }
    }
}