using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public int levelId;
    public string levelName = "Level";
    //Créer une nouvelle fonction 
    public void OpenLevel()
    {
        SceneManager.LoadScene(levelName + levelId);
    }
}
