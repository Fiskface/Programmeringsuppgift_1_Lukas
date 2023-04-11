using System;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;
using Vectors;

[ExecuteAlways]
[RequireComponent(typeof(VectorRenderer))]
public class Example : MonoBehaviour {
    
    [NonSerialized] 
    private VectorRenderer vectors;
    
    //Math
    private Vector3 aVector;
    private Vector3 bVector;

    private Vector3 bouncePosition;
    private Vector3 resultPosition;

    private float ballDiameter;

    void OnEnable() {
        vectors = GetComponent<VectorRenderer>();
    }

    void Update()
    {
        SceneManager sM = GetComponentInParent<SceneManager>();
        
        
        ballDiameter = sM.ballRadius * 2; 
        
        aVector = -sM.normalNormalized * sM.planeDistance;

        if (sM.planeDistance == 0)
        {
            bVector = Vector3.zero;
        }
        else
        {
            bVector = sM.ballDirection.normalized * (sM.planeDistance * sM.planeDistance) /
                      (Vector3.Dot(aVector ,sM.ballDirection.normalized));
        }
        bouncePosition = sM.ballPosition + bVector;
        resultPosition = bouncePosition - aVector - aVector + bVector;

        ballDiameter = sM.ballRadius * 2;
        
        
        foreach (var balltr in GetComponentsInChildren<Transform>())
        {
            if (balltr.name.ToLower().Contains("bounce"))
            {
                balltr.position = bouncePosition;
                balltr.localScale = new Vector3(ballDiameter, ballDiameter, ballDiameter);
            }
            if(balltr.name.ToLower().Contains("result"))
            {
                balltr.position = resultPosition;
                balltr.localScale = new Vector3(ballDiameter, ballDiameter, ballDiameter);
            }
        }

        
        //TODO: Fixa så de resterande 3 vectorerna ritas ut
        //Optional: Gör så saker bara händer om bollens riktning är samma som bVectors riktning.
        
        
        using (vectors.Begin()) {
            //Balldirection normalized
            vectors.Draw(sM.ballPosition, sM.ballPosition + sM.ballDirection.normalized, Color.green);
            
            //Vector to plane
            vectors.Draw(sM.ballPosition, sM.ballPosition + aVector, Color.red);
            //Vector to bounceposition
            vectors.Draw(sM.ballPosition, bouncePosition, Color.cyan);
            //From bounceposition to resultposition
            vectors.Draw(bouncePosition, resultPosition, Color.cyan);
            
            //Plane Normal
            Transform planetr = GameObject.Find("Plane").transform;
            vectors.Draw(planetr.position, planetr.position + planetr.up, Color.yellow);
        }
    }
}

/*
[CustomEditor(typeof(Example))]
public class ExampleGUI : Editor {
    void OnSceneGUI() {
        var ex = target as Example;
        if (ex == null) return;

        EditorGUI.BeginChangeCheck();
        var a = Handles.PositionHandle(ex.vectorA, Quaternion.identity);
        var b = Handles.PositionHandle(ex.vectorB, Quaternion.identity);
        var c = Handles.PositionHandle(ex.vectorC, Quaternion.identity);

        if (EditorGUI.EndChangeCheck()) {
            Undo.RecordObject(target, "Vector Positions");
            ex.vectorA = a;
            ex.vectorB = b;
            ex.vectorC = c;
            EditorUtility.SetDirty(target);
        }
    }
}
*/