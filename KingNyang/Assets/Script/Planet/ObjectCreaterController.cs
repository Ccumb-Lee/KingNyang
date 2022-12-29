using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ObjectCreaterController : MonoBehaviour
{
    public delegate void AllDeadFunc();
    AllDeadFunc m_func;

    [SerializeField]
    ObjectCreater[] m_lines;

    [SerializeField]
    GameObject m_likeStuff;

    [SerializeField]
    GameObject m_hateStuff;

    [SerializeField]
    GameObject m_randomStuff;

    List<GameObject> m_normalStuffs;

    Queue<List<GameObject>> m_stuffQueue = new Queue<List<GameObject>>();
    List<GameObject> m_firstObjects;

    int[] m_currentKind;

    public void Init(List<GameObject> _normals, AllDeadFunc _func)
    {
        m_normalStuffs = _normals;
        m_currentKind = new int[4];
        m_func = _func;
    }

   // [PunRPC]
    public void Create_Line()
    {
        GameObject[] objects = new GameObject[4];

        for(int i = 0; i < objects.Length; i++)
        {
            objects[i] = SelectObject(i);
        }

        bool cantClear = true;

        for(int i = 0; i < m_currentKind.Length; i++)
        {
            if(m_currentKind[i] >= 0)
            {
                cantClear = false;
                break;
            }
        }

        /// ¸ðµÎ ½È¾îÇÏ´Â ¹°¿õµ¢ÀÌ¶ó¸é?
        if(cantClear)
        {
            int index = Random.Range(0, 4);
            m_currentKind[index] = 0;
            objects[index] = m_normalStuffs[Random.Range(0, m_normalStuffs.Count - 1)];
        }

        List<GameObject> objList = new List<GameObject>();
        for (int i = 0; i < objects.Length; i++)
        {
            GameObject obj = m_lines[i].Create_Object(objects[i]);

            if (m_currentKind[i] > 1)
            {
                obj.GetComponent<Obstacle>().Init_Obstacle(1);
                obj.gameObject.tag = "BOX";
            }
            else if(m_currentKind[i] > 0)
            {
                obj.GetComponent<Obstacle>().Init_Obstacle(1);
                obj.gameObject.tag = "LIKE";
            }
            else if(m_currentKind[i] < 0)
            {
                if(obj != null)
                {
                    obj.GetComponent<Obstacle>().Init_Obstacle(1);
                    obj.gameObject.tag = "HATE";
                }
               
            }
            else
            {
                obj.GetComponent<Obstacle>().Init_Obstacle(1);
            }
            objList.Add(obj);
        }

        m_stuffQueue.Enqueue(objList);
      
    }

    public void CheckAndNext()
    {
        if(m_firstObjects == null)
        {
            m_firstObjects = m_stuffQueue.Peek();
        }

        bool canNext = true;
        for (int i = 0; i < m_firstObjects.Count; i++)
        {
            if (m_firstObjects[i] != null)
            {
                if(m_firstObjects[i].tag != "HATE" && m_firstObjects[i].tag != "LIKE" && m_firstObjects[i].activeInHierarchy)
                {
                    canNext = false;
                }
                //Destroy(objList[i]);
            }
        }

        if(canNext)
        {
            m_stuffQueue.Dequeue();
            Remove_First(m_firstObjects);
            m_firstObjects = m_stuffQueue.Peek();
            m_func?.Invoke();
        }
    }

   // [PunRPC]
    public void Remove_First(List<GameObject> _objList)
    {
        for(int i = 0; i < _objList.Count; i++)
        {
            if(_objList[i] != null)
            {
                Destroy(_objList[i]);
            }
        }
    }

    GameObject SelectObject(int _lineIndex)
    {
        int num = Random.Range(0, 100);

        if (num < 5)
        {
            m_currentKind[_lineIndex] = 2;
            return m_randomStuff;
        }
        else if (num < 10)
        {
            m_currentKind[_lineIndex] = -1;
            return m_hateStuff;
        }
        else if(num < 15)
        {
            m_currentKind[_lineIndex] = 1;
            return m_likeStuff;
        }
        else if (num < 45)
        {
            m_currentKind[_lineIndex] = -1;
            return null;
        }

        m_currentKind[_lineIndex] = 0;
        return m_normalStuffs[Random.Range(0, m_normalStuffs.Count - 1)];


    }


}
