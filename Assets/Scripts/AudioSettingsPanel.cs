using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioSettingsPanel : MonoBehaviour
{
    [SerializeField] private GameObject audioMenu;
    public void Pause()
    {
        audioMenu.SetActive(true);
        Time.timeScale = 0; //The game stopes moving
    }
    
}