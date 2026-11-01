using UnityEngine.UI;
using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Threading.Tasks;

public class EffectEntry
{
    public readonly EffectContext _effect;
    public int _turnsRemaining;
    public EffectEntry(EffectContext effect, int turnsRemaining)
    {
        _effect = effect;
        _turnsRemaining = turnsRemaining;
    }
}
public class CombatSlotMonster : MonoBehaviour, ICombatMonster
{
    [SerializeField] private SpriteRenderer Image;
    [SerializeField] private Button Button;
    [SerializeField] private GameObject TargetActive;
    [SerializeField] private Animator Animator;
    public MonsterStats Stats { get; private set; }
    private readonly List<EffectEntry> _activeEffects = new();
    public IReadOnlyList<EffectEntry> ActiveEffects => _activeEffects;
    public bool IsSelected { get; set; }
    public bool IsPlayerMonster;
    public event Action<CombatSlotMonster> OnMonsterClick;
    public event Action<EffectContext, ActionState> OnEffectStatusChange;
    public event Action<bool> IsAnimationDone;
    private TaskCompletionSource<bool> _tcs;
    public float GetMonsterSpeed() => Stats.Speed;
    public List<SOSkill> GetMonsterSkill() => Stats.Monster.Skills.Count > 0 ? Stats.Monster.Skills : null;
    public void Setup(MonsterStats _stats, bool _isPlayerMonster)
    {
        if (_stats == null) return;

        Stats = _stats;
        IsPlayerMonster = _isPlayerMonster;
        if (Image != null)
        {
            Image.sprite = _isPlayerMonster == false ? Stats.Monster.FrontImage : Stats.Monster.BackImage;
        }

        if (Button != null)
        {
            Button.onClick.RemoveAllListeners();
            Button.onClick.AddListener(() => OnMonsterClick?.Invoke(this));
        }

        Animator.runtimeAnimatorController = Stats.Monster.AnimatorOverrideRef;
        if (_isPlayerMonster == true)
        {
            Animator.SetFloat("IsPlayerParty", 1);
            gameObject.transform.localScale = new Vector3(2, 2, 0);
        }
    }
    public void SetTargetActive(bool value) => TargetActive.SetActive(value);
    public void OnAnimationEnd(bool result) => _tcs?.TrySetResult(result);
    public async Task WaitForHitFrame(string animator)
    {
        _tcs = new TaskCompletionSource<bool>();

        Animator.SetTrigger(animator);
        await Task.WhenAny(_tcs.Task, Task.Delay(TimeSpan.FromSeconds(3000)));
    }
    public void AddEffect(EffectContext e)
    {
        var existing = _activeEffects.Find(x => x._effect.Effect.EffectId == e.Effect.EffectId);
        if (existing != null)
        {
            existing._turnsRemaining = e.payload is DPTPayload p ? p.duration : 0;
        }
        else
        {
            var newEffect = new EffectEntry(e, e.payload is DPTPayload p ? p.duration : 0);
            _activeEffects.Add(newEffect);
            OnEffectStatusChange?.Invoke(newEffect._effect, ActionState.Add);
        }
    }
    public void CheckEffectDuration(EffectContext e)
    {
        var existing = _activeEffects.Find(x => x._effect.Effect.EffectId == e.Effect.EffectId);
        if (existing != null)
        {
            existing._turnsRemaining--;
            if (existing._turnsRemaining <= 0)
            {
                _activeEffects.Remove(existing);
                OnEffectStatusChange?.Invoke(existing._effect, ActionState.Remove);
            }
        }
    }
    private void OnDestroy()
    {

    }

}
