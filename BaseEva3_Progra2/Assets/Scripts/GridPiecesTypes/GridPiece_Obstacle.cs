using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPiece_Obstacle : GridPiece
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

    public override void OnEntityEnter(GridEntity gridEntity)
    {
        currentGridEntity = gridEntity;
        gridEntity.TakeDamage(2);
    }

    public override void OnEntityExit()
    {

    }

    public override void OnEntityStay()
    {

    }
}
