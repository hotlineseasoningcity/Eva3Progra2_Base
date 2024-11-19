using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyMover : MonoBehaviour
{
    public float rotationSpeed = 5f;

    private Material skyboxMaterial;

    void Start()
    {
        skyboxMaterial = RenderSettings.skybox;
    }

    void Update()
    {
        float rotationAmount = rotationSpeed * Time.deltaTime;

        skyboxMaterial.SetFloat("_Rotation", skyboxMaterial.GetFloat("_Rotation") + rotationAmount);
    }
}