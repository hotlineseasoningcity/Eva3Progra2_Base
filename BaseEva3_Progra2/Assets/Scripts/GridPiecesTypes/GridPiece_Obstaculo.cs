using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPiece_Obstaculo : GridPiece
{
    public override void OnEntityEnter(GridEntity gridEntity)
    {
        base.OnEntityEnter(gridEntity);
        currentGridEntity.TakeDamage(0.5f);

    }
    public override void OnEntityStay()
    {
     
    }
    public override void OnEntityExit()
    {
     
    }
}
