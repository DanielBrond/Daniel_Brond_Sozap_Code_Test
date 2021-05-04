using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ManagerGame : MonoBehaviour
{
    private DataManager dataManager;
    private TimerController timerController;
    private VictoryCondition victoryCondition;
    public int level = 0;
    public string time;

    public GameObject  nextLevelButton;
    public float soundVolume;

    private void Awake()
    {

        dataManager = FindObjectOfType<DataManager>();
        dataManager.Load();
        soundVolume = dataManager.data.soundVolume;
        victoryCondition = FindObjectOfType<VictoryCondition>();
        level = victoryCondition.currentLevel;
    }

    void Start()
    {
        timerController = FindObjectOfType<TimerController>();
        LevelBeenPlayed();
        dataManager.Save();
    }

    public void LevelCompleted()
    {
        timerController.EndTimer();
        dataManager.data.newTime = timerController.savedFloatTime;
        time = timerController.currentTime;
        CheckLevel();
        dataManager.Save();
    }

    public void CheckLevel()
    {
        if(level == 1)
        {
            LevelOneSaved();
            EnableNextLevelButton();
        }
        if (level == 2)
        {
            LevelTwoSaved();
            EnableNextLevelButton();
        }
        if (level == 3)
        {
            LevelThreeSaved();
            EnableNextLevelButton();
        }
        if (level == 4)
        {
            LevelFourSaved();
        }

    }

    public void EnableNextLevelButton()
    {
        nextLevelButton.SetActive(true);
    }


    public void LoadNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneManager.sceneCountInBuildSettings > nextSceneIndex)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LevelOneSaved()
    {

        if(dataManager.data.newTime != 0f)
        {
            dataManager.data.currentTime = dataManager.data.newTime;


            if(dataManager.data.currentTime < dataManager.data.level1Time || dataManager.data.level1Time < 0.01f)
            {

                dataManager.data.level1Time = dataManager.data.currentTime;

                dataManager.data.levelOneTime = timerController.currentTime;

              
            }

        }

    }

    public void LevelTwoSaved()
    {
        if (dataManager.data.newTime != 0f)
        {
            dataManager.data.currentTime = dataManager.data.newTime;


            if (dataManager.data.currentTime < dataManager.data.level2Time || dataManager.data.level2Time < 0.01f)
            {

                dataManager.data.level2Time = dataManager.data.currentTime;

                dataManager.data.levelTwoTime = timerController.currentTime;

              
            }

        }

    }

    public void LevelThreeSaved()
    {
        if (dataManager.data.newTime != 0f)
        {
            dataManager.data.currentTime = dataManager.data.newTime;


            if (dataManager.data.currentTime < dataManager.data.level3Time || dataManager.data.level3Time < 0.01f)
            {

                dataManager.data.level3Time = dataManager.data.currentTime;

                dataManager.data.levelOneTime = timerController.currentTime;

               
            }

        }
    }

    public void LevelFourSaved()
    {
        if (dataManager.data.newTime != 0f)
        {
            dataManager.data.currentTime = dataManager.data.newTime;


            if (dataManager.data.currentTime < dataManager.data.level4Time || dataManager.data.level4Time < 0.01f)
            {

                dataManager.data.level4Time = dataManager.data.currentTime;

                dataManager.data.levelFourTime = timerController.currentTime;

               
            }

        }
    }


    public void LevelBeenPlayed()
    {
        if(level == 1)
        {
            dataManager.data.playedLeveOne++;
        }
        if (level == 2)
        {
            dataManager.data.playedLevelTwo++;
        }
        if (level == 3)
        {
            dataManager.data.playedLevelThree++;
        }
        if (level == 4)
        {
            dataManager.data.playedLevelFour++;
        }
    }
}
