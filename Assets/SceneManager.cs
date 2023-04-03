using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class SceneManager : MonoBehaviour
{
    public Vector3 ballPosition;
    public Vector3 ballDirection;
    public float ballRadius;

    public float planeDistance;
    public Vector3 normal;

    [NonSerialized] public Vector3 normalNormalized;

    private void Update()
    {
        normalNormalized = normal.normalized;
    }
}
