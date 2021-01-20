using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiveDisplay : MonoBehaviour
{
    [SerializeField] float baseLives = 3;
    [SerializeField] int damage = 1;
    float lives;
    Text liveText;

    void Start()
    {
        lives = baseLives - PlayerPrefsController.GetDifficulty();
        liveText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        liveText.text = lives.ToString();
    }

    public void TakeLife()
    {
        lives -= damage;
        UpdateDisplay();

        if(lives < 1)
        {
            FindObjectOfType<LevelController>().setLose();
            FindObjectOfType<LevelController>().HandleLoseCondition();
            //FindObjectOfType<LevelLoader>().LoadYouLose();
        }
    }
}
