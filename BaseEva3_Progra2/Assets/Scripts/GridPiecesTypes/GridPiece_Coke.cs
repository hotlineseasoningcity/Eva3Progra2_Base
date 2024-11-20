using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPiece_Coke : GridPiece
{
    public float yOffSet;
    GameObject coke;
    bool isTouched;
    public void CreateWall(GameObject cokePref)
    {
        Vector3 pos = transform.position;
        coke = Instantiate(cokePref, pos + Vector3.up * yOffSet, Quaternion.identity, transform);
    }

    public override void OnEntityEnter(GridEntity gridEntity)
    {
        if (!isTouched)
        {
            isTouched = true;
            currentGridEntity = gridEntity;
            Destroy(coke);
        }

        //subirle felicidad
    }

    public override void OnEntityExit()
    {

    }

    public override void OnEntityStay()
    {

    }
}

