using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class SaveSlot : MonoBehaviour
{
    [SerializeField] Button CreateNew;
    [SerializeField] GameObject SaveInfo;
    // [SerializeField] Image PlayerAvatar;
    [SerializeField] TextMeshProUGUI PlayerLevel;
    [SerializeField] TextMeshProUGUI PlayerName;
    [SerializeField] Button RemoveSave;
    [SerializeField] Button PlaySave;
    void Awake()
    {
        CreateNew.onClick.AddListener(() =>
        {
            CreateNew.gameObject.SetActive(false);
            SaveInfo.SetActive(true);
        });
    }
    public void InitPlayerSaveData(PlayerSaveData data,SaveSlotIndex saveSlot)
    {
        PlayerLevel.text = data._level.ToString();
        PlayerName.text = data._playerName.ToString();
        CreateNew.gameObject.SetActive(false);
        PlaySave.onClick.AddListener(() =>
        {
            ManagerSave.Instance.Load(saveSlot);
            StartCoroutine(ManagerScene.Instance.LoadScene("Test"));
        });
        SaveInfo.SetActive(true);
    }
}
