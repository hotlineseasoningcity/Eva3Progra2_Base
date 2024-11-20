using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPiece_Coke : GridPiece
{
    public float yOffSet;
    GameObject coke;

    public void CreateWall(GameObject cokePref)
    {
        Vector3 pos = transform.position;
        coke = Instantiate(cokePref, pos + Vector3.up * yOffSet, Quaternion.identity, transform);
    }

    public override void OnEntityEnter(GridEntity gridEntity)
    {
        currentGridEntity = gridEntity;
        //subirle felicidad
    }

    public override void OnEntityExit()
    {

    }

    public override void OnEntityStay()
    {

    }
}

