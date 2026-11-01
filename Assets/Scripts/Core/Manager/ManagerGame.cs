using System;
using System.IO;
using UnityEngine;
using System.Collections.Generic;
using System.Numerics;

public enum GameState { Playing, Paused, Dialog, Cutscene }
public class ManagerGame : MonoBehaviour
{
    public static ManagerGame Instance { get; private set; }
    public GameState CurrentState { get; private set; }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            return;
        }
        Debug.Log("Manager Game");
    }
    public void SetState(GameState newState)
    {
        if (CurrentState == newState) return;

        GameState oldState = CurrentState;
        CurrentState = newState;
        if (newState == GameState.Paused)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;

        Debug.Log($"Game State changed: {oldState} → {newState}");
    }

}
