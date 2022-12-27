using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    [SerializeField]
    ObjectStorage m_storage;

    [SerializeField]
    ObjectCreaterController m_createController;

    [SerializeField]
    PlanetMovement m_movement;

    public void Init_Component(ObjectStorage.Thema _thema)
    {
        m_createController.Init(m_storage.Get_ThemaObjects(_thema), m_movement.Start_Rotate);
        m_movement.Init_Planet(CreateStuff);

        for (int i = 0; i < 5; i++)
        {
            m_createController.Create_Line();
            m_movement.Rotate_NoAnim();
        }
        m_createController.Create_Line();
    }

    void CreateStuff()
    {
        m_createController.Create_Line();
    }

    public void CheckAndNext()
    {
        m_createController.CheckAndNext();
    }

}
