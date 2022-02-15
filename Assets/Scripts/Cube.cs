using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cube : MonoBehaviour
{
    [HideInInspector]
    public bool CubeSelected;

    public void Select()
    {
        Cube[] cubes = GameObject.FindObjectsOfType<Cube>();
        foreach (Cube cube in cubes)
        {
            cube.CubeSelected = false;
        }
        CubeSelected = true;
    }
    public void MoveCubeToCircle(Transform newCircle)
    {
        Circle oldParent = transform.parent.GetComponent<Circle>();

        transform.SetParent(newCircle);
        transform.position = newCircle.position;
        CubeSelected = false;

        if (oldParent != null)
        {
            oldParent.CheckFilled();
        }

    }

    public void ReduceCubeSize()
    {
        Triangle[] triangles = GameObject.FindObjectsOfType<Triangle>();
        foreach (Triangle triangle in triangles)
        {
            if (triangle.TriangleSelected && transform.GetComponent<Figure>().Size > 1 && GameManager.Instance.Energy > 0)
            {
                transform.GetComponent<Figure>().ReduceSize();
                Destroy(triangle.transform.gameObject);
                GameManager.Instance.ChangeEnergy(-1);
            }
        }
    }

}
