using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path_points : MonoBehaviour
{
    public Path_Object_Parent pathObjParent;
    public List<Player_Script> playerPiecesList = new List<Player_Script>();

    private void Start()
    {
        pathObjParent = GetComponentInParent<Path_Object_Parent>();
    }


    public void AddPlayerPiece(Player_Script playerPiece_)
    {
        playerPiecesList.Add(playerPiece_);
        RescaleAndRepositionAllPlayerPieces();
    }


    public void RemovePlayerPiece(Player_Script playerPiece_)
    {
        if (playerPiecesList.Contains(playerPiece_))
        {
            playerPiecesList.Remove(playerPiece_);
            
        }
    }

   public void RescaleAndRepositionAllPlayerPieces()
    {
        int plsCount = playerPiecesList.Count;
        bool isOdd = (plsCount % 2) == 0 ? false : true;
        int spriteLayers = 5;

        int extent = plsCount / 2;
        int counter = 0;

        if (isOdd)
        {
            for ( int i = -extent; i <= extent; i++)
            {
                playerPiecesList[counter].transform.localScale = new Vector3(pathObjParent.Scales[plsCount - 1], pathObjParent.Scales[plsCount - 1], 1f);
                playerPiecesList[counter].transform.position = new Vector3(transform.position.x + (i * pathObjParent.positionDifference[plsCount - 1]), transform.position.y, 0f);
                counter++;
            }
        }
        else
        {
            for (int i = -extent; i < extent; i++)
            {
                playerPiecesList[counter].transform.localScale = new Vector3(pathObjParent.Scales[plsCount - 1], pathObjParent.Scales[plsCount - 1], 1f);
                playerPiecesList[counter].transform.position = new Vector3(transform.position.x + (i * pathObjParent.positionDifference[plsCount - 1]), transform.position.y, 0f);
                counter++;
            }
        }

        for (int i = 0; i < playerPiecesList.Count; i++)
        {
            playerPiecesList[i].GetComponentInChildren<SpriteRenderer>().sortingOrder = spriteLayers;
        }
    }


}
