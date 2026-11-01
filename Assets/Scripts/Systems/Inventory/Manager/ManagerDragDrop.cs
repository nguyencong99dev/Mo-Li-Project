using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
// Bất kỳ slot nào có thể kéo được

public class ManagerDragDrop : MonoBehaviour
{
    public static ManagerDragDrop Instance { get; private set; }
    public SOItem DraggingItem { get; private set; }
    public IDraggable DragSource { get; private set; }
    [SerializeField] GameObject ghostItemPrefab;
    public GameObject _ghostInstance;

    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void BeginDrag(IDraggable source)
    {
        if (source.Item == null) return;
        DragSource = source;
        DraggingItem = source.Item;
        source.OnBeginDrag();

        // Tạo ghost item theo cursor
        _ghostInstance = Instantiate(ghostItemPrefab, transform);
        _ghostInstance.GetComponent<Image>().sprite = DraggingItem.image;
    }
    void Update()
    {
        // Ghost item theo cursor
        if (_ghostInstance != null)
            _ghostInstance.transform.position = Mouse.current.position.ReadValue();
    }
    public void EndDrag(IDropTarget target)
    {
        if (target != null && target.CanAcceptDrop(DraggingItem))
        {
            target.OnItemDropped(DraggingItem);
            DragSource.OnEndDrag();
        }
        // Cleanup
        Destroy(_ghostInstance);
        DraggingItem = null;
        DragSource = null;
    }
}