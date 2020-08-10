using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue_Player_Script : Player_Script
{
    RollingDice BlueHomeRollingDice;

    private void Start()
    {
        BlueHomeRollingDice = GetComponentInParent<BlueHome>().rollingDice;
    }

    private void OnMouseDown()
    {
        if (GameManager.gm.rolledDice != null)
        {
            if (!isReady)
            {

                if (GameManager.gm.rolledDice == BlueHomeRollingDice && GameManager.gm.numOfStepsToMove == 6)
                {
                    MakePlayerReadyToMove(PathParent.BluePathPoints);
                    GameManager.gm.numOfStepsToMove = 0;
                    return;
                }
            }

            if (GameManager.gm.rolledDice == BlueHomeRollingDice && isReady)
            {
                canMove = true;
            }
        }

        MoveSteps(PathParent.BluePathPoints);
    }


}
