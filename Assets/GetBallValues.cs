using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class GetBallValues : MonoBehaviour
{
    void Update()
    {
        SceneManager sceneManager = GameObject.FindWithTag("SceneManager").GetComponent<SceneManager>();
        transform.position = sceneManager.ballPosition;
        
    }
}
