using UnityEngine;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;

public struct PlayerStat
{
    public int life;
    public int attack;
    public int defense;
}

// Exemple of how to save and load data using PlayerPrefs.
public class Exemple_Save : MonoBehaviour
{
    public int bestScore = 0;
    [Range(0f, 1f)]
    public float masterVolume = 1f;
    public string playerName = "Avatar";
    public PlayerStat playerStat;

    [Button]
    public void SaveData(int score, float volume, string name)
    {
        // Save data to PlayerPrefs
        PlayerPrefs.SetInt("HighScore", score);
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.SetString("PlayerName", name);

        //Save playerStat by converting it to a JSON string
        string playerStatJson = JsonUtility.ToJson(playerStat);
        PlayerPrefs.SetString("PlayerStat", playerStatJson);

        // Save the data
        PlayerPrefs.Save();

        // Display saved data
        Debug.Log("Data saved successfully!");
    }

    [Button]
    public void LoadData()
    {
        // Load data from PlayerPrefs
        bestScore = PlayerPrefs.GetInt("HighScore");
        masterVolume = PlayerPrefs.GetFloat("Volume");
        playerName = PlayerPrefs.GetString("PlayerName");

        // Load playerStat by converting it from a JSON string
        string playerStatJson = PlayerPrefs.GetString("PlayerStat");
        playerStat = JsonUtility.FromJson<PlayerStat>(playerStatJson);

        // Display loaded data
        Debug.Log("High Score: " + bestScore);
        Debug.Log("Master Volume: " + masterVolume);
        Debug.Log("Player Name: " + playerName);
    }
}
