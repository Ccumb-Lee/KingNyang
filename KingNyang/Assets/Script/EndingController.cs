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
    Sprite[] m_endings;

    [SerializeField]
    AudioSource m_audio;
    [SerializeField]
    AudioSource m_main;


    [SerializeField]
    AudioClip[] m_audioClip;

    public void See_Ending(KIND _kind)
    {
        this.gameObject.SetActive(true);
        m_image.sprite = m_endings[(int)_kind];
        m_image.gameObject.SetActive(true);

        m_main.Pause();

        if (_kind == KIND.happy)
        {
            m_audio.clip = m_audioClip[0];
            
        }
        else
        {
            m_audio.clip = m_audioClip[1];

        }
        m_audio.Play();

    }

    public void OnClick_Lobby()
    {
        SceneManager.LoadScene("Lobby");
    }

}
