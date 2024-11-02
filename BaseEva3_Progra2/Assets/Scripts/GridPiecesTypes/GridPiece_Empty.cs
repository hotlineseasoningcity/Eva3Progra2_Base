using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPiece_Empty : GridPiece
{
    public override void OnEntityEnter(GridEntity gridEntity)
    {
        if(!isEmpty)
        {
            gridEntity.InteractWhitOtherEntity(currentGridEntity);
        }
        isEmpty = false;
        isWalkable = gridEntity.isTrigger;
        base.OnEntityEnter(gridEntity);
    }

    public override void OnEntityExit()
    {
        currentGridEntity = null;
        isEmpty = true;
        isWalkable = true;
    }

    public override void OnEntityStay()
    {
        return;
    }
}
