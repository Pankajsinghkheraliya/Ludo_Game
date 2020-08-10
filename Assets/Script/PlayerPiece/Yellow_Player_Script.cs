using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yellow_Player_Script : Player_Script
{
    RollingDice YellowHomeRollingDice;

    private void Start()
    {
        YellowHomeRollingDice = GetComponentInParent<YelloHome>().rollingDice;
    }

    private void OnMouseDown()
    {
        if (GameManager.gm.rolledDice != null)
        {
            if (!isReady)
            {

                if (GameManager.gm.rolledDice == YellowHomeRollingDice && GameManager.gm.numOfStepsToMove == 6)
                {
                    MakePlayerReadyToMove(PathParent.yellowPathPoints);
                    GameManager.gm.numOfStepsToMove = 0;
                    return;
                }
            }

            if (GameManager.gm.rolledDice == YellowHomeRollingDice && isReady)
            {
                canMove = true;
            }
        }

        MoveSteps(PathParent.yellowPathPoints);
    }

}
