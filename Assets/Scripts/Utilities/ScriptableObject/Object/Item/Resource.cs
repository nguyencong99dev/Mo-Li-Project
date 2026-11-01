using UnityEngine;

[CreateAssetMenu(fileName = "New Resource Item",menuName = "Item/Resource")]
public class Resource : SOItem
{
    public bool CanUse(MonsterStats stats, bool isPlayerMonster)
    {
        return false;
    }
    public  void Use(MonsterStats stats, bool isPlayerMonster)
    {
        
    }
}