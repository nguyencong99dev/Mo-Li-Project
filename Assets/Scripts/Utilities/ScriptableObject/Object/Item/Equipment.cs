using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment Item", menuName = "Item/Equipment")]
public class Equipment : SOItem
{
    public bool CanUse(MonsterStats stats, bool isPlayerMonster)
    {
        return false;
    }
    public void Use(MonsterStats stats)
    {

    }
}