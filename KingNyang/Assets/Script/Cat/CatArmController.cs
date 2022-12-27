using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatArmController : MonoBehaviour
{
    [SerializeField]
    GameObject m_leftArm;
    Vector3 m_leftOriginPos;

    [SerializeField]
    GameObject m_rightArm;
    Vector3 m_rightOriginPos;

    float m_y = 3.87f;
    float m_z = -8.03f;

    bool m_isMoving;


    private void Start()
    {
        m_leftOriginPos = m_leftArm.transform.localPosition;
        m_rightOriginPos = m_rightArm.transform.localPosition;

        m_isMoving = false;
    }


    public void Move_Left1()
    {
        if (m_isMoving)
            return;

        m_leftArm.transform.localPosition = new Vector3(-2.6f, m_y, m_z);
        m_isMoving = true;
        StartCoroutine(Move_Origin());
    }

    public void Move_Left2()
    {
        if (m_isMoving)
            return;
        m_leftArm.transform.localPosition = new Vector3(-1, m_y, m_z);
        m_isMoving = true;
        StartCoroutine(Move_Origin());
    }

    public void Move_Right1()
    {
        if (m_isMoving)
            return;
        m_rightArm.transform.localPosition = new Vector3(1, m_y, m_z);
        m_isMoving = true;
        StartCoroutine(Move_Origin());
    }

    public void Move_Right2()
    {
        if (m_isMoving)
            return;
        m_rightArm.transform.localPosition = new Vector3(2.6f, m_y, m_z);
        m_isMoving = true;
        StartCoroutine(Move_Origin());
    }

    

    IEnumerator Move_Origin()
    {
        yield return new WaitForSeconds(0.3f);

        m_leftArm.transform.localPosition = m_leftOriginPos;
        m_rightArm.transform.localPosition = m_rightOriginPos;

        GameManager.instance().CheckAndNext();

        m_isMoving = false;
    }
}
