using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public struct SPlayerToolbar
{
    public List<string> Toolbar;
}

public class PlayerToolbar : MonoBehaviour
{
    [SerializeField] private List<string> _Toolbar;

    void Start()
    {
        EventBus<SPlayerToolbar>.Publish(new SPlayerToolbar { Toolbar = _Toolbar });
    }
    public void AddItem(DataItem item)
    {
        if (item != null)
        {
            _Toolbar.Add(item.ID);
            EventBus<SPlayerToolbar>.Publish(new SPlayerToolbar { Toolbar = _Toolbar });
        }
    }
    public void RemoveItem(DataItem item)
    {
        // Debug.Log("Remove " + item.NameDisplay);
    }
    public void SetToolbar(List<string> toolbar)
    {
        if (toolbar == null) return;
        _Toolbar = toolbar;
    }

}
