using System.Collections;
using System.Collections.Generic;
using UnityEngine;  

public class Red_Player_Script : Player_Script
{
    RollingDice RedHomeRollingDice;

    private void Start()
    {
        RedHomeRollingDice = GetComponentInParent<RedHome>().rollingDice;
    }

    private void OnMouseDown()
    {
        if (GameManager.gm.rolledDice != null)
        {
            if (!isReady)
            {

                if (GameManager.gm.rolledDice == RedHomeRollingDice && GameManager.gm.numOfStepsToMove == 6)
                {
                    MakePlayerReadyToMove(PathParent.RedPathPoints);
                    GameManager.gm.numOfStepsToMove = 0;
                    return;
                }
            }

            if (GameManager.gm.rolledDice == RedHomeRollingDice && isReady)
            {
                canMove = true;
            }
        }
        
        MoveSteps(PathParent.RedPathPoints);
    }
 

   
}
