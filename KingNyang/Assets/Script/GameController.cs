using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[DisallowMultipleComponent]
public class GameController : MonoBehaviour, IPunObservable
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
            GameManager.instance().Update_Slider();
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

    public bool IsMine
    {
        get
        {
            return m_pv.IsMine;
        }
    }

    public void Init()
    {
        m_isStart = false;
        m_planetController.Init_Component(ObjectStorage.Thema.Gyeongbokgung);
        m_catController.Init();

        m_targetScore = -1;
       
    }

    private void Start()
    {
        GameManager.instance().Set_PlayerCount(this);

        if (m_pv.IsMine)
        {
            Camera.main.transform.SetParent(m_camPos);
            Camera.main.transform.localPosition = Vector3.zero;
        }
        else
        {
            GameManager.instance().SubCam?.Set_Camera(m_camPos);
        }
    }

    public void MoveThis()
    {
        if(!m_pv.IsMine)
            this.transform.position += new Vector3(10.0f, 0.0f, 0.0f);
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

    // IPunObservable 인터페이스를 구현해야한다.
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // We own this player: send the others our data
            stream.SendNext(m_score);
            //stream.SendNext(Health);
        }
        else
        {
            try
            {
                this.m_score = (int)stream.ReceiveNext();
                GameManager.instance().Update_Slider();
            }
            catch
            {

            }
            // Network player, receive data
            
            //this.Health = (float)stream.ReceiveNext();
        }
    }
}
