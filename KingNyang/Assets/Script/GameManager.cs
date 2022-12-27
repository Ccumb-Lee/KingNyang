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

    bool m_isSingle;

    private void Start()
    {
        m_isGameStart = false;
        m_controllers = FindObjectsOfType<GameController>();

        m_time = m_gameTime;

        Init_Game();

        Set_Text(); 
        StartCoroutine( Start_Game_Cor());
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

    void Init_Game()
    {
        for (int i = 0; i < m_controllers.Length; i++)
        {
            m_controllers[i].Init();
        }

        if (m_controllers.Length < 2)
            m_controllers[0].Set_TargetScore();
    }

    void Set_Text()
    {
        if (m_time <= 0)
            m_time = 0.0f;

        m_timeText.text = ((int)m_time).ToString();
    }
}
