using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

/// <summary>
/// 캐릭터 컴포넌트
/// </summary>
public class CatController : MonoBehaviour
{
    GameController m_owner;
    public GameController Owner
    {
        get
        {
            return m_owner;
        }
    }

    [SerializeField]
    CatArmController m_catController;
    bool m_canMove;


    [SerializeField]
    PhotonView m_pv;

    private void Start()
    {
        m_canMove = true;
    }

    public void Init()
    {
        m_owner = this.GetComponent<GameController>();
        m_catController.Init(this);
    }

    private void Update()
    {
        if (!m_pv.IsMine)
            return;

        if (!m_canMove)
            return;

        if(Input.GetKeyDown(KeyCode.W))
        {
            m_catController.Move_Left1();

        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            m_catController.Move_Left2();

        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            m_catController.Move_Right1();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            m_catController.Move_Right2();
        }
    }

    public void Set_CantMove()
    {
        m_canMove = false;
    }

    public void Set_CanMove()
    {
        m_canMove = true;
    }

}
