using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "New Database Member", menuName = "Character/DatabaseMember")]
public class DatabaseMember : ScriptableObject
{
     public List<DataMember> allMember;

    public DataMember GetById(string id) 
        => allMember.Find(m => m.Id == id);


}
