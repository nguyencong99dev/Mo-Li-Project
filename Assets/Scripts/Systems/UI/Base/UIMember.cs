using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIPartyMember : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] GameObject Image;
    [SerializeField] GameObject Name;
    [SerializeField] GameObject MaxHP;
    [SerializeField] GameObject Level;

    [Header("Data")]
    [SerializeField] DataMember member;
}
