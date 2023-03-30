using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public Vector3 ballPosition;
    public Vector3 ballDirection;
    public float ballRadius;

    public float planeDistance;
    public Vector3 normal;

    private Vector3 planeNormalLastFrame;
    
    [NonSerialized]
    public bool updatedNormal;

    private void Update()
    {
        if (planeNormalLastFrame != normal)
        {
            updatedNormal = true;
        }

        planeNormalLastFrame = normal;
    }
}
