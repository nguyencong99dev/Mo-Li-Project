using UnityEngine;
using UnityEngine.AddressableAssets;
public class ManagerData : MonoBehaviour
{
    public static ManagerData Instance { get; private set; }
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
