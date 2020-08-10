using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green_Player_Script : Player_Script
{
    RollingDice GreenHomeRollingDice;

    private void Start()
    {
        GreenHomeRollingDice = GetComponentInParent<GreenHome>().rollingDice;
    }

    private void OnMouseDown()
    {
        if (GameManager.gm.rolledDice != null)
        {
            if (!isReady)
            {

                if (GameManager.gm.rolledDice == GreenHomeRollingDice && GameManager.gm.numOfStepsToMove == 6)
                {
                    MakePlayerReadyToMove(PathParent.GreenPathPoints);
                    GameManager.gm.numOfStepsToMove = 0;
                    return;
                }
            }

            if (GameManager.gm.rolledDice == GreenHomeRollingDice && isReady)
            {
                canMove = true;
            }
        }

        MoveSteps(PathParent.GreenPathPoints);
    }

}
