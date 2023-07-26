using System;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;
using Vectors;

[ExecuteAlways]
[RequireComponent(typeof(VectorRenderer))]
public class Example : MonoBehaviour {
    //Optional: Gör så saker bara händer om bollens riktning är samma som bVectors riktning.
    [NonSerialized] 
    private VectorRenderer vectors;
    
    //Vectors
    private Vector3 aVector;
    private Vector3 bVector;

    //Positions
    private Vector3 bouncePosition;
    private Vector3 resultPosition;

    private float ballDiameter;
    private float aVectorLength;

    void OnEnable() {
        vectors = GetComponent<VectorRenderer>();
    }

    void Update()
    {
        SceneManager sM = GetComponentInParent<SceneManager>();
        
        ballDiameter = sM.ballRadius * 2; 
        
        aVectorLength = Math.DotProduct(sM.ballPosition, sM.normalNormalized) - sM.planeDistance - sM.ballRadius;
        
        aVector = -sM.normalNormalized * aVectorLength;
        
        if (aVectorLength == 0)
        {
            bVector = Vector3.zero;
        }
        else
        {
            bVector = Math.Normalize(sM.ballDirection) * (aVectorLength * aVectorLength) /
                              (Math.DotProduct(aVector ,Math.Normalize(sM.ballDirection)));
        }
        
        
            //Calculates all ball positions
        bouncePosition = sM.ballPosition + bVector;
        resultPosition = bouncePosition - aVector - aVector + bVector;
        
        
        //Makes the balls that shows where it will bounce and the result be right size and position
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
        

        //Draws vectors
        using (vectors.Begin()) {
            //Balldirection normalized
            vectors.Draw(sM.ballPosition, sM.ballPosition + Math.Normalize(sM.ballDirection), Color.green);
            
            //Vector to plane
            vectors.Draw(sM.ballPosition, sM.ballPosition + aVector, Color.red);
            //Vector to bounceposition
            vectors.Draw(sM.ballPosition, bouncePosition, Color.blue);
            //From bounceposition to resultposition
            vectors.Draw(bouncePosition, resultPosition, Color.cyan);
            
            //Showing Step vectors
            vectors.Draw(bouncePosition, bouncePosition-aVector, Color.magenta);
            vectors.Draw(bouncePosition-aVector, bouncePosition-aVector-aVector, Color.magenta);
            vectors.Draw(bouncePosition-aVector-aVector, resultPosition, Color.magenta);
            
            //Plane Normal
            Transform planetr = GameObject.Find("Plane").transform;
            vectors.Draw(planetr.position, planetr.position + planetr.up, Color.yellow);
        }
    }
}
