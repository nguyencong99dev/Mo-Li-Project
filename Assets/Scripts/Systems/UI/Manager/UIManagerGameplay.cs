using System.Collections.Generic;
using UnityEngine;

public class UIManagerGameplay : MonoBehaviour
{
    public static UIManagerGameplay Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}