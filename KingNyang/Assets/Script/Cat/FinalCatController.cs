using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class FinalCatController : MonoBehaviour
{
    [SerializeField]
    PhotonView m_pv;

    [SerializeField]
    Animator m_anim;

    bool m_isMoving;

    public void Init()
    {

    }

    private void Update()
    {
        if (!m_pv.IsMine)
            return;

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.F))
        {
            Punch();
        }
        
    }

    void Punch()
    {
        if (m_isMoving)
            return;

        m_anim.SetBool("isAttack", true);
        m_isMoving = true;
        StartCoroutine(Move_Origin());
    }

    IEnumerator Move_Origin()
    {
        yield return new WaitForSeconds(0.25f);

        m_isMoving = false;
    }
}
