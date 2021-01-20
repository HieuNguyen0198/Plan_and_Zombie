using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] float waitToLoad = 4f;
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] GameObject finalLabel;
    [SerializeField] GameObject menuLabel;
    [SerializeField] int endGame;

    int numberOfAttackers = 0;
    bool levelTimerFinished = false;
    bool final = false;
    bool lose = false;
    //
    int phase = 0;

    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
        finalLabel.SetActive(false);
        menuLabel.SetActive(false);
    }

    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    public void AttackerKilled()
    {
        numberOfAttackers--;
        if (levelTimerFinished && lose == false)
        {
            //StopSpawners();
            //StartCoroutine(HandleWinCondition());
            

            StopSpawners();

            if (numberOfAttackers <= endGame)
            {
                StopSpawners();
                HandleWinCondition2();
                //StartCoroutine(HandleWinCondition());
            }
        }
        else if(lose == false)
        {
            if (final)
            {
                FinalWave();
                StartCoroutine(LateCall());              
            }
            else if (phase == 2)
            {
                Phase2();
            }

            if (phase == 3)
            {
                Phase3();
            }
            else
            {
                //FinalWave();
            }
        }
    }

    /*IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        Time.timeScale = 0;
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }*/

    public void HandleWinCondition2()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        //Time.timeScale = 0;
    }

    public void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        Time.timeScale = 0;
    }

    public void LevelTimeFinished()
    {
        levelTimerFinished = true;
        final = false;
        //StopSpawners();
    }

    public void setLose()
    {
        lose = true;
    }

    public void Final()
    {
        final = true;
        //StopSpawners();
    }

    public void Ffinal()
    {
        final = false;
    }

    public void Menu()
    {
        menuLabel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        menuLabel.SetActive(false);
        Time.timeScale = 1;
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnedArray = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in spawnedArray)
        {
            spawner.StopSpawning();
        }
    }

    private void FinalWave()
    {
        finalLabel.SetActive(true);
        AttackerSpawner[] spawnedArray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawnedArray)
        {
            spawner.FinalWave();
        }
    }

    private void Phase2()
    {
        AttackerSpawner[] spawnedArray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawnedArray)
        {
            spawner.phase2();
        }
    }

    private void Phase3()
    {
        AttackerSpawner[] spawnedArray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawnedArray)
        {
            spawner.phase3();
        }
    }

    public void SetPhase2()
    {
        phase = 2;
    }

    public void SetPhase3()
    {
        phase = 3;
    }

    IEnumerator LateCall()
    {
        yield return new WaitForSeconds(4f);
        finalLabel.SetActive(false);
        //Do Function here...
    }
}
