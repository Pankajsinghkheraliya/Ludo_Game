using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path_Object_Parent : MonoBehaviour
{
    public Path_points[] CommonPathPoints;
    public Path_points[] RedPathPoints;
    public Path_points[] BluePathPoints;
    public Path_points[] GreenPathPoints;
    public Path_points[] yellowPathPoints;

    [Header("Scales And Positions Difference")]
    public float[] Scales;
    public float[] positionDifference; 

}
