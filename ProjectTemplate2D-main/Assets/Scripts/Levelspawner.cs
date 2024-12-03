using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public GameObject[] levelParts; // Tableau contenant vos 3 prefabs
    public Transform[] spawnPoints; // Points où les parties vont spawn

    void Start()
    {
        SpawnLevelParts();
    }

    void SpawnLevelParts()
    {
        // Mélanger les parties de niveau
        List<GameObject> shuffledParts = new List<GameObject>(levelParts);
        ShuffleList(shuffledParts);

        // S'assurer qu'on a assez de points de spawn
        if (spawnPoints.Length < shuffledParts.Count)
        {
            Debug.LogError("Pas assez de points de spawn pour les parties de niveau !");
            return;
        }

        // Spawner chaque partie à un point de spawn
        for (int i = 0; i < shuffledParts.Count; i++)
        {
            Instantiate(shuffledParts[i], spawnPoints[i].position, Quaternion.identity);
        }
    }

    void ShuffleList(List<GameObject> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = Random.Range(0, list.Count);
            GameObject temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}