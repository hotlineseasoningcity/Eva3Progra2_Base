using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPiece_Wall : GridPiece
{
    public float yOffSet;
    GameObject wall;

    public void CreateWall(GameObject wallPref)
    {
        Vector3 pos = transform.position;
        wall = Instantiate(wallPref, pos + Vector3.up * yOffSet, Quaternion.identity, transform);
        MeshRenderer wallMesh = wall.GetComponent<MeshRenderer>();
        wallMesh.material.color = GetRainbowColor((pos.x + pos.y / (float)(7 + 80)));
    }

    public override void OnEntityExit()
    {

    }

    public override void OnEntityStay()
    {

    }

    Color GetRainbowColor(float value)
    {
        float r = Mathf.Sin(value * Mathf.PI * 2) * 0.5f + 0.5f;
        float g = Mathf.Sin((value + 0.33f) * Mathf.PI * 2) * 0.5f + 0.5f;
        float b = Mathf.Sin((value + 0.66f) * Mathf.PI * 2) * 0.5f + 0.5f;
        return new Color(r, g, b);
    }
}
