using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
    public const string CLoadingScene = "LoadingScene";
    public static ManagerScene Instance { get; private set; }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            return;
        }
        Debug.Log("Manager Scene Initialized");
    }
    public IEnumerator LoadScene(string sceneName)
    {
        AsyncOperation loadLoading = SceneManager.LoadSceneAsync(CLoadingScene, LoadSceneMode.Additive);
        while (!loadLoading.isDone)
        {
            yield return null;
        }
        AsyncOperation asyncLoadScene = SceneManager.LoadSceneAsync(sceneName);
        asyncLoadScene.allowSceneActivation = false;
        while (!asyncLoadScene.isDone)
        {
            // LoadingSlider.value = Mathf.Lerp(0f, 1f, asyncLoad.progress / 0.9f);
            if (asyncLoadScene.progress >= 0.9f)
            {
                yield return new WaitForSeconds(2f);
                asyncLoadScene.allowSceneActivation = true;
            }
            yield return null;
        }
        yield return null;
    }
}