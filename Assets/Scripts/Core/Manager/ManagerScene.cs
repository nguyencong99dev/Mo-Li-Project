using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerScene : MonoBehaviour
{
    public const string CLoadingScene = "LoadingScene";
    private const float FILL_SPEED = 1.2f;
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
        ManagerInput.Instance.DisableInput();
        Scene currentScene = SceneManager.GetActiveScene();
        AsyncOperation loadLoading = SceneManager.LoadSceneAsync(CLoadingScene, LoadSceneMode.Additive);
        while (!loadLoading.isDone)
        {
            yield return null;
        }

        Scene loadingScene = SceneManager.GetSceneByName(CLoadingScene);
        if (!loadingScene.IsValid() || !loadingScene.isLoaded || !SceneManager.SetActiveScene(loadingScene))
        {
            Debug.LogError($"Could not set '{CLoadingScene}' as the active scene.");
            yield break;
        }

        Slider loadingSlider = null;
        GameObject sliderObj = GameObject.FindWithTag("LoadingSlider");
        if (sliderObj != null)
        {
            loadingSlider = sliderObj.GetComponent<Slider>();
            loadingSlider.value = 0f; // Reset về 0
        }
        AsyncOperation asyncLoadScene = SceneManager.LoadSceneAsync(sceneName);
        asyncLoadScene.allowSceneActivation = false;
        while (!asyncLoadScene.isDone)
        {
            float targetProgress = Mathf.Clamp01(asyncLoadScene.progress / 0.9f);

            if (loadingSlider != null)
            {
                loadingSlider.value = Mathf.MoveTowards(loadingSlider.value, targetProgress, Time.deltaTime * FILL_SPEED);
            }

            // Điều kiện kích hoạt: Dữ liệu nạp ngầm xong (>= 0.9) VÀ thanh slider đã hiển thị đầy 100%
            if (asyncLoadScene.progress >= 0.9f && (loadingSlider == null || Mathf.Approximately(loadingSlider.value, 1f)))
            {
                yield return new WaitForSeconds(0.3f);
                asyncLoadScene.allowSceneActivation = true;
                ManagerInput.Instance.EnableInput();
            }
            yield return null;
        }
    }
}