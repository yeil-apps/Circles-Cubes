using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsManager : MonoBehaviour
{
    private static LevelsManager _instance;
    public static LevelsManager Instance { get { return _instance; } }

    public List<GameObject> LevelsInOrder;
    private int _currentLevelIndex;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        GameManager.Instance.OnMovesChanged += CheckAnyMoves;
    }

    public void StartNewLevel(int levelIndex)
    {
        _currentLevelIndex = levelIndex;
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        Instantiate(LevelsInOrder[_currentLevelIndex], transform);
        if (!GameManager.Instance.TriangleExtension)
        {
            Triangle[] triangles = FindObjectsOfType<Triangle>();
            foreach (Triangle triangle in triangles)
            {
                Destroy(triangle.transform.gameObject);
            }
        }
    }

    private void CheckAnyMoves()
    {
        bool hasMoves = false;
        Circle[] circels = FindObjectsOfType<Circle>();
        foreach (Circle circle in circels)
        {
            if (circle.Filled == false)
            {
                hasMoves = true;
            }
        }
        if (!hasMoves)
        {
            NextLevel();
        }
    }

    private void NextLevel()
    {
        if (_currentLevelIndex + 1 < LevelsInOrder.Count)
        {
            StartNewLevel(_currentLevelIndex+1);
        }
        else
        {
            FindObjectOfType<UIController>().ShowLevelMenu();
        }

    }
}
