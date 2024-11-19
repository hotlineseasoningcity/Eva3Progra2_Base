using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackWallTimmer : MonoBehaviour
{
    public GameObject prefabWallBlack;
    public int height = 20;
    public int length = 9;
    public int guatonao = 10;
    public float blockSize = 1f;
    public float movTimer = 1f;
    public Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        initialPosition.z = -10;
        CreateBlackWall();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = initialPosition + new Vector3(0f, 0f, Time.time * movTimer);
    }

    void CreateBlackWall()
    {

        for (int x = 0; x < length; x++)
        {
            for (int y = 0; y < height; y++)
            {
                for (int z = 0; z < guatonao; z++)
                {
                    Vector3 position = new Vector3(x * blockSize, y * blockSize, z * blockSize);
                    Instantiate(prefabWallBlack, position, Quaternion.identity, transform);

                }
            }
        }
    }
}