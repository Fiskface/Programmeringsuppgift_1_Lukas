using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class SceneManager : MonoBehaviour
{
    //Used to make settings in the scene
    
    [Header("Ball")]
    [NonSerialized]
    public Vector3 ballPosition;
    public Vector3 ballDirection;
    [Range(0, 20)]
    public float ballRadius;
    
    [Header("Plane")]
    [Range(0, 50)]
    public float planeDistance;
    public Vector3 normal;

    [NonSerialized] public Vector3 normalNormalized;

    private void Update()
    {
        normalNormalized = normal.normalized;
    }
}
