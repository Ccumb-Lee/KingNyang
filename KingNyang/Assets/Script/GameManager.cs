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

    private void Start()
    {
        m_isStart = true;
    }
}
