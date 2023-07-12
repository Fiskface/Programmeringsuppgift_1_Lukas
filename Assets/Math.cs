using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Math
{
    public static float DotProduct(Vector3 vec1, Vector3 vec2)
    {
        return vec1.x * vec2.x + vec1.y * vec2.y + vec1.z * vec2.z;
    }

    public static Vector3 CrossProduct(Vector3 vec1, Vector3 vec2)
    {
        return new Vector3(vec1.y * vec2.z - vec1.z * vec2.y,
            vec1.z * vec2.x - vec1.x * vec2.z,
            vec1.x * vec2.y - vec1.y * vec2.x);
    }

    //Returns the length of a vector3
    public static float GetMagnitude(Vector3 vec)
    {
        return Mathf.Sqrt(vec.x * vec.x + vec.y * vec.y + vec.z * vec.z);
    }

    //Normalizes a vector3
    public static Vector3 Normalize(Vector3 vec)
    {
        if (GetMagnitude(vec) == 0)
            return Vector3.zero;
        
        return (1 / GetMagnitude(vec)) * vec;
    }
}
