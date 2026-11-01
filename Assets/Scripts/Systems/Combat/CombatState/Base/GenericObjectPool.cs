using UnityEngine;
using UnityEngine.Pool;

public interface IPoolable
{
    // Hàm được gọi ngay khi lấy object ra khỏi Pool
    void OnSpawn();
    // Hàm được gọi khi trả object về Pool
    void OnDespawn();
}

public class GenericObjectPool<T> where T : Component
{
    private readonly T _prefab;
    private readonly Transform _parent;
    private readonly ObjectPool<T> _pool;

    // Constructor: Truyền vào Prefab và vị trí chứa (Parent) của Pool đó
    public GenericObjectPool(T prefab, Transform parent, int defaultCapacity = 10, int maxSize = 50)
    {
        _prefab = prefab;
        _parent = parent;

        _pool = new ObjectPool<T>(
            createFunc: CreateItem,
            actionOnGet: OnGet,
            actionOnRelease: OnRelease,
            actionOnDestroy: OnDestroyItem,
            collectionCheck: true,
            defaultCapacity: defaultCapacity,
            maxSize: maxSize
        );
    }

    private T CreateItem()
    {
        T instance = Object.Instantiate(_prefab, _parent);
        instance.gameObject.SetActive(false);
        return instance;
    }

    private void OnGet(T item)
    {
        item.gameObject.SetActive(true);
        
        // Nếu component có kế thừa IPoolable thì tự gọi hàm OnSpawn
        if (item is IPoolable poolable) poolable.OnSpawn();
    }

    private void OnRelease(T item)
    {
        // Nếu component có kế thừa IPoolable thì tự gọi hàm OnDespawn
        if (item is IPoolable poolable) poolable.OnDespawn();

        item.gameObject.SetActive(false);
    }

    private void OnDestroyItem(T item)
    {
        Object.Destroy(item.gameObject);
    }
    
    // Các hàm Helper để bên ngoài gọi
    public T Get() => _pool.Get();
    public void Release(T item) => _pool.Release(item);
}
