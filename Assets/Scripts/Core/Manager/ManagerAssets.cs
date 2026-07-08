using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
public class ManagerAssets : MonoBehaviour
{
    public static ManagerAssets Instance { get; private set; }
    public DatabaseMonster Monster { get; private set; }
    public DatabaseItem Item { get; private set; }
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
        var _Monster = Addressables.LoadAssetAsync<DatabaseMonster>("MonsterDB");
        var _Item = Addressables.LoadAssetAsync<DatabaseItem>("ItemDB");
        await Task.WhenAll(_Monster.Task, _Item.Task);
        Monster = _Monster.Result;
        Item = _Item.Result;
        Monster.BuildLookup();
        Item.BuildLookup();
    }
}
