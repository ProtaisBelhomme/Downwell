using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public Text pauseTitle;
    public Text resumeText;
    public Text retryText;
    public Text statsText;
    public Text optionsText;
    public Text quitText;
    public Text progressText;
    public Text progressValueText;
    public Slider progressBar;

    private int currentProgress = 32564;
    private int maxProgress = 35000;
    // Start is called before the first frame update
    void Start()
    {
        // Initialisation des textes du menu
        pauseTitle.text = "PAUSE";
        resumeText.text = "REPRENDRE";
        retryText.text = "REESSAYER";
        statsText.text = "STATS";
        optionsText.text = "OPTIONS";
        quitText.text = "QUITTER";
        progressText.text = "PROGRESS";
        UpdateProgress();
    }

    // Update is called once per frame
    void Update()
    {
        // Activer/Désactiver le menu pause avec la touche Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenuUI.activeSelf)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // Arrêter le temps du jeu
    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // Reprendre le temps du jeu
    }

    void UpdateProgress()
    {
        progressValueText.text = currentProgress + " / " + maxProgress;
        progressBar.maxValue = maxProgress;
        progressBar.value = currentProgress;
    }
}

