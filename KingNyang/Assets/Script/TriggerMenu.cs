using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMenu : MonoBehaviour
{
    public delegate void Func();
    Func m_func;

    public void Set_Func(Func _func)
    {
        m_func = _func;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
            m_func?.Invoke();
    }
}
