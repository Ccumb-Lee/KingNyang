using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingController : MonoBehaviour
{
    public enum KIND
    {
        bad_common,
        happy,
        bad_1,  // 신도화
        bad_2,  // 개다래
        bad_3  // 사막
        
    }

    [SerializeField]
    Image m_image;

    [SerializeField]
    Image m_happyImage;

    [SerializeField]
    Sprite[] m_endings;

    [SerializeField]
    Sprite[] m_happys;

    [SerializeField]
    AudioSource m_audio;
    [SerializeField]
    AudioSource m_main;


    [SerializeField]
    AudioClip[] m_audioClip;

    int m_index = 0;

    bool m_isending = false;
    public void See_Ending(KIND _kind)
    {
        if (m_isending)
            return;

        this.gameObject.SetActive(true);
        m_image.sprite = m_endings[(int)_kind];
        m_image.gameObject.SetActive(true);
        m_happyImage.gameObject.SetActive(false);
        Debug.Log("엔딩  " + _kind.ToString());
        m_main.Pause();

        if (_kind == KIND.happy)
        {
            m_happyImage.gameObject.SetActive(true);
            m_happyImage.sprite = m_happys[m_index];
        }
        else
        {
            

        }
        m_audio.clip = m_audioClip[(int)_kind];
        m_audio.Play();
        m_isending = true;
    }

    public void OnClick_Lobby()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void OnClick_Happy()
    {
        m_index++;

        if (m_index >= m_happys.Length)
            return;
        m_happyImage.sprite = m_happys[m_index];
    }

}
