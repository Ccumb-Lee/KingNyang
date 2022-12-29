using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CatInfoController : Singleton<CatInfoController>
{
    public enum CAT_TYPE
    {
        cheese,
        black,
        tuxedo,
        white,
        threecolor,
        END
    }

    public enum COSTUME_PART
    {
        face,
        body,
        ear,
        END
    }

    int[] m_costume;

    [SerializeField]
    Material[] m_catMats;

    [SerializeField]
    AudioClip[] m_sounds;

    private CAT_TYPE m_type;
    public CAT_TYPE Type
    {
        get
        {
            return m_type;
        }
        set
        {
            m_type = value;

            if((int)m_type >= (int)CAT_TYPE.END)
            {
                m_type = (CAT_TYPE)(int)CAT_TYPE.cheese;
            }
            else if((int)m_type < (int)CAT_TYPE.cheese)
            {
                m_type = CAT_TYPE.END - 1;
            }
        }
    }


    //private void Start()
    //{
    //    m_type = CAT_TYPE.cheese;
    //}

    public Material Get_Material(CAT_TYPE _type)
    {
        return m_catMats[(int)_type];
    }

    public AudioClip Get_Sound(CAT_TYPE _type)
    {
        return m_sounds[(int)_type];
    }

    public void Change_CostumeData(int[] _costumeData)
    {
        m_costume = _costumeData;
    }

    public int[] Get_CostumeData()
    {
        if(m_costume == null)
        {
            m_costume = new int[(int)COSTUME_PART.END];

        }

        return m_costume;

    }

}
