using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMovement : MonoBehaviour
{
    PlanetController m_owner;

    public delegate void EndFunc();
    EndFunc m_endFunc;

    const float m_amount = 21;
    float m_current;
    float m_target;

    [SerializeField]
    float m_speed = 1;

    bool m_startRotate;

    bool m_isInit = false;


    public void Init_Planet(EndFunc _endFunc)
    {
        //this.transform.eulerAngles = new Vector3(0, 0, 0);

        m_owner = this.GetComponentInParent<PlanetController>();
        m_startRotate = false;
        m_isInit = true;

        m_endFunc = _endFunc;
    }

    public void Start_Rotate()
    {
        if (m_startRotate)
            return;

        m_startRotate = true;


        m_current = this.transform.eulerAngles.y;
        m_target = this.transform.eulerAngles.y + m_amount;

        if (m_target >= 180.0f)
        {
            float amount = m_target - 180.0f;

            m_target = -180.0f + amount;
        }

        m_current = 0.0f;



    }

    private void Update()
    {
        if (!m_isInit)
            return;

        if (!m_owner.Owner.IsStart)
            return;

        if (m_startRotate)
        {
            Rotate();
        }
            
    }

    void Rotate()
    {
        float angle = Mathf.Lerp(m_current, m_amount, m_speed);

        if (angle >= m_amount)
        {
            m_startRotate = false;
            m_endFunc?.Invoke();
            return;
        }
            
        m_current = angle;

        float newAngle = 1 - (angle / m_amount);

        this.transform.Rotate(new Vector3(m_amount * newAngle, 0.0f, 0.0f), Space.World);

    }

    public void Rotate_NoAnim()
    {
        this.transform.Rotate(new Vector3(m_amount, 0.0f, 0.0f), Space.World);
    }
}
