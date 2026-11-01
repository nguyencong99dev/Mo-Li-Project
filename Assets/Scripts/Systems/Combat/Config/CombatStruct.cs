using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

public struct SBattleContext
{
    public ActionType Action;
    public CombatSlotMonster Actor;
    public CombatSlotMonster Target;
    public CombatSlotItem Item;
    public SOSkill Skill;
    public bool Confirm;
    public FloatingText Dialogue;
    public FloatingVFX Vfx;
    public ActionQueue Queue;

    // public CombatUIManager CombatUIManager;
}
public struct SCombatState
{
    public BattleState State;
    public CombatSlotMonster Actor;
    public string Notification;
}

public interface ICombatMonster
{
    public MonsterStats Stats { get; }
    public event Action<bool> IsAnimationDone;
    public Task WaitForHitFrame(string animator);
    public void OnAnimationEnd(bool value);
}
public interface ICombatAction
{    
    public Task ExecuteAsync(SBattleContext ctx);
}