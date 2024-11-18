using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPiece_Obstacle : GridPiece
{
    public bool isDestructible;
    public bool isDestroyed;
    public float yOffSet;
    GameObject obstacle;

    public void CreateWall(GameObject obstaclePref)
    {
        Vector3 pos = transform.position;
        obstacle = Instantiate(obstaclePref, pos + Vector3.up * yOffSet, Quaternion.identity, transform);
        MeshRenderer obstacleMesh = obstacle.GetComponent<MeshRenderer>();
        obstacleMesh.material.color = Random.ColorHSV(0, 1, 0.95f, 0.95f, 0.95f, 0.95f);
    }

    public override void OnEntityEnter(GridEntity gridEntity)
    {
        currentGridEntity = gridEntity;
        gridEntity.TakeDamage(2);
    }

    public override void OnEntityExit()
    {

    }

    public override void OnEntityStay()
    {

    }
}
