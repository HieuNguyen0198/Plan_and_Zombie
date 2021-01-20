using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] float waitToLoad = 4f;
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] GameObject finalLabel;

    int numberOfAttackers = 0;
    bool levelTimerFinished = false;
    bool final = false;

    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
        finalLabel.SetActive(false);
    }

    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    public void AttackerKilled()
    {
        numberOfAttackers--;
        if(levelTimerFinished)
        {
            //StopSpawners();
            //StartCoroutine(HandleWinCondition());
            if(!final)
            {
                FinalWave();
                StartCoroutine(LateCall());
                final = true;
            }

            if (numberOfAttackers >= 10)
            {
                StopSpawners();
            }
            if (numberOfAttackers <= 2 && final)
            {
                HandleWinCondition2();
                //StartCoroutine(HandleWinCondition());
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
        //StopSpawners();
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

    IEnumerator LateCall()
    {
        yield return new WaitForSeconds(3f);
        finalLabel.SetActive(false);
        //Do Function here...
    }
}
