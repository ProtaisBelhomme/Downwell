using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exemple_SceneManagement : MonoBehaviour
{
    [Scene]
    public string sceneToLoad;

    public void LoadScene() => LoadScene(sceneToLoad);
    public void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
    public void LoadSceneIn(float time)
    {
        if(time <= 0)
        {
            LoadScene();
            return;
        }

        CancelInvoke("LoadScene");
        Invoke("LoadScene", time);
    }

    [Button]
    public void QuitGame()
    {
#if UNITY_EDITOR
        Debug.LogWarning("Quit the game");
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
