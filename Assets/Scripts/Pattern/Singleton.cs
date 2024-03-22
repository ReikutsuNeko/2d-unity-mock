using UnityEngine;

namespace DesignPatterns.Singleton
{

    public class Singleton<T> : MonoBehaviour where T : Component
    {
        private static T _instance;
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = (T)FindObjectOfType(typeof(T));

                    if (_instance == null)
                    {
                        SetupInstance();
                    }
                    else
                    {
                        Debug.Log("[Singleton] " + typeof(T).Name + " instance already created: " + _instance.gameObject.name + "\n");
                    }
                }

                return _instance;
            }
        }

        public virtual void Awake()
        {
            RemoveDuplicates();

        }

        private static void SetupInstance()
        {
            // lazy instantiation
            _instance = (T)FindObjectOfType(typeof(T));

            if (_instance == null)
            {
                GameObject gameObj = new GameObject();
                gameObj.name = typeof(T).Name;

                _instance = gameObj.AddComponent<T>();
                DontDestroyOnLoad(gameObj);
            }
        }

        private void RemoveDuplicates()
        {
            if (_instance == null)
            {
                _instance = this as T;
                DontDestroyOnLoad(gameObject.transform.root);
            }
            else if (_instance != null && _instance != this)
            {
                Debug.Log("[Singleton] " + typeof(T).Name + " duplicate found!! Destroying: " + _instance.gameObject.name + "\n");
                
                Destroy(gameObject);
            }
        }
    }
}