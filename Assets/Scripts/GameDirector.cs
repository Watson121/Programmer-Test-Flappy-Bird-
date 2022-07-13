using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// The main game director, that is responible for controlling the more global aspects of the game.
/// </summary>

public class GameDirector : MonoBehaviour
{

    #region Properties

    public static int HighScore { 
        get { return highScore; }
    }

    public int Score { 
        get { return score; }
        set 
        { 
            score = value;
            scoreText.text = "Score: " + score;
        }
    }

    #endregion

    // High Score that stays throughout the game
    private static int highScore;

    // Score that is reset once the game is restarted
    private int score;

    [Header("Controllers")]
    public CharacterController player;
    public PipeGenerator pipes;

    [Header("HUD")]
    public GameObject HUD;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI scoreText;

    [Header("Game Over Screen")]
    public GameObject gameOverScreen;

    [Header("Main Menu")]
    public GameObject mainMenu;

    [Header("Pause Menu")]
    public GameObject pauseMenu;

    private void Start()
    {
        MainMenu();
        Time.timeScale = 0.0f;
        GettingSaveData();
    }

    // Getting the Save Data when a new game is started
    private void GettingSaveData()
    {
        highScore = PlayerPrefs.GetInt("High Score");
        highScoreText.text = "High Score: " + highScore;
    }

    // Updating the high score
    private void UpdateHighScore()
    {
        if(highScore < score)
        {
            highScore = score;
        }

        highScoreText.text = "High Score: " + highScore;
    }

    
    // Game Over 
    public void EndGame()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0.0f;
        UpdateHighScore();
    }

    // Resesting the game, so that it can be restarted
    public void ResetGame()
    {
        Score = 0;
        Time.timeScale = 1.0f;
        player.ResetPlayer();
        pipes.ResetPipes();
        gameOverScreen.SetActive(false);
        mainMenu.SetActive(false);
        pauseMenu.SetActive(false);
        HUD.SetActive(true);
    }

    // Opening the main menu
    public void MainMenu()
    {
        mainMenu.SetActive(true);
        HUD.SetActive(false);
        gameOverScreen.SetActive(false);
        pauseMenu.SetActive(false);
    }

    // Opening the pause
    public void PauseMenu()
    {
        Time.timeScale = 0.0f;
        pauseMenu.SetActive(true);
        HUD.SetActive(false);
        gameOverScreen.SetActive(false);
        mainMenu.SetActive(false);
    }

    // Resuming the game from the pause menu
    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        HUD.SetActive(true);
        gameOverScreen.SetActive(false);
        mainMenu.SetActive(false);
    }

    // Exiting the app
    public void ExitGame()
    {
        PlayerPrefs.SetInt("High Score", highScore);
        Application.Quit();
    }
    

}
