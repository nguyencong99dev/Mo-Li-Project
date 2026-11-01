using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable Item", menuName = "Item/Consumable")]
public class Consumables : SOItem, IConsumable<EffectContext>
{
    [SerializeReference] List<EffectContext> _effects;
    public bool CanUse(MonsterStats target, EffectContext context)
    {
        return false;
    }
    public void Use(MonsterStats target, EffectContext context)
    {
        
    }
}