using System;
using UnityEngine;

public class ManagerAudio : MonoBehaviour
{
    public static ManagerAudio Instance { get; private set; }
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
        Debug.Log("Manager Audio");
    }
}
