using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryCondition : MonoBehaviour
{
    private BoxMovement[] boxes;
    private ManagerGame gameManager;

    public int currentLevel;
    public int boxHolders;
    public int occupied;

    public GameObject confetti;
    private AudioSource audioSource;
    public AudioClip boxEnterSound;
    public AudioClip boxExitSound;
    public AudioClip victorySound;


    public void Awake()
    {
       
        
    }
    private void Start()
    {
        gameManager = FindObjectOfType<ManagerGame>();
        audioSource = GetComponent<AudioSource>();
        boxes = FindObjectsOfType<BoxMovement>();
        boxHolders = boxes.Length;
       
    }

    public void CheckForVictory()
    {
        if (currentLevel == 1)
        {
            if(boxHolders == occupied)
            {
                gameManager.LevelCompleted();
                PlaySoundEffects(2);
                confetti.SetActive(true);
            }
        }

        if (currentLevel == 2)
        {
            if (boxHolders == occupied)
            {
                gameManager.LevelCompleted();
                PlaySoundEffects(2);
                confetti.SetActive(true);
            }
        }

        if (currentLevel == 3)
        {
            if (boxHolders == occupied)
            {
                gameManager.LevelCompleted();
                PlaySoundEffects(2);
                confetti.SetActive(true);
            }
        }
        if (currentLevel == 4)
        {
            if (boxHolders == occupied)
            {
                gameManager.LevelCompleted();
                PlaySoundEffects(2);
                confetti.SetActive(true);
            }
        }
    }

    public void AddBox()
    {
        occupied++;
        CheckForVictory();
        PlaySoundEffects(0);
    }

    public void RemoveBox()
    {
        occupied--;
        CheckForVictory();
        PlaySoundEffects(1);
    }

    public void PlaySoundEffects(int stage)
    {
        audioSource.volume = gameManager.soundVolume;

        if (stage == 0)
        {
           
            audioSource.PlayOneShot(boxEnterSound, 1f);
        }
        if(stage == 1)
        {
            audioSource.PlayOneShot(boxExitSound, 1f);
        }

        if(stage == 2)
        {
            audioSource.PlayOneShot(victorySound, 1f);
        }
        
    }
}
