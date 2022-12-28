using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingController : MonoBehaviour
{
    public enum KIND
    {
        bad_common,
        happy,
        bad_1,  // �ŵ�ȭ
        bad_2,  // ���ٷ�
        bad_3  // �縷
        
    }

    [SerializeField]
    Image m_image;

    [SerializeField]
    Sprite[] m_endings;

    public void See_Ending(KIND _kind)
    {
        this.gameObject.SetActive(true);
        m_image.sprite = m_endings[(int)_kind];
        m_image.gameObject.SetActive(true);
    }

}
