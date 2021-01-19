using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner: MonoBehaviour
{
    //[SerializeField] GameObject defender;
    Defender defender;

    private void OnMouseDown()
    {
        //SpawnDefender(GetSquareClicked());
        AttemptToPlaceDefenderAt(GetSquareClicked());
    }

    public void SetSeclectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        var StarDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defender.GetStarCost();
        if(StarDisplay.HaveEnoughStars(defenderCost))
        {
            SpawnDefender(gridPos);
            StarDisplay.SpendStars(defenderCost);
        }
        //if we have enough stars
            //spawn the defender
            //spawn the stars
    }

    //public void SetSec
    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    //Trả về x y trên grid
    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 roundedPos)
    {
        //GameObject newDefender = Instantiate(defender, transform.position, Quaternion.identity) as GameObject;
        Defender newDefender = Instantiate(defender, roundedPos, Quaternion.identity) as Defender;
    }
}
