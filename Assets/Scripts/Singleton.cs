using UnityEngine;

public class Singleton<Type> : MonoBehaviour where Type : MonoBehaviour
{
    private static Type _instance;
    public static Type Instance
    {

        private set { _instance = value; }
        get
        {
            if (_instance == null)
            {
                _instance = FindFirstObjectByType<Type>();
            }
            return _instance;
        }
    }


}

