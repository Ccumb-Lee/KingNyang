using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (EnvironmentManager.instance() != this)
        {
            Destroy(this.gameObject);
            return;
        }
            
        DontDestroyOnLoad(this);
        SceneManager.sceneLoaded += LoadedsceneEvent;
    }

    private void Start()
    {
        int rand = Random.Range((int)DAY.MORNING, (int)DAY.END);

        m_day = (DAY)rand;

        //m_sky.SetTextureOffset()
        m_mat.SetTexture("_MainTex", m_dayTexture[(int)m_day]);
        m_sky.SetTextureOffset("_MainTex", m_skyOffset[(int)m_day]);

        Set_Sky();
    }

    private void LoadedsceneEvent(Scene scene, LoadSceneMode mode)
    {
        Set_Sky();
    }

    void Set_Sky()
    {
        //RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.;
        if (m_day == DAY.MORNING)
            Set_Day_Morning();
        else if (m_day == DAY.EVENING)
            Set_Day_Evening();
        else if (m_day == DAY.NIGHT)
            Set_Day_Night();
    }
    void Set_Day_Morning()
    {
        Color ambientcolor;
        ColorUtility.TryParseHtmlString("#d3d3d2", out ambientcolor);

        RenderSettings.ambientSkyColor = ambientcolor;

        Color ambientEquatorColor;
        ColorUtility.TryParseHtmlString("#d1dee6", out ambientEquatorColor);

        RenderSettings.ambientEquatorColor = ambientEquatorColor;

        Color ambientGroundColor;
        ColorUtility.TryParseHtmlString("#6d89bd", out ambientGroundColor);

        RenderSettings.ambientGroundColor = ambientGroundColor;
    }

    void Set_Day_Evening()
    {
        Color ambientcolor;
        ColorUtility.TryParseHtmlString("#b39284", out ambientcolor);

        RenderSettings.ambientSkyColor = ambientcolor;

        Color ambientEquatorColor;
        ColorUtility.TryParseHtmlString("#8aa2c6", out ambientEquatorColor);

        RenderSettings.ambientEquatorColor = ambientEquatorColor;

        Color ambientGroundColor;
        ColorUtility.TryParseHtmlString("#c894be", out ambientGroundColor);

        RenderSettings.ambientGroundColor = ambientGroundColor;
    }

    void Set_Day_Night()
    {
        Color ambientcolor;
        ColorUtility.TryParseHtmlString("#9779c2", out ambientcolor);

        RenderSettings.ambientSkyColor = ambientcolor;

        Color ambientEquatorColor;
        ColorUtility.TryParseHtmlString("#6b00f4", out ambientEquatorColor);

        RenderSettings.ambientEquatorColor = ambientEquatorColor;

        Color ambientGroundColor;
        ColorUtility.TryParseHtmlString("#75c8d7", out ambientGroundColor);

        RenderSettings.ambientGroundColor = ambientGroundColor;
    }
}
