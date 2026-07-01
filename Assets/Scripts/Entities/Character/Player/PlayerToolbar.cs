using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerToolbar : MonoBehaviour
{
    [SerializeField] private List<string> _Toolbar;
    public event Action<List<string>> OnToolbarChanged;
    void Start()
    {

    }
    public void AddItem(DataItem item)
    {
        if (item != null)
        {
            _Toolbar.Add(item.Id);
            OnToolbarChanged?.Invoke(_Toolbar);
        }
    }
    public void RemoveItem(DataItem item)
    {
        // Debug.Log("Remove " + item.NameDisplay);
    }
    public List<string> GetToolbarItems()
    {
        return _Toolbar;
    }
    public void SetToolbar(List<string> toolbar)
    {
        if (toolbar == null) return;
        _Toolbar = toolbar;
    }
}
