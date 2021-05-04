using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private GridMovement gridMovement;
    private BoxMovement[] boxMovement;
    private AudioSource audioSource;
    private ManagerGame gameManager;
    private DataManager dataManager;
    public AudioClip[] audioClips;

    public int currentLevel;

    public float soundVolume;
    void Start()
    {
        gridMovement = FindObjectOfType<GridMovement>();
        boxMovement = FindObjectsOfType<BoxMovement>();
        audioSource = GetComponent<AudioSource>();
        gameManager = FindObjectOfType<ManagerGame>();

        audioSource.volume = gameManager.soundVolume;
        AdjustVolume();
        LevelMusic();

    }

    public void LevelMusic()
    {
        if(gameManager.level == currentLevel)
        {
            audioSource.clip = audioClips[0];
            audioSource.Play();
        }
        if (gameManager.level == 2)
        {
            audioSource.clip = audioClips[1];
            audioSource.Play();
        }
        if (gameManager.level == 3)
        {
            audioSource.clip = audioClips[0];
            audioSource.Play();
        }
        if (gameManager.level == 4)
        {
            audioSource.clip = audioClips[1];
            audioSource.Play();
        }
    }

    public void AdjustVolume()
    {

        gridMovement.audioSource.volume = audioSource.volume;

        foreach (var box in boxMovement)
        {
            box.audioSource.volume = audioSource.volume;
        }

        
    }

    
    
}
