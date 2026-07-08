using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bootstrapper : MonoBehaviour
{
    [Header("Scene Settings")]
    public const string MAIN_MENU_SCENE_NAME = "MainMenu";
    [SerializeField] private Slider LoadingSlider;

    [Header("Game Manager")]
    public ManagerAssets ManagerAssets;
    public ManagerAudio ManagerAudio;
    public ManagerSave ManagerSave;
    public ManagerGame ManagerGame;
    public ManagerScene ManagerScene;
    public ManagerInput ManagerInput;
    

    private void Awake()
    {
        DontDestroyOnLoad(this);
        StartCoroutine(BootSequence());
    }
    private IEnumerator BootSequence()
    {
        yield return StartCoroutine(InitializeManagers());
        yield return StartCoroutine(LoadMainScene());
        Destroy(this);
    }
    private IEnumerator InitializeManagers()
    {
        DontDestroyOnLoad(ManagerAssets);
        DontDestroyOnLoad(ManagerAudio);
        DontDestroyOnLoad(ManagerSave);
        DontDestroyOnLoad(ManagerGame);
        DontDestroyOnLoad(ManagerInput);
        DontDestroyOnLoad(ManagerScene);
        yield return null; 
    }
    private IEnumerator LoadMainScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(MAIN_MENU_SCENE_NAME);
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            LoadingSlider.value = Mathf.Lerp(0f, 1f, asyncLoad.progress / 0.9f);
            if (asyncLoad.progress >= 0.9f)
            {
                yield return new WaitForSeconds(0.5f);
                asyncLoad.allowSceneActivation = true;
            }
            yield return null;
        }

    }
}