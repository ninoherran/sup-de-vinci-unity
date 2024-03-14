using DefaultNamespace;
using DefaultNamespace.saveManager;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResumeButtonController : MonoBehaviour
{
    private SaveData _saveData;
    [SerializeField] private TextMeshProUGUI saveNameText;
    
    public void LoadSave(SaveData saveData)
    {
        _saveData = saveData;
        saveNameText.text = saveData.Name;
    }
    
    public void ResumeGame()
    {
        SceneManager.LoadScene("Level 1");
        ScoreComputer.PlayerScore = _saveData.PlayerScore;
        ScoreComputer.BotScore = _saveData.BotScore;
    }
}
