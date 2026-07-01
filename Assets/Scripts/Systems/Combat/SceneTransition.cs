using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string combatSceneName = "Test";
    // [SerializeField] private LayerMask playerLayer;
    
    void Awake()
    {
        
    }
    
    public void EndCombat()
    {
        SceneManager.UnloadSceneAsync(combatSceneName);
    }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     _player = collision.GetComponent<PlayerController>();
    //     if (!GameObjectHelper.IsInLayerMask(collision.gameObject.layer, playerLayer)) return;
    //     StartCombat();
    // }
    // private void OnTriggerExit2D(Collider2D collision)
    // {
    //     if (!GameObjectHelper.IsInLayerMask(collision.gameObject.layer, playerLayer)) return;
    //     _player = null;
    //     EndCombat();
    // }
}
