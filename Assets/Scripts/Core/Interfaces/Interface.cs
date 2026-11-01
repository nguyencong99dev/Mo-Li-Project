using System;
public interface IHasHealth
{
    float CurrentHP { get; }
    float MaxHP { get; }
    event Action<float, float> OnHPChanged;
}
public interface IHasMana
{
    float CurrentMP { get; }
    float MaxMP { get; }
    event Action<float, float> OnMPChanged;
}
public interface IHasStamina
{
    float CurrentSP { get; }
    float MaxSP { get; }
    event Action<float, float> OnSPChanged;
}
public interface IDraggable
{
    SOItem Item { get; }
    // int Qty { get; }
    void OnBeginDrag();
    void OnEndDrag();
}

// Bất kỳ vùng nào có thể thả vào
public interface IDropTarget
{
    bool CanAcceptDrop(SOItem item);  // có chấp nhận item này không
    void OnItemDropped(SOItem item);  // xử lý khi item được thả vào
}
public enum SaveKey
{
    PlayerStats,
    Inventory,
    Party
}
public interface ISaveable
{
    SaveKey _saveKey { get; }        // key duy nhất để lưu vào file
    SaveData ExportSaveData();       // xuất data → string JSON
    void ImportSaveData(SSaveData data);
}