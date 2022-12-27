using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    protected CatController m_cat;
    private int m_hp;

    public virtual void Init_Obstacle(int _hp)
    {
        m_hp = _hp;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            m_cat = other.GetComponentInParent<CatController>();
            if (this.tag != "HATE")
            {
                m_hp -= 1;

                if (m_hp <= 0)
                {

                   
                    this.gameObject.SetActive(false);
                }
            }
            else
            {
                DoSomething();
            }
        }
    }
    
    protected virtual void DoSomething()
    {

    }
}
