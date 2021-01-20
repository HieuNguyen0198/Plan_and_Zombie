using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Our level timer in SECONDS")]
    [SerializeField] float levelTime= 10;
    bool triggeredLevelFinished = false;

    private void Update()
    {
        if (triggeredLevelFinished) { return; } 
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);
        bool timerPhase2 = (Time.timeSinceLevelLoad >= levelTime - levelTime);
        bool timerPhase3 = (Time.timeSinceLevelLoad >= levelTime/2);

        if (timerFinished)
        {
            FindObjectOfType<LevelController>().LevelTimeFinished();
            triggeredLevelFinished = true;
        }
        else if (timerPhase3)
        {
            FindObjectOfType<LevelController>().SetPhase3();
        }
        else if(timerPhase2)
        {
            FindObjectOfType<LevelController>().SetPhase2();
        }    
    }
}
