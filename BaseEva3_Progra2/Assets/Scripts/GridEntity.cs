using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GridEntity : MonoBehaviour
{
    public EntityType entityType;
    public Vector2Int gridPos;
    public bool isTrigger, hasWon, hasLost;
    public float life;
    public float currentLife;
    public GameManager gameManager;

    private void Awake()
    {
        currentLife = life;
        Awake2();
    }

    protected abstract void Awake2();

    public virtual void TakeDamage(float dmg)
    {
        currentLife -= dmg;
        if (currentLife <= 0)
        {
            Die();
        }
    }

    public virtual void Win()
    {
        hasWon = true;
        gameManager.LoadVictory();

    }

    public virtual void Lose()
    {
        hasLost = true;
        gameManager.LoadDefeat();

    }

    protected abstract void Die();

    public abstract void InteractWhitOtherEntity(GridEntity other);
}
