using UnityEngine;
using UnityEngine.UI;

public class UIHandleMemberPanel : MonoBehaviour
{
    [Header("UI References")]
    public Button InitBtn;
    public Button RemoveBtn;
    public GameObject MemberPanel;
    void Start()
    {
        InitBtn.onClick.AddListener(() => SetActive(true));
        RemoveBtn.onClick.AddListener(() => SetActive(false));
    }
    public void SetActive(bool isActive)
    {
        if (MemberPanel == null) return;
        InitBtn.gameObject.SetActive(!isActive);
        MemberPanel.SetActive(isActive);
    }
}
