using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[DisallowMultipleComponent]
public class GameController : MonoBehaviour
{
    private bool m_isStart;
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
            Debug.Log(m_score);
        }
    }

    [SerializeField]
    PlanetController m_planetController;

    [SerializeField]
    CatController m_catController;

    [SerializeField]
    Transform m_camPos;

    [SerializeField]
    PhotonView m_pv;

    private void Start()
    {
        m_isStart = true;
        m_score = 0;

        m_planetController.Init_Component(ObjectStorage.Thema.Gyeongbokgung);
        m_catController.Init();

        if(m_pv.IsMine)
        {
            Camera.main.transform.SetParent(m_camPos);
            Camera.main.transform.localPosition = Vector3.zero;
        }
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
