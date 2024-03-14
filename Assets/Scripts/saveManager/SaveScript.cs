using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.saveManager
{
    public class SaveScript : MonoBehaviour
    {
        void Start()
        {
            var input = gameObject.GetComponent<InputField>(); 
            input.onEndEdit.AddListener(SaveGame);
        }

        private void SaveGame(string saveName)
        {
            SaveManager.Save(saveName, ScoreComputer.PlayerScore, ScoreComputer.BotScore);
        }
    }
}