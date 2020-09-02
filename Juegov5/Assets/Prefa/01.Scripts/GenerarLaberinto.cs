using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum wallOrientation{
   west=0,North=1,EAST=2,south=3
   }


public class GenerarLaberinto : MonoBehaviour
{
 

public GameObject[] walls;
public bool isVisited=false;

private bool[] wallsActive={true,true,true,true};

//-------------
public void HideWall(wallOrientation orientation)
{
    int index=(int)orientation;
    if (walls[index]!=null)
    {
        Destroy(walls[index]);
        this.walls[index]=null;
        this.wallsActive[index]=false;
    
     }
}

public bool IsWallActive(wallOrientation orientation)
{
    int index=(int)orientation;
    return this.wallsActive[index];
}




}
