using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPiece_Wall : GridPiece
{
    public bool isDestructible;
    public bool isDestroyed;
    public float yOffSet;
    GameObject wall;

    public void CreateWall(GameObject wallPref)
    {
        Vector3 pos = transform.position;
        pos += Vector3.up * yOffSet; 
        wall = Instantiate(wallPref, pos, Quaternion.identity,transform);
    }

    public void DestroyWall()
    {
        if(isDestructible)
        {
            Destroy(wall);
            isWalkable = true;
            isEmpty = true;
            isDestroyed = true;
        }
    }

    public override void OnEntityExit()
    {

    }

    public override void OnEntityStay()
    {

    }
}
