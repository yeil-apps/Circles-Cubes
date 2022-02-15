using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIController : MonoBehaviour
{
    public Text MovesText;
    public GameObject EnergyUI;
    public Text EnergyText;
    public GameObject LevelWindow;

    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameManager.Instance;
        _gameManager.OnMovesChanged += DisplayMoves;
        _gameManager.OnEnergyChange += DisplayEnergy;
        DisplayMoves();
        DisplayEnergy();

        if (!_gameManager.TriangleExtension)
            EnergyUI.SetActive(false);
    }

    public void StartLevel(int levelIndex)
    {
        CloseLevelWindow();
        LevelsManager.Instance.StartNewLevel(levelIndex);
    }

    public void ShowLevelMenu()
    {
        LevelWindow.SetActive(true);
    }

    public void CloseLevelWindow()
    {
        LevelWindow.SetActive(false);
    }


    private void DisplayMoves()
    {
        MovesText.text = _gameManager.Moves.ToString();
    }

    private void DisplayEnergy()
    {
        EnergyText.text = _gameManager.Energy.ToString();
    }
}
