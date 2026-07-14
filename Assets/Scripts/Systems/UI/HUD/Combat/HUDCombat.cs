using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HUDCombat : MonoBehaviour
{
    public static HUDCombat Instance { get; private set; }
    [SerializeField] SlotSkill _slotSkill;
    [SerializeField] Transform _skillPanel;
    public BattleAction action = new BattleAction();
    void OnEnable()
    {
        EventBus<SPlayerTurnEvent>.Subscribe(InitSkill);
        EventBus<SMonsterTarget>.Subscribe(TargetMonster);
    }
    void OnDisable()
    {
        EventBus<SPlayerTurnEvent>.Unsubscribe(InitSkill);
        EventBus<SMonsterTarget>.Unsubscribe(TargetMonster);
    }
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
    }
    void InitSkill(SPlayerTurnEvent data)
    {
        foreach (Transform child in _skillPanel)
        {
            Destroy(child.gameObject);
        }
        List<string> _skills = data.monster.Monster.Skills;
        foreach (string skill in _skills)
        {
            SlotSkill _slotInstance = Instantiate(_slotSkill, _skillPanel);
            DataSkill _skill = _slotInstance.SetSkillValue(skill);
            Button _button = _slotInstance.GetComponent<Button>();
            if (_button != null)
            {
                _button.onClick.AddListener(() => SkillEvent(data.monster, _skill)); ;
            }
        }
    }
    public void SkillEvent(MonsterStats actor, DataSkill skill)
    {
        action.actionType = ActionType.Attack;
        action.actor = actor;
        action.skill = skill;
        CombatManager.Instance.SubmitAction(action);
    }
    public void TargetMonster(SMonsterTarget target)
    {
        action.target = target.target;
        CombatManager.Instance.SubmitAction(action);
    }
}