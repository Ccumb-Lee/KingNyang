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

            m_hp -= 1;

           



            if (this.tag == "HATE")
            {
                m_cat.Stun();
            }
            else if(this.tag == "LIKE")
            {
                m_cat.Happy();
            }
            else if (this.tag == "BOX")
            {
                //m_cat.Happy();
                DoSomething();
            }
            else
            {
                //m_cat.Happy();
                
            }

            if (m_hp <= 0)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
    
    protected void DoSomething()
    {
        int random = Random.Range(0, 100);

        if(random > 25)
        {
            m_cat.ScreenHuddle();
        }
        else if (random > 50)
        {
            // ½ÅµµÈ­
            m_cat.ScreenHuddle();
        }
        else if (random > 75)
        {
            m_cat.Happy();
        }
        else
        {

        }
    }
}
