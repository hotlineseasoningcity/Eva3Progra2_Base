using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPiece_Victory : GridPiece
{
    public override void OnEntityEnter(GridEntity gridEntity)
    {
        currentGridEntity = gridEntity;
        gridEntity.Win();
    }

    public override void OnEntityExit()
    {

    }

    public override void OnEntityStay()
    {

    }
}
