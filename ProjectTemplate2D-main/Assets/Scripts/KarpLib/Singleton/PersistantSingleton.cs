using UnityEngine;

/// <summary>
/// Make a class a singleton, this will make sure that only one instance of the class exists.
/// It persists between scenes, if you don't want to persist between scenes use Singleton
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class PersistantSingleton<T> : MonoBehaviour where T : Component
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

        // Make sure the instance persists between scenes
        transform.parent = null;
        DontDestroyOnLoad(gameObject);
    }
    protected virtual void OnDestroy()
    {
        if (instance == this)
            instance = null;
    }
}
