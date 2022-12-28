using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FinalController : MonoBehaviour
{
    bool m_isGameStart;

    [SerializeField]
    TextMeshProUGUI m_timeText;

    float m_time;

    // Start is called before the first frame update
    void Start()
    {
        m_isGameStart = true;
        m_time = 15.0f;
        m_timeText.gameObject.SetActive(true);
        Set_Text();
    }

    private void Update()
    {
        if (m_isGameStart)
        {
            m_time -= Time.deltaTime;

            Set_Text();

            if (m_time <= 0)
            {
                GameManager.instance().End_FinalGame();
                //End_Game();
            }
        }
    }

    void Set_Text()
    {
        if (m_time <= 0)
            m_time = 0.0f;

        m_timeText.text = ((int)m_time).ToString();
    }

}
