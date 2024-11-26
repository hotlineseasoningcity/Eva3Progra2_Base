using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureGenerator : MonoBehaviour
{
    public Texture2D creature;
    public MeshRenderer piecePrefab;
    public Transform parent;
    public Vector2 offset = Vector2.zero;

    void Start()
    {
        GenerateCreature();
    }

    void CheckForPiece(int x, int y)
    {
        int adjustedX = x + Mathf.FloorToInt(offset.x);
        int adjustedY = y + Mathf.FloorToInt(offset.y);

        if (adjustedX >= 0 && adjustedX < creature.width && adjustedY >= 0 && adjustedY < creature.height)
        {
            Color pixelColor = creature.GetPixel(adjustedX, adjustedY);

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
