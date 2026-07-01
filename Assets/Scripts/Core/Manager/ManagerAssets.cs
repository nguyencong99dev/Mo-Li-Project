using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
public class ManagerAssets : MonoBehaviour
{
    public static ManagerAssets Instance { get; private set; }
    public DatabaseMember Member { get; private set; }
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
    }
    public async Task LoadAllAsync()
    {
        await Addressables.InitializeAsync().Task;
        // Member = await Addressables.LoadAssetAsync<DatabaseMember>("MemberDB").Task; 
        Item = await Addressables.LoadAssetAsync<DatabaseItem>("Assets/Prefab/Item/Tool/ItemDB.asset").Task;
    }
}
