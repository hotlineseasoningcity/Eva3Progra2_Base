using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPiece_Banana : GridPiece
{
    public float yOffSet;
    GameObject banana;
    bool isTouched;

    public void CreateWall(GameObject bananaPref)
    {
        Vector3 pos = transform.position;
        banana = Instantiate(bananaPref, pos + Vector3.up * yOffSet, Quaternion.identity, transform);
    }

    public override void OnEntityEnter(GridEntity gridEntity)
    {
        if (!isTouched)
        {
            isTouched = true;
            currentGridEntity = gridEntity;
            gridEntity.life += 2;
            Destroy(banana);
        }

    }

    public override void OnEntityExit()
    {

    }

    public override void OnEntityStay()
    {

    }
}
