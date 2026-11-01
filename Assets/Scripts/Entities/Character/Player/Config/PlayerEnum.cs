using System.Collections.Generic;

public struct SPlayerParty
{
    public List<MonsterData> Party;
}
public struct SEncounterMonster
{
    public List<MonsterData> Party;
    public bool IsEncounter;
}
// public struct SInventory
// {
//     public List<ItemData> Inventory;
// }
// public struct SToolbar
// {
//     public List<ItemData> Toolbar;
// }
public struct SPlayerStats
{
    public PlayerStats player;
}
