using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GridEntity_Movible : GridEntity
{
    public GridManager gridManager;
    public float spd;
    public float yPos;
    public bool isMoving;

    private void Update()
    {
        Update2();
        if(!isMoving)
        {
            gridManager.grid[gridPos.x, gridPos.y].OnEntityStay();
        }
    }

    protected abstract void Update2();

    public virtual void Move(Vector2Int dir)
    {
        if (isMoving) return;
        Vector2Int newPos = gridPos + dir;
        if(gridManager.IsPosOnArray(newPos))
        {
            if (gridManager.IsPieceWalkable(newPos))
            {
                isMoving = true;
                StartCoroutine(MoveCoroutine(newPos));
            }
        }
    }

    protected IEnumerator MoveCoroutine(Vector2Int newPos)
    {
        //Llamo a funcion OnEntityExit de la gridPiece en la que me encuentro antes de moverme
        gridManager.grid[gridPos.x, gridPos.y].OnEntityExit();

        //Me muevo
        float lerp = 0;
        Vector3 start = new Vector3(gridPos.x, yPos, gridPos.y);
        Vector3 end = new Vector3(newPos.x, yPos, newPos.y);
        while (lerp < 1)
        {
            lerp += Time.deltaTime * spd;
            transform.position = Vector3.Lerp(start, end, lerp);

            yield return null;

            if (lerp >= 1)
            {
                transform.position = end;
            }
        }

        //Al terminar mi movimiento cambio mi posicion
        gridPos = newPos;

        //Llamo a la función OnEntityEnter de la GridPiece a la que entro y me entrego 1313
        GridPiece newGridPiece = gridManager.grid[newPos.x, newPos.y];
        newGridPiece.OnEntityEnter(this);
        isMoving = false;
        OnMovementEnd(newGridPiece);
    }

    protected virtual void OnMovementEnd(GridPiece gridPiece)
    {

    }
}
