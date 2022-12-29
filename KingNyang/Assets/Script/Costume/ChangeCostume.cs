using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeCostume : MonoBehaviour
{
    [SerializeField]
    SkinnedMeshRenderer m_renderer;

    int[] m_changeCostume;
    private void Start()
    {
        m_changeCostume = CatInfoController.instance().Get_CostumeData();
        m_renderer.material = CatInfoController.instance().Get_Material(CatInfoController.instance().Type);
        Set_Costume(m_changeCostume);
    }

    public void Change_Costume()
    {
        Clear_Costume();

        m_changeCostume[(int)CatInfoController.COSTUME_PART.face] = Random.Range(0, 4);
        m_changeCostume[(int)CatInfoController.COSTUME_PART.body] = Random.Range(0, 4);
        m_changeCostume[(int)CatInfoController.COSTUME_PART.ear] = Random.Range(0, 3);

        Set_Costume(m_changeCostume);
        CatInfoController.instance().Change_CostumeData(m_changeCostume);
    }

    public void Change_Mat()
    {
        CatInfoController.instance().Type++;
        m_renderer.material = CatInfoController.instance().Get_Material(CatInfoController.instance().Type);
    }

    public void Lobby()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void Clear_Costume()
    {
        for (int i = 2; i <= 4; i++)
        {
            m_renderer.SetBlendShapeWeight(i, 0);
        }
        for (int i = 5; i <= 7; i++)
        {
            m_renderer.SetBlendShapeWeight(i, 0);
        }
        for (int i = 8; i <= 9; i++)
        {
            m_renderer.SetBlendShapeWeight(i, 0);
        }
    }

    public void Set_Costume(int[] _costumeData)
    {
        // ¾ó±¼
        if(_costumeData[0] > 0)
            m_renderer.SetBlendShapeWeight(2 + (_costumeData[0] - 1), 100);
        else
        {
            for(int i = 2; i <= 4; i++)
            {
                m_renderer.SetBlendShapeWeight(i, 0);
            }
        }

        if (_costumeData[1] > 0)
            m_renderer.SetBlendShapeWeight(5 + (_costumeData[1] - 1), 100);
        else
        {
            for (int i = 5; i <= 7; i++)
            {
                m_renderer.SetBlendShapeWeight(i, 0);
            }
        }

        if (_costumeData[2] > 0)
            m_renderer.SetBlendShapeWeight(8 + (_costumeData[2] - 1), 100);
        else
        {
            for (int i = 8; i <= 9; i++)
            {
                m_renderer.SetBlendShapeWeight(i, 0);
            }
        }
    }
}
