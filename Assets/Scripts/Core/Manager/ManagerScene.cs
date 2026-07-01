using UnityEngine;

public class ManagerScene : MonoBehaviour
{
    public static ManagerScene Instance { get; private set; }
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
        Debug.Log("Manager Scene");
    }

}