using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CombatDataManager : MonoBehaviour
{
    [SerializeField] CombatInventory CombatInventory;
    [SerializeField] CombatParty CombatPlayerParty;
    [SerializeField] CombatParty CombatEnemyParty;
    public List<CombatSlotMonster> PlayerParty = new();
    public List<CombatSlotMonster> EnemyParty = new();
    public List<CombatSlotMonster> TurnOrder = new();
    async void Awake()
    {
        EventBus<SPlayerParty>.Subscribe(InitPlayerParty);
        EventBus<SEncounterMonster>.Subscribe(InitEnemyParty);
        EventBus<SInventory>.Subscribe(CombatInventory.InitInventoryItem);
        TurnOrder = ArrangeTurn();
    }
    void OnDestroy()
    {
        EventBus<SPlayerParty>.Unsubscribe(InitPlayerParty);
        EventBus<SEncounterMonster>.Unsubscribe(InitEnemyParty);
        EventBus<SInventory>.Unsubscribe(CombatInventory.InitInventoryItem);
    }
    public void InitPlayerParty(SPlayerParty data)
    {
        PlayerParty.Clear();
        PlayerParty = CombatPlayerParty.InitParty(data.Party, true);
    }
    public void InitEnemyParty(SEncounterMonster data)
    {
        EnemyParty.Clear();
        EnemyParty = CombatEnemyParty.InitParty(data.Party, false);
    }
    public List<CombatSlotMonster> ArrangeTurn()
    {
        List<CombatSlotMonster> allMonsters = new()
        {
            PlayerParty[0],
            EnemyParty[0]
        };
        
        // Change this to less complex logic for turn order, this is just a placeholder
        List<CombatSlotMonster> turnOrder = allMonsters
            .OrderBy(m => m.GetMonsterSpeed())
            .ToList();

        return turnOrder;
    }
}