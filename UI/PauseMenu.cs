using UnityEngine;

public class PauseMenu : MonoBehaviour 
{
    public static bool GamePaused { get; private set; }

    void OnEnable() 
    {
        GamePaused = true;
    }

    void OnDisable()
    {
        GamePaused = false;
    }

}
    
