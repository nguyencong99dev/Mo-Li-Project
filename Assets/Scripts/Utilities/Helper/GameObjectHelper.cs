using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public static class GameObjectHelper
{
    public static bool IsInLayerMask(int layer, LayerMask mask)
        => (mask.value & (1 << layer)) != 0;

    public static IEnumerator LoadScene(string SceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneName);
        asyncLoad.allowSceneActivation = false;
        while (!asyncLoad.isDone)
        {
            asyncLoad.allowSceneActivation = true;
            yield return null;
        }
    }
    public static void SetSliderValue(Slider _slider, float current, float max)
    {
        if (_slider != null)
        {
            _slider.maxValue = max;
            _slider.value = current;
        }
    }
    public static void SetTextValue(TextMeshProUGUI _text, float current, float max)
    {
        _text.text = $"{current}/{max}";
    }
}