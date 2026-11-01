using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] Button PlayBtn;
    [SerializeField] Button SettingBtn;
    [SerializeField] Button ExitBtn;
    [SerializeField] Transform LoadMenu;
    
    void Start()
    {
        ManagerSave.Instance.GetSaveData();
        UpdateUI();
    }
    private void UpdateUI()
    {
        PlayBtn.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
            LoadMenu.gameObject.SetActive(true);
        });
        // SettingBtn.onClick.AddListener(() =>
        // {

        // });
        foreach(var save in ManagerSave.Instance.playerSaveData)
        {
            if(save.Value == null) return;
            if (!LoadMenu.GetChild((int)save.Key - 1).TryGetComponent<SaveSlot>(out var slot)) return;
            slot.InitPlayerSaveData(save.Value._player,save.Key);
        }
    }

}
