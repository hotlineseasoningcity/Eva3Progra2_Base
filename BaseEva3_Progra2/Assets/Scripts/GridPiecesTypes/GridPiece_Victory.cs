using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPiece_Victory : GridPiece
{
    public bool isVictoryTriggered;

    public override void OnEntityEnter(GridEntity gridEntity)
    {
        currentGridEntity = gridEntity;
        gridEntity.hasWon = true;
        isVictoryTriggered = true;
    }

    public override void OnEntityExit()
    {

    }

    public override void OnEntityStay()
    {

    }
}
