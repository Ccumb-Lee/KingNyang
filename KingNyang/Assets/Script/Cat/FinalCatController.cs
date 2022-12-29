using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class FinalCatController : MonoBehaviour
{
    GameController m_controller;

    [SerializeField]
    SkinnedMeshRenderer m_mesh;

    [SerializeField]
    PhotonView m_pv;

    [SerializeField]
    Animator m_anim;

    bool m_isMoving;

    bool m_canMove;

    public void Init(GameController _controller)
    {
        this.gameObject.SetActive(true);

        m_canMove = true;

        if (!m_pv.IsMine)
        {
            this.transform.position = new Vector3(0.5f, 50, 0.0f);
            //this.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        else
        {
            this.transform.position = new Vector3(-0.5f, 50, 0.0f);
           
        }

        m_controller = _controller;
    }

    public void Set_CanMove(bool _canMove)
    {
        m_canMove = _canMove;
    }


    public void Set_Material(int _num)
    {
        m_mesh.material = CatInfoController.instance().Get_Material((CatInfoController.CAT_TYPE)_num);
    }

    public void Set_Costume(int[] _costumeData)
    {
        if (_costumeData == null) return;
        // ¾ó±¼
        if (_costumeData[0] > 0)
            m_mesh.SetBlendShapeWeight(2 + (_costumeData[0] - 1), 100);
        else
        {
            for (int i = 2; i <= 4; i++)
            {
                m_mesh.SetBlendShapeWeight(i, 0);
            }
        }

        if (_costumeData[1] > 0)
            m_mesh.SetBlendShapeWeight(5 + (_costumeData[1] - 1), 100);
        else
        {
            for (int i = 5; i <= 7; i++)
            {
                m_mesh.SetBlendShapeWeight(i, 0);
            }
        }

        if (_costumeData[2] > 0)
            m_mesh.SetBlendShapeWeight(8 + (_costumeData[2] - 1), 100);
        else
        {
            for (int i = 8; i <= 9; i++)
            {
                m_mesh.SetBlendShapeWeight(i, 0);
            }
        }
    }

    private void Update()
    {
        if (!m_canMove)
            return;

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
        m_mesh.SetBlendShapeWeight(0, 100);
        m_mesh.SetBlendShapeWeight(1, 100);
        m_isMoving = true;

        m_controller.Score++;

        StartCoroutine(Move_Origin());
    }

    IEnumerator Move_Origin()
    {
        yield return new WaitForSeconds(0.25f);

        m_anim.SetBool("isAttack", false);
        m_mesh.SetBlendShapeWeight(0, 0);
        m_mesh.SetBlendShapeWeight(1, 0);
        m_isMoving = false;
    }
}
