using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>, new()
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null) 
            {
                _instance = new GameObject("Singleton", typeof(T)) as T; //create an instance if there isn't one already
            }
            return _instance;
        }
    }

    protected virtual void Awake()
    {
        if(Instance == null) //if the object doesn't exist
        {
            _instance = this as T; //set the singleton instance to this object
            DontDestroyOnLoad(gameObject); //set this object to persist between scenes
        }
        else //but if one already exists
        {
            Destroy(gameObject); //destroy this object
        }
    }

}
