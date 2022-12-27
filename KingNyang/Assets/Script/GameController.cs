using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Start()
    {
        m_isStart = true;
        m_score = 0;

        m_planetController.Init_Component(ObjectStorage.Thema.Gyeongbokgung);
        m_catController.Init();
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
