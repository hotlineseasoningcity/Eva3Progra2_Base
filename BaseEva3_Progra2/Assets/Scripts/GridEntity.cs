using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GridEntity : MonoBehaviour
{
    public EntityType entityType;
    public Vector2Int gridPos;
    public bool isTrigger;

    public abstract void InteractWhitOtherEntity(GridEntity other);

    public abstract void TakeDamage(float dmg);

}
