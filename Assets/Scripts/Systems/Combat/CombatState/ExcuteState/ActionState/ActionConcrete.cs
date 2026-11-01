using System;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayAnimationAction : ICombatAction
{
    private readonly SOSkill _skill;
    private readonly ICombatMonster _actorMonster;
    public PlayAnimationAction(ICombatMonster actor, SOSkill skill)
    {
        _actorMonster = actor;
        _skill = skill;
    }

    public async Task ExecuteAsync(SBattleContext ctx)
    {
        var _animName = "";
        if (_skill.skillType == SkillType.Attack) _animName = "Attack";
        else _animName = "UseSkill";

        await _actorMonster.WaitForHitFrame(_animName);
        await Task.CompletedTask;
    }
}

public class SpawnVFXAction : ICombatAction
{
    private readonly AnimationClip _vfx;
    private readonly Transform _position;
    public SpawnVFXAction(AnimationClip vfx, Transform position)
    {
        _vfx = vfx;
        _position = position;
    }

    public async Task ExecuteAsync(SBattleContext ctx)
    {
        await CombatUIManager.Instance.PlayAsyncVFX(_vfx, _position);
        await Task.CompletedTask;
    }
}

public class SpawnDialogueAction : ICombatAction
{
    private readonly string _dialogue;
    private readonly Transform _position;
    public SpawnDialogueAction(string dialogue, Transform position)
    {
        _dialogue = dialogue;
        _position = position;
    }

    public async Task ExecuteAsync(SBattleContext ctx)
    {
        await CombatUIManager.Instance.PlayAsyncDialogue(_dialogue, _position);
        await Task.CompletedTask;
    }
}
public class ApplyEffectAction : ICombatAction
{
    private readonly ICombatMonster _target;
    private readonly EffectContext _effect;
    private readonly ActionState _state;
    public ApplyEffectAction(ICombatMonster target, EffectContext effect, ActionState state)
    { _target = target; _effect = effect; _state = state; }

    public async Task ExecuteAsync(SBattleContext ctx)
    {
        CombatSlotMonster monster = (CombatSlotMonster)(_target ?? null);
        if (_state == ActionState.Add)
        {
            monster.AddEffect(_effect);     // lúc này mới bắn OnAdded -> hiện icon
        }
        else if (_state == ActionState.Remove)
        {
            monster.CheckEffectDuration(_effect); // lúc này mới bắn OnRemoved -> xóa icon
        }
        await Task.CompletedTask;
    }
}
public class UseSkillAction : ICombatAction
{
    private readonly ICombatMonster _actor;
    private readonly SOSkill _skill;
    public UseSkillAction(ICombatMonster actor, SOSkill skill)
    { _actor = actor; _skill = skill; }

    public async Task ExecuteAsync(SBattleContext ctx)
    {
        _actor.Stats.UseSkill(_skill.mpCost);
        await Task.CompletedTask;
    }
}
public class ApplyDamageAction : ICombatAction
{
    private readonly ICombatMonster _actor;
    private readonly ICombatMonster _target;
    private readonly EffectContext _effect;
    public ApplyDamageAction(ICombatMonster actor, ICombatMonster target, EffectContext effect)
    { _actor = actor; _target = target; _effect = effect; }

    public async Task ExecuteAsync(SBattleContext ctx)
    {
        CombatSlotMonster tMonster = (CombatSlotMonster)(_target ?? null);
        float lastHP = tMonster.Stats.CurrentHP;
        _effect.payload.Apply(_actor, _target);
        ctx.Queue.EnqueueFront(new SpawnDialogueAction(Mathf.Abs(lastHP - tMonster.Stats.CurrentHP).ToString(), tMonster.transform));
        await Task.CompletedTask;
    }
}
public class ApplyDamageEffectAction : ICombatAction
{
    private readonly ICombatMonster _actorMonster;
    private readonly ICombatMonster _targetMonster;
    public ApplyDamageEffectAction(ICombatMonster actor, ICombatMonster target)
    {
        _actorMonster = actor;
        _targetMonster = target;
    }

    public async Task ExecuteAsync(SBattleContext ctx)
    {
        CombatSlotMonster tMonster = (CombatSlotMonster)(_targetMonster ?? null);

        await Task.CompletedTask;
    }

}
