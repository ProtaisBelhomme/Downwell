using UnityEngine;
using UnityEngine.Pool;
using System.Collections;
using System.Collections.Generic;

public class Overview_Pooling : MonoBehaviour
{
    #region Pooling declaration
    public void CreateObjectPool(GameObject prefab)
    {
        ObjectPool<GameObject> objectPool = new ObjectPool<GameObject>(
            createFunc: () => Instantiate(prefab),
            actionOnGet: (obj) => OnPoolObjectInitialisation(obj),
            actionOnRelease: (obj) => OnPoolObjectDiscard(obj),
            actionOnDestroy: (obj) => DestroyGameObject(obj)
        );
    }

    // Method called when getting an object from the pool
    private void OnPoolObjectInitialisation(GameObject obj)
    {
        obj.SetActive(true);
    }
    // Method called when releasing an object back to the pool
    private void OnPoolObjectDiscard(GameObject obj)
    {
        obj.SetActive(false);
    }
    public void DestroyGameObject(GameObject gameObject)
    {
        Destroy(gameObject);
    }
    #endregion

    #region Usage example
    // Object pool variable
    private ObjectPool<GameObject> _objectPool;
    public GameObject GetObjectFromPool()
    {
        return _objectPool.Get();
    }
    public void ReturnObjectToPool(GameObject gameObject)
    {
        _objectPool.Release(gameObject);
    }
    #endregion
}
