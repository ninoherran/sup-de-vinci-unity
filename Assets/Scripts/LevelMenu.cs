using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    // On crée un tableau pour contenir tous les boutons de niveau.
    public Button[] buttons;

    private void Awake()
    {
        int openLevel = PlayerPrefs.GetInt("unlockedLevel" + 1);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        for (int i = 0; i < openLevel; i++)
        {
            buttons[i].interactable = true;
        }
    }

    public int levelId;
    public string levelName = "Level";
    //Créer une nouvelle fonction 
    public void OpenLevel()
    {
        SceneManager.LoadScene(levelName + levelId);
    }