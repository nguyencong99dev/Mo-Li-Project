using UnityEngine;
using UnityEngine.UI;

public class UIHandleBtn : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] GameObject _object;
    private bool isActive = false;

    public void SetActive()
    {
        if (_object == null) return;
        isActive = !isActive;
        _object.SetActive(isActive);
    }
}
