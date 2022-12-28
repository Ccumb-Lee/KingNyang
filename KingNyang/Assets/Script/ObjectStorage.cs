using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStorage : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> m_themaObjects;

    public List<GameObject> Get_ThemaObjects()
    {
        return m_themaObjects;
    }
}
