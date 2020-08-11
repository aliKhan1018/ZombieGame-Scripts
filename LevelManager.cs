using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadLevel(string levelName){
       SceneManager.LoadSceneAsync(levelName);
    }

    public void ExitGame()
    {
        Application.Quit();
        
    }
}
