using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPiece_Banana : GridPiece
{
    public float yOffSet;
    GameObject banana;

    public void CreateWall(GameObject bananaPref)
    {
        Vector3 pos = transform.position;
        banana = Instantiate(bananaPref, pos + Vector3.up * yOffSet, Quaternion.identity, transform);
    }

    public override void OnEntityEnter(GridEntity gridEntity)
    {
        currentGridEntity = gridEntity;
        gridEntity.life += 2;
    }

    public override void OnEntityExit()
    {

    }

    public override void OnEntityStay()
    {

    }
}
