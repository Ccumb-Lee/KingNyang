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
        //todo - ÄÚ½ºÆ¬
        //Application.Quit();
    }

    public void OnTrigger_Single()
    {
        SceneManager.LoadScene("Single");
    }

    public void OnTrigger_Multi()
    {
        SceneManager.LoadScene("Multi");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            CatInfoController.instance().Type++;
        }
    }
}
