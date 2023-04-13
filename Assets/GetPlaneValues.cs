using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class GetPlaneValues : MonoBehaviour
{

    // Sets orientation of plane
    void Update()
    {
        SceneManager sceneManager = GetComponentInParent<SceneManager>();
        transform.up = sceneManager.normalNormalized;
        transform.position = sceneManager.ballPosition - (sceneManager.ballRadius + sceneManager.planeDistance) * sceneManager.normalNormalized;
    }
}
