using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using NaughtyAttributes;

public class PauseMenu : MonoBehaviour
{
    [Scene, SerializeField]
    private string SceneToLoad;

    private bool isPaused = false;
    public GameObject pausePanel;

    private void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TooglePause();
        }
    }


    public void SetPause(bool pIsPause)
    {
        isPaused = pIsPause;

        Time.timeScale = isPaused ? 0 : 1; // Met le jeu en pause
        pausePanel.SetActive(isPaused);
    }

    public void TooglePause()
    {
        isPaused = !isPaused;

        Time.timeScale = isPaused ? 0 : 1; // Met le jeu en pause
        pausePanel.SetActive(isPaused);
    }

    public void RestartGame()
    {
        // Recharge la scène de jeu principal
        Time.timeScale = 1f; // Assurez-vous que le jeu reprenne normalement
        SceneManager.LoadScene(SceneToLoad); // Remplacez "GameScene" par le nom de votre scène de jeu
    }

    public void QuitGame()
    {
        // Quitte le jeu (fonctionne uniquement dans une build, pas dans l'éditeur)
        Application.Quit();
    }
}

