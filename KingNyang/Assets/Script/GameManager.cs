using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    const float m_gameTime = 60.0f;
    float m_time;

    bool m_isGameStart;

    [SerializeField]
    TextMeshProUGUI m_timeText;

    [SerializeField]
    Slider m_scoreSlider;

    GameController[] m_controllers;

    GameController m_myController;
    GameController m_otherController;

    int m_playerCount = 0;

    bool m_isSingle;
    bool m_useServer = false;
    bool m_isInit = false;

    private void Start()
    {
        if(this.GetComponentInChildren<PhotonInit>() == null)
        {
            InitAndStart_Game();
        }
        else
        {
            m_useServer = true;
        }
    }
    public void Set_PlayerCount(GameController _controller)
    {
        if (!m_useServer)
            return;

        m_playerCount++;

        if (m_playerCount >= 2)
            _controller.transform.position += new Vector3(10.0f, 0.0f, 0.0f);

        Start_Game();

        //Debug.Log(m_playerCount);
    }

    void Start_Game()
    {
        if (m_playerCount >= 2)
        {
            GameManager.instance().InitAndStart_Game();
        }
    }

    public void InitAndStart_Game()
    {
        m_isGameStart = false;
        m_controllers = FindObjectsOfType<GameController>();

        m_isInit = true;

        m_time = m_gameTime;

        Init_Game();

        Set_Text();

        m_timeText.gameObject.SetActive(true);
        m_scoreSlider.gameObject.SetActive(true);

        StartCoroutine(Start_Game_Cor());
    }

    IEnumerator Start_Game_Cor()
    {
        yield return new WaitForSeconds(1.0f);

        m_isGameStart = true;

        for (int i = 0; i < m_controllers.Length; i++)
        {
            m_controllers[i].Start_Game();
        }
    }

    private void Update()
    {
        if(m_isGameStart)
        {
            m_time -= Time.deltaTime;

            Set_Text();

            if(m_time <= 0)
            {
                End_Game();
            }
        }
    }

    public void End_Game()
    {
        for (int i = 0; i < m_controllers.Length; i++)
        {
            m_controllers[i].End_Game();
        }

        m_isGameStart = false;
    }

    public void Set_Slider(float _current, float _total)
    {
        m_scoreSlider.value = _current / _total;
    }

    public void Select_Mine()
    {
        for(int i = 0; i < m_controllers.Length; i++)
        {
            if(m_controllers[i].IsMine)
            {
                m_myController = m_controllers[i];
            }
            else
            {
                m_otherController = m_controllers[i];
            }
        }
    }

    public void Update_Slider()
    {
        if (m_isSingle || !m_isInit)
            return;

        Set_Slider_Compare(m_myController.Score, m_otherController.Score);
    }

    void Set_Slider_Compare(float _myScore, float _otherScore)
    {
        if(_myScore == _otherScore)
        {
            m_scoreSlider.value = 0.5f;
        }
        else
        {
            float total = _myScore + _otherScore;

            m_scoreSlider.value = ((_myScore / total));

        }
    }

    void Init_Game()
    {
        for (int i = 0; i < m_controllers.Length; i++)
        {
            m_controllers[i].Init();
        }

        if (m_controllers.Length < 2)
        {
            m_isSingle = true;
            m_controllers[0].Set_TargetScore();
        }
        else
        {
            m_isSingle = false;
            Select_Mine();
            Update_Slider();
        }    
    }

    void Set_Text()
    {
        if (m_time <= 0)
            m_time = 0.0f;

        m_timeText.text = ((int)m_time).ToString();
    }
}
