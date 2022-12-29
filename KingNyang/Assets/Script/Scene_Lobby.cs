using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Lobby : MonoBehaviour
{
    [SerializeField]
    CatController m_cat;

    [SerializeField]
    TriggerMenu[] m_menus;

    private void Start()
    {
        m_cat.Init();
        m_cat.Set_Material((int)CatInfoController.instance().Type);
        m_cat.Set_Costume(CatInfoController.instance().Get_CostumeData());
        m_cat.Set_CanMove();

        m_menus[0].Set_Func(OnTrigger_Quit);
        m_menus[1].Set_Func(OnTrigger_Custom);
        m_menus[2].Set_Func(OnTrigger_Multi);
        m_menus[3].Set_Func(OnTrigger_Single);
    }

    public void OnTrigger_Quit()
    {
        Application.Quit();
    }

    public void OnTrigger_Custom()
    {
        SceneManager.LoadScene("Costume");
    }

    public void OnTrigger_Single()
    {
        SceneManager.LoadScene("Single");
    }

    public void OnTrigger_Multi()
    {
        SceneManager.LoadScene("Multi");
    }

}
