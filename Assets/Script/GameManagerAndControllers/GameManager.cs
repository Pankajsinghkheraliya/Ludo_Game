using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public int numOfStepsToMove;
    public RollingDice rolledDice;

    List<Path_points> playerOnPathPointsList = new List<Path_points>();

    private void Awake()
    {
        gm = this;
    }

    public void AddPathPoint(Path_points pathPoint_)
    {
        playerOnPathPointsList.Add(pathPoint_);
    }

    public void RemovePathPoint(Path_points pathPoint_)
    {
        if (playerOnPathPointsList.Contains(pathPoint_))
        {
            playerOnPathPointsList.Remove(pathPoint_);
        }
        else
        {
            Debug.Log("Path point to found to be removed.");
        }
    }
    
}
