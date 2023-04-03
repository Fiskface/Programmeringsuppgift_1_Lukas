using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class GetPlaneValues : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        SceneManager sceneManager = GetComponentInParent<SceneManager>();
        transform.up = sceneManager.normalNormalized;
    }
}
