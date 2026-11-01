using UnityEngine;

[CreateAssetMenu(fileName = "New Tool Item", menuName = "Item/Tool")]
public class Tool : SOItem
{
    public bool CanUse(MonsterStats stats, bool isPlayerMonster)
    {
        return false;
    }
    public void Use(MonsterStats stats, bool isPlayerMonster)
    {

    }
}