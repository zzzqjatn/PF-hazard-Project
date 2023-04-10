using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T Instance;
    public static T instance
    {
        get
        {
            if (Instance == null)
            {
                GameObject obj;
                obj = GameObject.Find(typeof(T).Name);
                if (obj == null)
                {
                    obj = new GameObject(typeof(T).Name);
                    Instance = obj.AddComponent<T>();
                }
                else
                {
                    Instance = obj.GetComponent<T>();
                }
            }
            return Instance;
        }
    }

    private void Awake() {
        
    }
}
