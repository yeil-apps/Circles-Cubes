using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool TriangleExtension = false;


    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    public delegate void MovesChanged();
    public event MovesChanged OnMovesChanged;

    public delegate void EnergyChange();
    public event EnergyChange OnEnergyChange;


    private int _moves = 0;
    public int Moves => _moves;

    public int Energy = 3;

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

    public void ChangeMoves(int count)
    {
        _moves += count;
        OnMovesChanged();
    }

    public void ChangeEnergy(int count)
    {
        Energy += count;
        OnEnergyChange();
    }
}
