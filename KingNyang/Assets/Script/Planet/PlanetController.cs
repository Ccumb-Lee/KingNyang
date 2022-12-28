using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    GameController m_owner;
    public GameController Owner
    {
        get
        {
            return m_owner;
        }
    }


    [SerializeField]
    ObjectStorage m_storage;

    [SerializeField]
    ObjectCreaterController m_createController;

    [SerializeField]
    PlanetMovement m_movement;

    public void Init_Component()
    {
        m_owner = this.GetComponent<GameController>();

        m_createController.Init(m_storage.Get_ThemaObjects(), Move_Next);
        m_movement.Init_Planet(CreateStuff);

        for (int i = 0; i < 5; i++)
        {
            m_createController.Create_Line();
            m_movement.Rotate_NoAnim();
        }
        m_createController.Create_Line();
    }

    void Move_Next()
    {
        m_movement.Start_Rotate();
        Owner.Score++;
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
