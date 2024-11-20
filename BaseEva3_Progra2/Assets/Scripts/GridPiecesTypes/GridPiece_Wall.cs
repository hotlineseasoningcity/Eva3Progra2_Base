using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPiece_Wall : GridPiece
{
    public float yOffSet;
    public Color[] colors;
    GameObject wall;

    public void CreateWall(GameObject wallPref)
    {
        Vector3 pos = transform.position;
        wall = Instantiate(wallPref, pos + Vector3.up * yOffSet, Quaternion.identity, transform);
        MeshRenderer wallMesh = wall.GetComponent<MeshRenderer>();
        StartCoroutine(Rainbow(wallMesh));
    }

    public override void OnEntityExit()
    {

    }

    public override void OnEntityStay()
    {

    }

    IEnumerator Rainbow(MeshRenderer mesh)
    {
        if (colors.Length > 0)
        {
            float dividedDuration = 5f / colors.Length;

            while (true)
            {
                for (int i = 0; i < colors.Length - 1; i++)
                {
                    float t = 0f;
                    
                    while (t < (1f + Mathf.Epsilon))
                    {
                        mesh.material.color = Color.Lerp(colors[i], colors[i + 1], t);
                        t += Time.deltaTime / dividedDuration;
                        yield return null;
                    }
                    mesh.material.color = Color.Lerp(colors[i], colors[i + 1], 1f);
                }
            }
        }
    }
}
