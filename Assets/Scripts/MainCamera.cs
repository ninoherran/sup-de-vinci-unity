using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCamera : MonoBehaviour
{
 public void PlayGame()
 {
  //Button will open SampleScene
  SceneManager.LoadSceneAsync("Scenes/SampleScene");
 }

 public void QuitGame()
 {
  Application.Quit();
 }
}
