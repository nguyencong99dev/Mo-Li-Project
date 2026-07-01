using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "New Database Item", menuName = "Inventory/DatabaseInventory")]
public class DatabaseItem : ScriptableObject
{
     public List<DataItem> allInventory;

    public DataItem GetById(string id) 
        => allInventory.Find(m => m.Id == id);

}
