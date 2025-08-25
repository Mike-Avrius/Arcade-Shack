using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SceneTransition : MonoBehaviour
{
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void Update()
    {
        
#if UNITY_EDITOR
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 screenPos = Mouse.current.position.ReadValue();
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        }
#else
        foreach (var touch in Touchscreen.current.touches)
        {
            if (touch.phase.ReadValue() == UnityEngine.InputSystem.TouchPhase.Began)
            {
                Vector2 screenPos = touch.position.ReadValue();
                Vector2 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
                
            }
        }
#endif
    }
    
    public void LoadPlayZone()
    {
      SceneManager.LoadScene("Play Zone");
    }


    public void LoadRoom()
    {
        SceneManager.LoadScene("Room");
    }
    
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
