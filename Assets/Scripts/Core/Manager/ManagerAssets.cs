using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
public class ManagerAssets : MonoBehaviour
{
    public static ManagerAssets Instance { get; private set; }
    public DatabaseMonster MonsterDB { get; private set; }
    public DatabaseItem ItemDB { get; private set; }
    public DatabaseSkill SkillDB { get; private set; }
    private async void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            return;
        }
        await LoadAllAsync();
        Debug.Log("Manager Assets Initialized");
    }
    public async Task LoadAllAsync()
    {
        await Addressables.InitializeAsync().Task;
        await LoadMonsterDB();
        await LoadItemDB();
        await LoadSkillDB();     
    }
    public async Task LoadMonsterDB()
    {
        var _Monster = Addressables.LoadAssetAsync<DatabaseMonster>("MonsterDB");
        await _Monster.Task;
        MonsterDB = _Monster.Result;
        MonsterDB.BuildLookup();
    }
    public async Task LoadItemDB()
    {
        var _Item = Addressables.LoadAssetAsync<DatabaseItem>("ItemDB");
        await _Item.Task;
        ItemDB = _Item.Result;
        ItemDB.BuildLookup();
    }
    public async Task LoadSkillDB()
    {
        var _Skill = Addressables.LoadAssetAsync<DatabaseSkill>("SkillDB");
        await _Skill.Task;                                                      
        SkillDB = _Skill.Result;
        SkillDB.BuildLookup();
    }
}