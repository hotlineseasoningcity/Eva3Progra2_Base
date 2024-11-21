using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureGenerator : MonoBehaviour
{
    public Texture2D creature;
    public MeshRenderer piecePrefab;
    public Transform parent;

    void Start()
    {
        GenerateCreature();
    }

    void CheckForPiece(int x, int y)
    {
        Color pixelColor = creature.GetPixel(x, y);

        if (pixelColor == Color.red) { return; }

        MeshRenderer newPiece = Instantiate(piecePrefab, new Vector3(x, y, 0), Quaternion.identity, parent);
        
        if (pixelColor == Color.white)
        {
            newPiece.material.color = Color.white;
        }
        else if (pixelColor == Color.black)
        {
            newPiece.material.color = Color.black;
        }
    }

    void GenerateCreature()
    {
        for (int x = 0; x < creature.width; x++)
        {
            for (int y = 0; y < creature.height; y++)
            {
                CheckForPiece(x, y);
            }
        }
    }
}
