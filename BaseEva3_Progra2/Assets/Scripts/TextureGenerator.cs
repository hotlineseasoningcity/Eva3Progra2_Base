using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureGenerator : MonoBehaviour
{
    public Texture2D grid;
    public GameObject piecePrefab;
    public Transform parent;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int x = 0; x < grid.width; x++)
        {
            for (int y = 0; y < grid.height; y++)
            {
                CheckForPiece(x, y);
            }
        }
    }

    void CheckForPiece(int x, int y)
    {
        Color pixelColor = grid.GetPixel(x, y);

        if (pixelColor == Color.red) { return; }

        GameObject newPiece = Instantiate(piecePrefab, new Vector3(x, y, 0), Quaternion.identity, parent);
        MeshRenderer meshPiece = newPiece.GetComponent<MeshRenderer>();

        if (pixelColor == Color.white) 
        { 
            meshPiece.material.color = Color.white; 
        }

        if (pixelColor == Color.black)
        {
            meshPiece.material.color = Color.black;
        }

    }
}
