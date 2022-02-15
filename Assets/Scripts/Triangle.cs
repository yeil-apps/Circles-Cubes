using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle : MonoBehaviour
{
    [HideInInspector]
    public bool TriangleSelected = false;
    public void Select()
    {
        Triangle[] triangles = GameObject.FindObjectsOfType<Triangle>();
        foreach (Triangle triangle in triangles)
        {
            triangle.TriangleSelected = false;
        }
        TriangleSelected = true;
    }
}
