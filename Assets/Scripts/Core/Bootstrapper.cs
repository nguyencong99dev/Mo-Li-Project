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
        DontDestroyOnLoad(ManagerGame);
        DontDestroyOnLoad(ManagerInput);
        DontDestroyOnLoad(ManagerScene);
        yield return null;
    }
    private IEnumerator LoadMainScene()
    {
        LoadingSlider.value = 0f;
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(MAIN_MENU_SCENE_NAME);
        asyncLoad.allowSceneActivation = false;
        float fillSpeed = 1.5f;
        while (!asyncLoad.isDone)
        {
            float targetProgress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            LoadingSlider.value = Mathf.MoveTowards(LoadingSlider.value, targetProgress, Time.deltaTime * fillSpeed);
            if (asyncLoad.progress >= 0.9f && Mathf.Approximately(LoadingSlider.value, 1f))
            {
                yield return new WaitForSeconds(0.2f);
                asyncLoad.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}