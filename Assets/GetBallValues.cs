using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class GetBallValues : MonoBehaviour
{
    private float diameter;
    void Update()
    {
        SceneManager sceneManager = GameObject.FindWithTag("SceneManager").GetComponent<SceneManager>();
        transform.position = sceneManager.ballPosition;
        diameter = sceneManager.ballRadius * 2;
        transform.localScale = new Vector3(diameter, diameter, diameter);
    }
}

