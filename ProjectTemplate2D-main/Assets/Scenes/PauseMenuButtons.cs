using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuButtons : MonoBehaviour
{
    [Scene, SerializeField]
    private string SceneToLoad;

    public void Reprendre()
    {
        // D�charge la sc�ne du menu pause et reprend le jeu
        Time.timeScale = 1f; // Reprendre le jeu
    }

    public void RestartGame()
    {
        // Recharge la sc�ne de jeu principal
        Time.timeScale = 1f; // Assurez-vous que le jeu reprenne normalement
        SceneManager.LoadScene(SceneToLoad); // Remplacez "GameScene" par le nom de votre sc�ne de jeu
    }

    public void QuitGame()
    {
        // Quitte le jeu (fonctionne uniquement dans une build, pas dans l'�diteur)
        Application.Quit();
    }
}

