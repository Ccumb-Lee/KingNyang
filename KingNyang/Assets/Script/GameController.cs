using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[DisallowMultipleComponent]
public class GameController : MonoBehaviour
{
    private bool m_isStart = false;
    public bool IsStart
    {
        get
        {
            return m_isStart;
        }
    }

    private int m_score;
    
    public int Score
    {
        get
        {
            return m_score;
        }
        set
        {
            m_score = value;

            CheckAndEndGame();
        }
    }

    private int m_targetScore;

    bool m_isSingle = false;

    [SerializeField]
    PlanetController m_planetController;

    [SerializeField]
    CatController m_catController;

    [SerializeField]
    Transform m_camPos;

    [SerializeField]
    PhotonView m_pv;

    public void Init()
    {
        m_isStart = false;
        m_planetController.Init_Component(ObjectStorage.Thema.Gyeongbokgung);
        m_catController.Init();

        m_targetScore = -1;
       
    }

    void CheckAndEndGame()
    {
        if (!m_isSingle)
        {
            return;
        }

        GameManager.instance().Set_Slider((float)m_score, (float)m_targetScore);

        if (m_score >= m_targetScore)
        {
            GameManager.instance().End_Game();
        }
    }
    
    public void Set_TargetScore()
    {
        m_isSingle = true;
        m_targetScore = Random.Range(60, 65);
    }

    public void Start_Game()
    {
        m_isStart = true;
        m_score = 0;

        Set_CatCanMove();

        if (m_pv.IsMine)
        {
            Camera.main.transform.SetParent(m_camPos);
            Camera.main.transform.localPosition = Vector3.zero;
        }
    }

    public void End_Game()
    {
        m_isStart = false;
        Set_CatCantMove();
    }

    public void CheckAndNext()
    {
        m_planetController.CheckAndNext();
    }

    public void Set_CatCantMove()
    {
        m_catController.Set_CantMove();
    }

    public void Set_CatCanMove()
    {
        
        m_catController.Set_CanMove();
    }
}
