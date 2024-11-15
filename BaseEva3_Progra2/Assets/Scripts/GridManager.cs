using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    //El arreglo requiere el mismo orden que el enum
    public GameObject[] gridPiecesPrefabs;
    public Vector2Int gridSize;
    public Transform parent;

    public GameObject wallPref;
    public GameObject obstaclePref;

    public GridPiece[,] grid;

    private void Awake()
    {
        CreateGrid();
    }

    //Se encarga de crear la grilla
    public void CreateGrid()
    {
        //Inicializo la matriz (arreglo bidimensional) segun el tama�o de la grilla
        grid = new GridPiece[gridSize.x, gridSize.y];

        for (int x = 0; x < gridSize.x; x++)
        {
            for(int z = 0; z < gridSize.y; z++)
            {
                //Obtengo posicion en grilla
                Vector2Int gridPos = new Vector2Int(x, z);
                
                //Segun la posicion devuelvo un tipo de pieza
                GridPieceType gridPieceType = GetPieceType(gridPos);
                
                //Ocupo la posicion en grilla y el tipo de pieza para instancia la pieza
                GridPiece newPiece = CreatePiece(gridPieceType, gridPos);
                newPiece.pos = gridPos;
                //Guardo la pieza creada en la matriz
                grid[x,z] = newPiece;
            }
        }
    }

    //Se encarga de instanciar la pieza y setearla
    GridPiece CreatePiece(GridPieceType pieceType, Vector2Int gridPos)
    {
        GridPiece piece = null;
        Vector3 position = new Vector3(gridPos.x,-0.5f, gridPos.y);
        GameObject pref = gridPiecesPrefabs[(int)pieceType];

        GameObject pieceObj = Instantiate(pref, position, Quaternion.identity,parent);
        
        switch (pieceType)
        {
            case GridPieceType.Empty:
                GridPiece_Empty gridPiece_Empty = pieceObj.GetComponent<GridPiece_Empty>();
                gridPiece_Empty.isEmpty = true;
                gridPiece_Empty.isWalkable = true;
                piece = gridPiece_Empty;
                break;
            case GridPieceType.Wall:
                GridPiece_Wall gridPiece_Wall = pieceObj.GetComponent<GridPiece_Wall>();
                gridPiece_Wall.isEmpty = false;
                gridPiece_Wall.isWalkable = false;
                gridPiece_Wall.CreateWall(wallPref);
                gridPiece_Wall.ChangeColor(GetRainbowColor((gridPos.x + gridPos.y) / (float)(7 + 80)), false);
                piece = gridPiece_Wall;
                break;
            case GridPieceType.Obstacle:
                GridPiece_Obstacle gridPiece_Obstacle = pieceObj.GetComponent<GridPiece_Obstacle>();
                gridPiece_Obstacle.isEmpty = true;
                gridPiece_Obstacle.isWalkable = true;
                gridPiece_Obstacle.CreateWall(obstaclePref);
                piece = gridPiece_Obstacle;
                break;
        }
        return piece;   
    }

    //Se encarga de elegir el tipo de pieza segun la posicion
    GridPieceType GetPieceType(Vector2Int pos)
    {
        GridPieceType gridPieceType = GridPieceType.Empty;
        if(pos.x == 0 || pos.x == gridSize.x-1 || pos.y == 0 || pos.y == gridSize.y-1)
        {
            gridPieceType = GridPieceType.Wall;
        }
        else if (pos.x == 3 && pos.y == 3)
        {
            gridPieceType = GridPieceType.Obstacle;
        }
        return gridPieceType;
    }

    Color GetRainbowColor(float value)
    {
        float r = Mathf.Sin(value * Mathf.PI * 2) * 0.5f + 0.5f;
        float g = Mathf.Sin((value + 0.33f) * Mathf.PI * 2) * 0.5f + 0.5f;
        float b = Mathf.Sin((value + 0.66f) * Mathf.PI * 2) * 0.5f + 0.5f;
        return new Color(r, g, b);
    }

    public bool IsPieceWalkable(Vector2Int piecePos)
    {
        return grid[piecePos.x, piecePos.y].isWalkable;
    }

    public GridPiece GetGridPiece(Vector2Int piecePos)
    {
        return grid[piecePos.x,piecePos.y];
    }

    public bool IsPosOnArray(Vector2Int pos)
    {
        return pos.x >= 0 && pos.x < gridSize.x && pos.y >= 0 && pos.y < gridSize.y;
    }
}
