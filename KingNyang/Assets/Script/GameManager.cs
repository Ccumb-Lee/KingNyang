using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
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
    }

    [SerializeField]
    PlanetController m_planetController;

    private void Start()
    {
        m_isStart = true;

        m_planetController.Init_Component(ObjectStorage.Thema.Gyeongbokgung);
    }
}
