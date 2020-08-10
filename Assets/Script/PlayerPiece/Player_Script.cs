using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour
{
    public bool isReady;
    public bool canMove;
    public bool moveNow;
    public int numberOfStepsAlreadyMoved;

    public Path_Object_Parent PathParent;
    public Path_points previousPathPoint;
    public Path_points currentPathPoint;

    Coroutine moveSteps_Coroutine;

    private void Awake()
    {
        PathParent = FindObjectOfType<Path_Object_Parent>();
    }

    public void MoveSteps(Path_points[] pathPointsToMoveOn_)
    {
        moveSteps_Coroutine = StartCoroutine(MoveSteps_Enum(pathPointsToMoveOn_));
    }

    public void MakePlayerReadyToMove(Path_points[] pathPointsToMoveOn_)
    {
        isReady = true;
        transform.position = pathPointsToMoveOn_[0].transform.position;
        numberOfStepsAlreadyMoved = 1;
        previousPathPoint = pathPointsToMoveOn_[0];
        currentPathPoint = pathPointsToMoveOn_[0];
        GameManager.gm.RemovePathPoint(previousPathPoint);
        GameManager.gm.AddPathPoint(currentPathPoint);
    }

    IEnumerator MoveSteps_Enum(Path_points[] pathPointsToMoveOn_)
    {
        yield return new WaitForSeconds(0.25f);
        int numOfStepsToMove = GameManager.gm.numOfStepsToMove;
        

        if (canMove)
        {
            previousPathPoint.RescaleAndRepositionAllPlayerPieces();

            for (int i = numberOfStepsAlreadyMoved; i <(numberOfStepsAlreadyMoved + numOfStepsToMove); i++)
            {
                if (isPathPointsAvailableToMove(numOfStepsToMove, numberOfStepsAlreadyMoved, pathPointsToMoveOn_))
                {
                    transform.position = pathPointsToMoveOn_[i].transform.position;
                    yield return new WaitForSeconds(0.5f);
                }

            }

            if (isPathPointsAvailableToMove(numOfStepsToMove, numberOfStepsAlreadyMoved, pathPointsToMoveOn_))
            {
                numberOfStepsAlreadyMoved += numOfStepsToMove;

                GameManager.gm.RemovePathPoint(previousPathPoint);
                previousPathPoint.RemovePlayerPiece(this);
                currentPathPoint = pathPointsToMoveOn_[numberOfStepsAlreadyMoved - 1];
                currentPathPoint.AddPlayerPiece(this);
                GameManager.gm.AddPathPoint(currentPathPoint);
                previousPathPoint = currentPathPoint;
            }


            if (moveSteps_Coroutine != null)
            {
                StopCoroutine(moveSteps_Coroutine);
            }
        }
                       
    }

    bool isPathPointsAvailableToMove(int numOfStepsToMove_, int numOfStepsAlreadyMoved_, Path_points[] pathPointToMoveOn)
    {
        int leftNumOfPathPoints = pathPointToMoveOn.Length - numOfStepsAlreadyMoved_;

        if (leftNumOfPathPoints >= numOfStepsToMove_)
        {
            return true;
        }
                                           
        return false;
    }



}
