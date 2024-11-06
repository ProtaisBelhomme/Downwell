using NaughtyAttributes;
using UnityEngine;

/// <summary>
/// Make a class a singleton, this will make sure that only one instance of the class exists.
/// It don't persist between scenes, if you want to persist between scenes use PersistantSingleton
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class Singleton<T> : MonoBehaviour where T : Component
{
    public static T Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<T>();

            return instance;
        }
    }
    private static T instance;

    protected virtual void Awake()
    {
        if (instance == null)
            instance = this as T;
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }
    protected virtual void OnDestroy()
    {
        if (instance == this)
            instance = null;
    }
}
