using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStorage : MonoBehaviour
{
    public enum Thema
    {
        Gyeongbokgung,

        Gyeongbokgung_first,
        Gyeongbokgung_second,
        Gyeongbokgung_third,
        Gyeongbokgung_forth,


        End,

        NamsanTower,

        NamsanTower_first,
        NamsanTower_second,
        NamsanTower_third


        
    }

    [SerializeField]
    private List<GameObject> m_themaObjects;

    public List<GameObject> Get_ThemaObjects(Thema _thema)
    {
        List<GameObject> objects = new List<GameObject>();

        for(int i = (int)_thema + 1; i < (int)Thema.End; i++)
        {
            if(((Thema)i).ToString().Contains(((Thema)_thema).ToString()))
            {
                objects.Add(m_themaObjects[i]);
            }

        }
        return objects;
    }
}
