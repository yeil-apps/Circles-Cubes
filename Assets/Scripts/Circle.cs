using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Circle : MonoBehaviour
{
    public bool Filled = false;

    public void Select()
    {
        if (!Filled)
        {
            int mySize = transform.gameObject.GetComponent<Figure>().Size;
            Cube[] cubes = GameObject.FindObjectsOfType<Cube>();
            Cube selectedCube = null;
            foreach (Cube cube in cubes)
            {
                if (cube.CubeSelected)
                {
                    Figure figure = cube.gameObject.GetComponent<Figure>();
                    if (figure.Size <= mySize)
                    {
                        selectedCube = cube;
                        selectedCube.MoveCubeToCircle(transform);
                        Filled = true;
                        GameManager.Instance.ChangeMoves(1);
                    }
                }
            }
        }
    }

    public void CheckFilled()
    {
        if (transform.childCount == 0 && Filled)
        {
            Filled = false;
            GameManager.Instance.ChangeMoves(-1);
        }
    }
}
