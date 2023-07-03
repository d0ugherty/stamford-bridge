using UnityEngine;

public class Exit : MonoBehaviour
{
    // Call this method when the Quit button is clicked
    public void QuitGame()
    {
        #if UNITY_EDITOR
        // If in Unity Editor, stop play mode
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        // Otherwise, quit the application
        Application.Quit();
        #endif
    }
}