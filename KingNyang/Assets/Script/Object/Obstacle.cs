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

            int endRand = Random.Range(0, 100);



            if (this.tag == "HATE")
            {
                m_cat.Stun();

                if(endRand < 33)
                {
                    GameManager.instance().See_Ending(EndingController.KIND.bad_3);
                }
            }
            else if(this.tag == "LIKE")
            {
                m_cat.Happy();

                if (endRand < 33)
                {
                    GameManager.instance().See_Ending(EndingController.KIND.bad_2);
                }
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
                m_cat.Create_Particle(this.transform.position);
                this.gameObject.SetActive(false);


                m_cat.Owner.CheckAndNext();
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
            GameManager.instance().See_Ending(EndingController.KIND.bad_1);
            // �ŵ�ȭ
            //m_cat.ScreenHuddle();
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
