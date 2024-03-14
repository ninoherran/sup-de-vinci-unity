using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    // On cr�e un tableau pour contenir tous les boutons de niveau.
    public Button[] buttons;

    private void Awake()
    {
        // Stockage du nombre de niveaux termin�s � l'aide de la m�thode PlayerPrefs
        int openLevel = PlayerPrefs.GetInt("unlockedLevel");

        // D�fiition des boucles for pour g�rer les propri�t�s int�ractives des boutons
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        for (int i = 0; i < openLevel; i++)
        {
            buttons[i].interactable = true;
        }
    }

    //Cr�er une nouvelle fonction 
    public void OpenLevel(int levelId)
    {
        string levelName = "Level" + levelId;
        SceneManager.LoadScene(levelName);
    }
}
