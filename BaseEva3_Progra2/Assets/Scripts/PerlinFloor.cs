using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinFloor : MonoBehaviour
{
    public int width = 80;
    public int height = 3;
    public int depth = 10;
    public GameObject blockPrefab;
    public float noiseScale = 0.1f;
    public float heightOffset = -5f; 
    public float xOffset = -5f;       

    void Start()
    {
        BuildWall();
    }

    void BuildWall()
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < depth; z++)
            {
                for (int y = 0; y < height; y++)
                {
                    float perlinValue = Mathf.PerlinNoise((x + z) * noiseScale, y * noiseScale);
                    float blockHeightOffset = Mathf.Floor(perlinValue * height);

                    Vector3 position = new Vector3(x + xOffset, blockHeightOffset + heightOffset, z);

                    GameObject block = Instantiate(blockPrefab, position, Quaternion.identity);

                    Renderer blockRenderer = block.GetComponent<Renderer>();
                    blockRenderer.material.color = GetRainbowColor((x + y + z) / (float)(width + height + depth));

                    block.transform.parent = this.transform;
                }
            }
        }
    }

    Color GetRainbowColor(float value)
    {
        float r = Mathf.Sin(value * Mathf.PI * 2) * 0.5f + 0.5f;
        float g = Mathf.Sin((value + 0.33f) * Mathf.PI * 2) * 0.5f + 0.5f;
        float b = Mathf.Sin((value + 0.66f) * Mathf.PI * 2) * 0.5f + 0.5f;
        return new Color(r, g, b);
    }
}