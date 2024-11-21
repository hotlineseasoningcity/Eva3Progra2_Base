using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    //El arreglo requiere el mismo orden que el enum
    public GameObject[] gridPiecesPrefabs;
    public Vector2Int gridSize;
    public Transform parent;

<<<<<<< HEAD
    public GameObject wallPref;
    public GameObject wallDestructiblePref;
    public GameObject lava;
=======
    public GameObject victoryPref, wallPref, obstaclePref, bananaPref, cokePref;
    public Color lighterGreen, lightGreen, green, darkerGreen;
>>>>>>> CreaturaDanger

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
            for (int z = 0; z < gridSize.y; z++)
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
            case GridPieceType.Victory:
                GridPiece_Victory gridPiece_Victory = pieceObj.GetComponent<GridPiece_Victory>();
                gridPiece_Victory.isEmpty = true;
                gridPiece_Victory.isWalkable = true;
                piece = gridPiece_Victory;
                break;
            case GridPieceType.Wall:
                GridPiece_Wall gridPiece_Wall = pieceObj.GetComponent<GridPiece_Wall>();
                gridPiece_Wall.isEmpty = false;
                gridPiece_Wall.isWalkable = false;
                gridPiece_Wall.CreateWall(wallPref);
                piece = gridPiece_Wall;
                break;
            case GridPieceType.Obstacle:
                GridPiece_Obstacle gridPiece_Obstacle = pieceObj.GetComponent<GridPiece_Obstacle>();
                gridPiece_Obstacle.isEmpty = true;
                gridPiece_Obstacle.isWalkable = true;
                gridPiece_Obstacle.CreateWall(obstaclePref);
                piece = gridPiece_Obstacle;
                break;
<<<<<<< HEAD
            case GridPieceType.Damage:
                GridPiece_Obstaculo gridPiece_Obstaculo = pieceObj.GetComponent<GridPiece_Obstaculo>();
                gridPiece_Obstaculo.isWalkable = true;
                gridPiece_Obstaculo.isEmpty = true;
                piece = gridPiece_Obstaculo;
                break;

=======
            case GridPieceType.Banana:
                GridPiece_Banana gridPiece_Banana = pieceObj.GetComponent<GridPiece_Banana>();
                gridPiece_Banana.isEmpty = true;
                gridPiece_Banana.isWalkable = true;
                gridPiece_Banana.CreateWall(bananaPref);
                piece = gridPiece_Banana;
                break;
            case GridPieceType.Coke:
                GridPiece_Coke gridPiece_Coke = pieceObj.GetComponent<GridPiece_Coke>();
                gridPiece_Coke.isEmpty = true;
                gridPiece_Coke.isWalkable = true;
                gridPiece_Coke.CreateWall(cokePref);
                piece = gridPiece_Coke;
                break;
        }

        if ((gridPos.x + gridPos.y) % 2 == 0)
        {
            piece.ChangeColor(green, false);
        }
        else
        {
            piece.ChangeColor(darkerGreen, false);
        }

        if (gridPos.x <= 5 && gridPos.y >= 76)
        {
            
            piece.ChangeColor(lightGreen, false);

            if ((gridPos.x + gridPos.y) % 2 == 0)
            {
                piece.ChangeColor(lighterGreen, false);
            }
>>>>>>> CreaturaDanger
        }

        return piece;   
    }

    GridPieceType GetPieceType(Vector2Int pos)
    {
        GridPieceType gridPieceType = GridPieceType.Empty;
<<<<<<< HEAD
        if (pos.x == 0 || pos.x == gridSize.x - 1 || pos.y == 0 || pos.y == gridSize.y - 1)
=======

        if(pos.x == 0 || pos.x == gridSize.x-1 || pos.y == 0 || pos.y == gridSize.y-1)
>>>>>>> CreaturaDanger
        {
            gridPieceType = GridPieceType.Wall;
        }
        else if (Random.Range(0f, 10f) < 0.45f)
        {
            gridPieceType = GridPieceType.Obstacle;
        }
<<<<<<< HEAD
        else if (pos.x == 3 && pos.y == 3)
        {
            gridPieceType = GridPieceType.Damage;
        }
=======
        else if (Random.Range(0f, 10f) < 0.25f)
        {
            gridPieceType = GridPieceType.Banana;
        }
        else if (Random.Range(0f, 10f) < 0.15f)
        {
            gridPieceType = GridPieceType.Coke;
        }
        else if (pos.x <= 5 && pos.y >= 76)
        {
            gridPieceType = GridPieceType.Victory;
        }

>>>>>>> CreaturaDanger
        return gridPieceType;
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
