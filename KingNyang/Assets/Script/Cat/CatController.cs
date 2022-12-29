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
    CatAnimController m_catController;
    bool m_canMove;


    [SerializeField]
    PhotonView m_pv;


    [SerializeField]
    GameObject m_particle;

    public void Init()
    {
        m_canMove = false;
        m_owner = this.GetComponent<GameController>();
        m_catController.Init(this);

       // if (m_pv.IsMine)
      
    }


    private void Update()
    {
        if (!m_pv.IsMine)
            return;

        if (!m_canMove)
            return;

        if(Input.GetKeyDown(KeyCode.A))
        {
            m_catController.Move_Left1();

        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            m_catController.Move_Left2();

        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            m_catController.Move_Right2();
            
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            m_catController.Move_Right1();
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

    public void Set_Material(int _num)
    {
        m_catController.Set_Material(_num);
    }

    public void Set_Costume(int[] _costume)
    {
        if (_costume == null)
            return;

        m_catController.Set_Costume(_costume);
    }
    public void Create_Particle(Vector3 _pos)
    {
        Instantiate(m_particle, _pos, Quaternion.identity);
    }

    public void Stun()
    {
        m_catController.Set_Hate(true);
        Set_CantMove();
        StartCoroutine(Stun_Cor());
    }

    public void Happy()
    {
        m_catController.Set_Happy(true);
        //Set_CantMove();
        StartCoroutine(Happy_Cor());
    }


    IEnumerator Stun_Cor()
    {
        yield return new WaitForSecondsRealtime(2.0f);

        Set_CanMove();
        m_catController.Set_Hate(false);

    }

    IEnumerator Happy_Cor()
    {
        yield return new WaitForSecondsRealtime(1.5f);

        //Set_CanMove();
        m_catController.Set_Happy(false);

    }

    public void ScreenHuddle()
    {
        if (!m_pv.IsMine)
            return;

        GameManager.instance().SetActive_Huddle(true);

        StartCoroutine(ScreenHuddle_Cor());
    }

    IEnumerator ScreenHuddle_Cor()
    {
        yield return new WaitForSecondsRealtime(6.0f);

        //Set_CanMove();
        GameManager.instance().SetActive_Huddle(false);

    }
}
