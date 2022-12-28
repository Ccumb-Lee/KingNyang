using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : Singleton<EnvironmentManager>
{
    public enum DAY
    {
        MORNING,
        EVENING,
        NIGHT,
        END
    }
    [SerializeField]
    Material m_mat;

    [SerializeField]
    Material m_sky;

    [SerializeField]
    Texture2D[] m_dayTexture;

    [SerializeField]
    Vector2[] m_skyOffset;

    DAY m_day;

    public void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        int rand = Random.Range((int)DAY.MORNING, (int)DAY.END);

        m_day = (DAY)rand;

        //m_sky.SetTextureOffset()
        m_mat.SetTexture("_MainTex", m_dayTexture[(int)m_day]);
        m_sky.SetTextureOffset("_MainTex", m_skyOffset[(int)m_day]);
    }
}
