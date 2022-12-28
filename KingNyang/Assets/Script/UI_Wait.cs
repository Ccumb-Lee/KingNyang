using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Wait : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI m_other;

    [SerializeField]
    TextMeshProUGUI m_me;

    GameController m_myController;
    GameController m_otherController;

    bool m_needCheck = true;
    public void Init_MyControllers(GameController _controller)
    {
        m_myController = _controller;
        Update_Controllers();
    }

    public void Init_OtherControllers(GameController _controller)
    {
        m_otherController = _controller;
        Update_Controllers();
    }

    public void Update_Controllers()
    {
        if (!m_needCheck)
            return;

        if (m_myController == null || m_otherController == null)
            return;

        if(m_myController.IsReady)
        {
            m_me.text = "준비완료다냥!";
        }
        else
        {
            m_me.text = "준비됐냥?";
        }


        if (m_otherController.IsReady)
        {
            m_other.text = "준비완료다냥!";
        }
        else
        {
            m_other.text = "준비됐냥?";
        }

        if(m_myController.IsReady && m_otherController.IsReady)
        {
            m_needCheck = false;
           
            GameManager.instance().Start_MultiGame();
            //this.gameObject.SetActive(false);
        }
    }

    public void OnClick()
    {
        if (!m_needCheck)
            return;

        if (m_myController != null && m_otherController != null)
            m_myController.IsReady = !m_myController.IsReady;

        Update_Controllers();
    }

    private void OnDisable()
    {
        
    }
}
