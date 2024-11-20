using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridEntity_Movible_Player : GridEntity_Movible
{
    public Vector2Int startPos;
    private float lastMov = 0f;
    private float coolDown = 0.7f;

    protected override void Awake2()
    {

    }

    private void Start()
    {
        SetPlayerPos(startPos);
    }

    protected override void Update2()
    {
        if (!isMoving)
        {
            MoveInputs();
        }
    }  

    public void SetPlayerPos(Vector2Int pos)
    {
        gridPos = pos;
        gridManager.GetGridPiece(pos).OnEntityEnter(this);
    }

    void MoveInputs()
    {
        if (Time.time - lastMov >= coolDown)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            Vector2Int dir = Vector2Int.zero;

            if (Input.GetKey(KeyCode.W))
            {
                dir.y = 1;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                dir.y = -1;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                dir.x = -1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                dir.x = 1;
            }

            if (dir.magnitude != 0)
            {
                transform.forward = new Vector3(dir.x, 0, dir.y);
                Move(dir);

                lastMov = Time.time;
            }
        }
    }

    public override void InteractWhitOtherEntity(GridEntity other)
    {
        other.InteractWhitOtherEntity(this);
    }


    protected override void Die()
    {
        gameObject.SetActive(false);
        hasLost = true;
        print("PlayerDead");
    }
}
