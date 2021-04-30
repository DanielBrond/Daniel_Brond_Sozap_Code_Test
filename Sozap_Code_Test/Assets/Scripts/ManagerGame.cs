using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ManagerGame : MonoBehaviour
{
    public int level = 0;
    public float time;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void LoadNextLevel()
    {
        Utils.currentlevel++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LevelOne()
    {

    }

    public void LevelTwo()
    {

    }

    public void LevelThree()
    {

    }

    public void LevelFour()
    {

    }
}
