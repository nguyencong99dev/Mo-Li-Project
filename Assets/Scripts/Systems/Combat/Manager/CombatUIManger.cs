using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class CombatUIManager : MonoBehaviour
{
    public static CombatUIManager Instance { get; private set; }

    [SerializeField] CombatPanelSkill CombatPanelSkill;
    [SerializeField] GameObject NotificationPanel;
    [SerializeField] private int poolSize = 10;
    [SerializeField] private Transform canvasVFX;
    [SerializeField] private Transform canvasText;
    [SerializeField] private FloatingText prefabText;
    [SerializeField] private FloatingVFX prefabVFX;
    
    private GenericObjectPool<FloatingText> _poolText;
    private GenericObjectPool<FloatingVFX> _poolVFX;
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
        _poolText = new GenericObjectPool<FloatingText>(prefabText, canvasText.transform, poolSize);
        _poolVFX = new GenericObjectPool<FloatingVFX>(prefabVFX, canvasVFX.transform, poolSize);
    }
    private void OnEnable()
    {
        EventBus<SCombatState>.Subscribe(HandleCombatState);
    }
    private void OnDisable()
    {
        EventBus<SCombatState>.Unsubscribe(HandleCombatState);
    }
    private async void HandleCombatState(SCombatState e)
    {
        NotificationPanel.SetActive(true);
        NotificationPanel.GetComponentInChildren<TextMeshProUGUI>().text = e.Notification;
        await Task.Delay(2000);
        NotificationPanel.SetActive(false);
        if (e.Actor == null) return;
        List<SOSkill> _skill = e.Actor.GetMonsterSkill();
        CombatPanelSkill.InitSkill(_skill, e.State == BattleState.PlayerTurn);
    }
    public async Task PlayAsyncVFX(AnimationClip vfx, Transform target)
    {
        FloatingVFX fv = _poolVFX.Get();
        fv.transform.position = target.position;
        try
        {
            fv.Setup(vfx);
            await fv.WaitForHitFrame();   // chờ theo thời lượng thật
        }
        finally
        {
            _poolVFX.Release(fv);   // luôn trả về pool, kể cả khi bị hủy/lỗi
        }
    }
    public async Task PlayAsyncDialogue(string dialogue, Transform target)
    {
        FloatingText ft = _poolText.Get();
        ft.transform.position = target.position;
        try
        {
            ft.Setup(dialogue);
            await ft.WaitForHitFrame();   // chờ theo thời lượng thật
        }
        finally
        {
            _poolText.Release(ft);   // luôn trả về pool, kể cả khi bị hủy/lỗi
        }
    }
}