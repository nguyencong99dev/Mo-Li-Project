using UnityEngine;
using UnityEngine.UI;

public class HUDSetting : MonoBehaviour
{
    [SerializeField] private Button _ContinueBtn;
    [SerializeField] private Button _SaveBtn;
    [SerializeField] private Button _LoadBtn;
    [SerializeField] private Button _ExitBtn;
    
    void Start()
    {
        _ContinueBtn.onClick.AddListener(HandleContinueBtn);
        _SaveBtn.onClick.AddListener(HandleSaveBtn);
        _LoadBtn.onClick.AddListener(HandleLoadBtn);
        _ExitBtn.onClick.AddListener(HandleExitBtn);
    }
    void HandleContinueBtn()
    {
       
    }
    void HandleSaveBtn()
    {
        ManagerSave.Instance.Save(SaveSlotIndex.One);
    }
    void HandleLoadBtn()
    {
        
    }
    void HandleExitBtn()
    {
        
    }
}
