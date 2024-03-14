using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DefaultNamespace.saveManager
{
    public class SaveScript : MonoBehaviour
    {
        [SerializeField] private TMP_InputField inputField;

        public void SaveGame()
        {
            string saveName = inputField.text;
            SaveManager.Save(saveName, ScoreComputer.PlayerScore, ScoreComputer.BotScore);
            SceneManager.LoadScene("Main Menu");
        }
    }
}