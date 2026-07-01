using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] GameObject NewGameBtn;
    [SerializeField] GameObject LoadGameBtn;
    [SerializeField] GameObject SettingBtn;
    [SerializeField] GameObject ExitBtn;
    void Start()
    {
        UpdateUI();
        // Testing();
    }

    private void UpdateUI()
    {
        NewGameBtn.GetComponent<Button>().onClick.AddListener(() => StartCoroutine(GameObjectHelper.LoadScene("Test")));
    }
    private void Testing()
    {
        // LoadGameBtn.GetComponent<Button>().onClick.AddListener(() => Debug.Log());
    }
}
