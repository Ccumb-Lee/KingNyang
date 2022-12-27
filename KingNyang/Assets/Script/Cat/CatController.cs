using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 캐릭터 컴포넌트
/// </summary>
public class CatController : MonoBehaviour
{
    [SerializeField]
    CatArmController m_catController;
    bool m_canMove;

    private void Start()
    {
        m_canMove = true;
    }
    private void Update()
    {
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
