using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class LevelManager : MonoBehaviour
    {
        void Update()
        {
            if (ScoreComputer.PlayerScore == 1)
                OpenLevel(2);
            else if (ScoreComputer.PlayerScore == 2) OpenLevel(3);
        }
        
        public void OpenLevel(int levelId)
        {
            
            string levelName = "Level " + levelId;
            var currentScene = SceneManager.GetActiveScene().name;

            if (levelName != currentScene)
            {
                Debug.Log($"{levelName} loaded.");
      
                SceneManager.LoadScene(levelName); 
            }
        }
    }
}