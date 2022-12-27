using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public delegate void AllDeadFunc();
    AllDeadFunc m_func;
    private int m_hp;

    public void Init_Obstacle(int _hp, AllDeadFunc _func)
    {
        m_hp = _hp;
        m_func = _func;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (this.tag != "HATE")
            {
                m_hp -= 1;

                if (m_hp <= 0)
                {
                    m_func?.Invoke();
                    Destroy(this.gameObject);
                }
            }
            
        }
    }
    

}
