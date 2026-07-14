using System.Collections.Generic;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine;

public class BuildSlotCombatMonster : MonoBehaviour
{
    [SerializeField] SlotMonster monsterSlot;
    [SerializeField] Transform PlayerSide;
    [SerializeField] Transform EnemySide;
    public List<MonsterStats> PlayerParty;
    public List<MonsterStats> EnemyParty;
    void OnEnable()
    {
        EventBus<SPlayerParty>.Subscribe(InitPlayerParty);
        EventBus<SEncounterMonster>.Subscribe(InitEnemyParty);
    }
    void OnDisable()
    {
        EventBus<SPlayerParty>.Unsubscribe(InitPlayerParty);
        EventBus<SEncounterMonster>.Unsubscribe(InitEnemyParty);
    }
    public void InitPlayerParty(SPlayerParty data)
    {
        foreach (MonsterData member in data._Party)
        {
            int idx = data._Party.IndexOf(member);
            Transform MonsterPostion = PlayerSide.GetChild(idx);
            MonsterStats monsterStats = MonsterPostion.AddComponent<MonsterStats>();
            monsterStats.SetMonsterStats(member);
            SlotMonster _slotMonster = Instantiate(monsterSlot, MonsterPostion);
            _slotMonster.SetMonterStats(monsterStats, true);
            PlayerParty.Add(monsterStats);
        }
    }
    public void InitEnemyParty(SEncounterMonster data)
    {
        foreach (MonsterData monster in data._Party)
        {
            int idx = data._Party.IndexOf(monster);
            Transform MonsterPostion = EnemySide.GetChild(idx);
            MonsterStats monsterStats = MonsterPostion.AddComponent<MonsterStats>();
            monsterStats.SetMonsterStats(monster);
            SlotMonster _slotMonster = Instantiate(monsterSlot, MonsterPostion);
            _slotMonster.SetMonterStats(monsterStats, false);
            EnemyParty.Add(monsterStats);
        }
    }
}