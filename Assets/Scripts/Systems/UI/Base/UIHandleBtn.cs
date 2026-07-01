using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIHandleBtn : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] GameObject _object;

    public void SetActive(bool isActive)
    {
        if (_object == null) return;
        _object.SetActive(!isActive);
    }
}
