using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    //El arreglo requiere el mismo orden que el enum
    public GameObject[] gridPiecesPrefabs;
    public Vector2Int gridSize;

    public GridPiece[,] grid;

    //Se encarga de crear la grilla
    public void CreateGrid()
    {
        //Inicializo la matriz (arreglo bidimensional) segun el tamaño de la grilla
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

                //Guardo la pieza creada en la matriz
                grid[x,z] = newPiece;
            }
        }
    }

    //Se encarga de instanciar la pieza y setearla
    GridPiece CreatePiece(GridPieceType pieceType, Vector2Int pos)
    {
        GridPiece piece = null;


        return piece;   
    }

    //Se encarga de elegir el tipo de pieza segun la posicion
    public GridPieceType GetPieceType(Vector2Int pos)
    {
        GridPieceType gridPieceType = GridPieceType.Empty;



        return gridPieceType;
    }
}
