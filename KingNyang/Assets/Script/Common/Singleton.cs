using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T m_instance;

    public static T instance()
    {
        if (m_instance == null)
            m_instance = (T)FindObjectOfType(typeof(T));
        return m_instance;
    }
}
