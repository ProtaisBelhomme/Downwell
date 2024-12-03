using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionEndLevel : MonoBehaviour
{

    [Scene, SerializeField]
    private string SceneToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            RestartGame();
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Assurez-vous que le jeu reprenne normalement
        SceneManager.LoadScene(SceneToLoad); // Remplacez "GameScene" par le nom de votre scène de jeu
    }
}
