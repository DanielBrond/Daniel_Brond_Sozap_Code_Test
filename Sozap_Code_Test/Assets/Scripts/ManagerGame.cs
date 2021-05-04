using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ManagerGame : MonoBehaviour
{
    private TimerController timerController;
    public int level = 0;
    public string time;

    

    public GameObject  nextLevelButton;

    private DataManager dataManager;
   

 
    void Start()
    {
      
        timerController = FindObjectOfType<TimerController>();
        dataManager = FindObjectOfType<DataManager>();
        dataManager.Load();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LevelCompleted()
    {
        EnableNextLevelButton();
        timerController.EndTimer();
        time = timerController.currentTime;
        LevelOne();
        dataManager.Save();
        
    }

    public void EnableNextLevelButton()
    {
        nextLevelButton.SetActive(true);
    }


    public void LoadNextLevel()
    {
        Utils.currentlevel++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LevelOne()
    {
        dataManager.data.levelOneTime = time;
        
    }

    public void LevelTwo()
    {
        dataManager.data.levelTwoTime = time;
    }

    public void LevelThree()
    {
        dataManager.data.levelOneTime = time;
    }

    public void LevelFour()
    {
        dataManager.data.levelOneTime = time;
    }
}
