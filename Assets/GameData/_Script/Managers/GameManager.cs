using System;
using UnityEngine;

public enum GameState
{
    GenerateGrid = 0,
    SpawnPlayer = 1,
    SpawnEnemies = 2,
    PlayerTurn = 3,
    EnemiesTurn = 4
}
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private GameState gameState;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    private void Start()
    {
        ChangeState(GameState.GenerateGrid);
    }
    public void ChangeState(GameState newState)
    {
        gameState = newState;
        switch (gameState)
        {
            case GameState.GenerateGrid:
                GridManager.Instance.GenerateGrid();
                break;
            case GameState.SpawnPlayer:
                break;
            case GameState.SpawnEnemies:
                break;
            case GameState.PlayerTurn:
                break;
            case GameState.EnemiesTurn:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }
}
