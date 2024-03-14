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
        // Stockage du nombre de niveaux terminés à l'aide de la méthode PlayerPrefs
        int openLevel = PlayerPrefs.GetInt("unlockedLevel");

        // Défiition des boucles for pour gérer les propriétés intéractives des boutons
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        for (int i = 0; i < openLevel; i++)
        {
            buttons[i].interactable = true;
        }
    }

    //Créer une nouvelle fonction 
    public void OpenLevel(int levelId)
    {
        string levelName = "Level" + levelId;
        SceneManager.LoadScene(levelName);
    }
}
