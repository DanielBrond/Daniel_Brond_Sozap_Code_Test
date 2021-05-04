using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Dropdown dropDown;
    private DataManager dataManager;
    public string text;

    public Button playButton;

    // Start is called before the first frame update
    void Start()
    {
        dataManager = FindObjectOfType<DataManager>();
        

        dataManager.Load();

        dropDown.options[0].text = "Level 1: " + dataManager.data.levelOneTime;
        dropDown.options[1].text = "Level 2: " + dataManager.data.levelOneTime;
        dropDown.options[2].text = "Level 3: " + dataManager.data.levelOneTime;
        dropDown.options[3].text = "Level 4: " + dataManager.data.levelOneTime;





    }

    private void Update()
    {
       
    }

    public void PlayLevel()
    {
        SceneManager.LoadScene(1);
    }




}
