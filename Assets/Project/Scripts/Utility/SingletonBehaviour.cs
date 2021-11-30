using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public abstract class SingletonBehaviour<T> : MonoBehaviour
    where T : MonoBehaviour
{
    protected static T m_instance = null;

    public static T Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = (T)FindObjectOfType(typeof(T));

                if (m_instance == null)
                {
                    var instanceName = "__" + typeof(T).ToString();
                    var go = new GameObject(instanceName);
                    m_instance = go.AddComponent<T>();
                    DontDestroyOnLoad(go);
                }
            }

            return m_instance;
        }
    }


    public void SetToDestroyOnLoad()
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        try
        {
            Destroy(gameObject);
        }
        catch
        {
        }
    }

    private void OnDestroy()
    {
        m_instance = null;
    }

    void OnApplicationQuit()
    {
        m_instance = null;
    }
}