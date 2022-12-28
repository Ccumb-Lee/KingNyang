using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class CatAnimController : MonoBehaviour
{

    CatInfoController.CAT_TYPE m_type;

    CatController m_owner;

    [SerializeField]
    Animator m_anim;

    [SerializeField]
    SkinnedMeshRenderer m_mesh;

    [SerializeField]
    BoxCollider m_leftArm;
    //Vector3 m_leftOriginPos;

    [SerializeField]
    BoxCollider m_rightArm;
    //Vector3 m_rightOriginPos;

    //float m_y = 3.87f;
    //float m_z = -8.03f;

    bool m_isMoving;


    public void Init(CatController _owner)
    {
        m_owner = _owner;

        m_isMoving = false;

       
    }

    public void Set_Material(int _num)
    {
        m_type = (CatInfoController.CAT_TYPE)_num;//CatInfoController.instance().Type;
        m_mesh.material = CatInfoController.instance().Get_Material(m_type);
    }

    public void Set_Hate(bool _isActive)
    {
        m_anim.SetBool("isHate", _isActive);

        if (_isActive)
        {
            m_mesh.SetBlendShapeWeight(1, 100);
        }
        else
        {
            m_mesh.SetBlendShapeWeight(1, 0);
        }

    }

    public void Set_Happy(bool _isActive)
    {
        //m_anim.SetBool("isHate", _isActive);
        

        if (_isActive)
        {
            m_mesh.SetBlendShapeWeight(0, 100);
        }
        else
        {
            m_mesh.SetBlendShapeWeight(0, 0);
        }
    }



    // [PunRPC]
    public void Move_Left1()
    {
        if (m_isMoving)
            return;

        TurnOff_Collider();

        m_anim.SetBool("right_02", true);
       
        m_isMoving = true;
        StartCoroutine(Move_Origin());
    }

  //  [PunRPC]
    public void Move_Left2()
    {
        if (m_isMoving)
            return;

        TurnOff_Collider();

        m_anim.SetBool("right_01", true);
        m_isMoving = true;
        StartCoroutine(Move_Origin());
    }

  //  [PunRPC]
    public void Move_Right1()
    {
        if (m_isMoving)
            return;

        TurnOff_Collider();

        m_anim.SetBool("left_02", true);
        m_isMoving = true;
        StartCoroutine(Move_Origin());
    }

 //   [PunRPC]
    public void Move_Right2()
    {
        if (m_isMoving)
            return;

        TurnOff_Collider();

        m_anim.SetBool("left_01", true);
        m_isMoving = true;
        StartCoroutine(Move_Origin());
    }

    public void TurnOn_Collider()
    {
        m_leftArm.enabled = true;
        m_rightArm.enabled = true;
    }

    public void TurnOff_Collider()
    {
        m_leftArm.enabled = false;
        m_rightArm.enabled = false;
    }

   // [PunRPC]
    IEnumerator Move_Origin()
    {
        yield return new WaitForSeconds(0.25f);

        m_anim.SetBool("right_01", false);
        m_anim.SetBool("right_02", false);
        m_anim.SetBool("left_02", false);
        m_anim.SetBool("left_01", false);

        if (m_owner.Owner != null)
            m_owner.Owner.CheckAndNext();

        

        m_isMoving = false;
    }
}
