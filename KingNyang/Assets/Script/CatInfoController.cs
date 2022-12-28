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
        END
    }

    [SerializeField]
    Material[] m_catMats;

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
                m_type = (CAT_TYPE)(int)CAT_TYPE.END - 1;
            }
            else if((int)m_type < (int)CAT_TYPE.cheese)
            {
                m_type = CAT_TYPE.cheese;
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

}
