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


    [SerializeField]
    AudioSource m_audio;
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
        m_audio.clip = CatInfoController.instance().Get_Sound(m_type);
    }

    public void Set_Costume(int[] _costumeData)
    {
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
        m_audio.Play();
         m_isMoving = true;
        StartCoroutine(Move_Origin());
    }

  //  [PunRPC]
    public void Move_Left2()
    {
        if (m_isMoving)
            return;

        TurnOff_Collider();
        m_audio.Play();
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
        m_audio.Play();
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
        m_audio.Play();
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
