using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerParty : MonoBehaviour
{
    [SerializeField] List<DataMember> membersParty;
    public static bool isOpenInventory = false;
    public event Action OnInventoryChanged;
    public List<DataMember> GetMembersPartys()
    {
        return membersParty;
    }
}
