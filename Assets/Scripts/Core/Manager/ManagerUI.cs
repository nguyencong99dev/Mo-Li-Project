using System;
using UnityEngine;

public class ManagerUI : MonoBehaviour
{
    public static ManagerUI Instance { get; private set; }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            return;
        }
        Debug.Log("Manager UI");
    }
}