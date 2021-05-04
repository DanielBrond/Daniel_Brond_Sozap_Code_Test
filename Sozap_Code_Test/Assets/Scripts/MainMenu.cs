using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private AudioSource audioSource;
    private DataManager dataManager;
    public Dropdown dropDown;
    public Slider volumeSlider;
    public Text amountPlayedText;
    public Text levelText;
    public Text bestTimeText;

    private int levelSelected;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        dataManager = FindObjectOfType<DataManager>();
        dataManager.Load();
        SetSavedTime();
        ShowLevelStats();

        volumeSlider.value = dataManager.data.soundVolume;

        dropDown.onValueChanged.AddListener(delegate
        {
            DropDownValueChanged(dropDown);
        });

        volumeSlider.onValueChanged.AddListener(delegate
        {
            SoundVolumeChanged(volumeSlider);
        });


    }

    public void SoundVolumeChanged(Slider sender)
    {
        dataManager.data.soundVolume = sender.value;
        audioSource.volume = sender.value;
        
    }
    public void DropDownValueChanged(Dropdown sender)
    {
        Debug.Log("Level selected:" + sender.value);
        levelSelected = sender.value;
        ShowLevelStats();
    }

    public void SetSavedTime()
    {
        
        
    }

    public void ShowLevelStats()
    {
        if (levelSelected == 0)
        {
            levelText.text = "Level: 1";

            amountPlayedText.text = dataManager.data.playedLeveOne.ToString();

            bestTimeText.text = dataManager.data.levelOneTime;
        }
        if (levelSelected == 1)
        {
            levelText.text = "Level: 2";
            amountPlayedText.text = dataManager.data.playedLevelTwo.ToString();
            bestTimeText.text = dataManager.data.levelTwoTime;
        }
        if (levelSelected == 2)
        {
            levelText.text = "Level: 3";
            amountPlayedText.text = dataManager.data.playedLevelThree.ToString();
            bestTimeText.text = dataManager.data.levelThreeTime;
        }
        if (levelSelected == 3)
        {
            levelText.text = "Level: 4";
            amountPlayedText.text = dataManager.data.playedLevelFour.ToString();
            bestTimeText.text = dataManager.data.levelFourTime;
        }
    }

    public void PlayLevel()
    {
        dataManager.Save();
        if (levelSelected == 0)
        {
            SceneManager.LoadScene(1);
        }
        if (levelSelected == 1)
        {
            SceneManager.LoadScene(2);
        }
        if (levelSelected == 2)
        {
            SceneManager.LoadScene(3);
        }
        if (levelSelected == 3)
        {
            SceneManager.LoadScene(4);
        }

        
    }




}
