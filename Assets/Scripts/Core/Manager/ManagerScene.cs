using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
    public const string LoadingScene = "LoadingScene";
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
        // SceneManager.LoadScene(LoadingScene);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        asyncLoad.allowSceneActivation = false;
        while (!asyncLoad.isDone)
        {
            // LoadingSlider.value = Mathf.Lerp(0f, 1f, asyncLoad.progress / 0.9f);
            if (asyncLoad.progress >= 0.9f)
            {
                yield return new WaitForSeconds(2f);
                asyncLoad.allowSceneActivation = true;
            }
            yield return null;
        }
        yield return null;
    }
}