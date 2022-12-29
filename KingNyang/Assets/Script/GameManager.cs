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
    TextMeshProUGUI m_startText;

    [SerializeField]
    Slider m_scoreSlider;


    [SerializeField]
    UI_Wait m_wait;

    [SerializeField]
    GameObject m_screenHuddle;

    [SerializeField]
    EndingController m_endingController;
   
    GameController[] m_controllers;

    GameController m_myController;
    GameController m_otherController;

    int m_playerCount = 0;

    bool m_isSingle;
    bool m_useServer = false;
    bool m_isInit = false;

    [SerializeField]
    SubCamComponent m_subCam;
    public SubCamComponent SubCam
    {
        get
        {
            return m_subCam;
        }
    }

    private void Start()
    {
        m_startText.gameObject.SetActive(false);
        if (this.GetComponentInChildren<PhotonInit>() == null)
        {
            
            InitAndStart_Game();
        }
        else
        {
            m_useServer = true;
            m_timeText.gameObject.SetActive(false);
        }
    }
    public void Set_PlayerCount(GameController _controller)
    {
        if (!m_useServer)
            return;

        m_playerCount++;

        if (m_playerCount >= 2)
        {
            _controller.MoveThis();
            m_wait.Init_OtherControllers(_controller);
        }
        else
            m_wait.Init_MyControllers(_controller);

        //Start_Game();

        //Debug.Log(m_playerCount);
    }

    public void Update_CheckReady()
    {
        m_wait.Update_Controllers();
    }

    public void Start_MultiGame()
    {
        if (m_playerCount >= 2)
        {
            
            m_subCam?.Set_MiniScreen();
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

        if(m_isSingle)
            m_timeText.gameObject.SetActive(true);
        m_scoreSlider.gameObject.SetActive(true);

        StartCoroutine(Start_Game_Cor());
    }

    IEnumerator Start_Game_Cor()
    {
        if(m_wait != null)
            m_wait.gameObject.SetActive(false);
        //yield return new WaitForSecondsRealtime(0.3f);
        m_startText.gameObject.SetActive(true);
        m_startText.text = 3 + "!";
        yield return new WaitForSeconds(0.7f);
        m_startText.text = 2 + "!";
        yield return new WaitForSeconds(0.7f);
        m_startText.text = 1 + "!";
        yield return new WaitForSeconds(0.7f);
        m_startText.text = "시작한다냥!";
        yield return new WaitForSeconds(0.7f);

        m_startText.gameObject.SetActive(false);

        m_isGameStart = true;

        for (int i = 0; i < m_controllers.Length; i++)
        {
            m_controllers[i].Start_Game();
        }
    }

    private void Update()
    {
        if(m_isGameStart && m_isSingle)
        {
            m_time -= Time.deltaTime;

            Set_Text();

            if(m_time <= 0)
            {
                See_Ending(EndingController.KIND.bad_common);
                //End_Game();
            }
        }
    }

    [SerializeField]
    FinalController m_finalGame;

    bool m_isCheckEnd = false;
    public void CheckEnd_MultiGame()
    {
        if (m_isCheckEnd)
            return;

        Camera.main.gameObject.SetActive(false);
        m_finalGame.gameObject.SetActive(true);
        
        End_Game();
        m_isCheckEnd = true;
    }

    public void End_FinalGame()
    {
        for (int i = 0; i < m_controllers.Length; i++)
        {
            m_controllers[i].Set_CatCantMove();
        }

        if(m_myController.Score > m_otherController.Score)
        {
            m_endingController.See_Ending(EndingController.KIND.happy);
        }
        else
        {
            m_endingController.See_Ending(EndingController.KIND.bad_common);
        }
    }



    public void End_Game(bool _isSuccess = false)
    {
        if (!m_isGameStart)
            return;

        if (m_isSingle)
        {
           

            for (int i = 0; i < m_controllers.Length; i++)
            {
                m_controllers[i].SingleEnd();
            }

            if(_isSuccess)
            {
                m_endingController.See_Ending(EndingController.KIND.happy);
            }
            else
            {
                m_endingController.See_Ending(EndingController.KIND.bad_common);
            }
        }
        else
        {
            for (int i = 0; i < m_controllers.Length; i++)
            {
                m_controllers[i].End_Game();
            }
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


    public void See_Ending(EndingController.KIND _kind)
    {
        if (!m_isGameStart)
            return;

        if(m_playerCount >= 2)
        {
            if ((int)_kind >= (int)EndingController.KIND.bad_1)
                return;
        }

        m_endingController.See_Ending(_kind);
        End_Game();

    }

    public void Update_Slider()
    {
        if (m_isSingle || !m_isInit)
            return;

        Set_Slider_Compare(m_myController.Score, m_otherController.Score);

        if(m_myController.Score + m_otherController.Score >= 40)
        {
            CheckEnd_MultiGame();
        }
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

    public void SetActive_Huddle(bool _isActive)
    {
        m_screenHuddle.gameObject.SetActive(_isActive);
    }
}
