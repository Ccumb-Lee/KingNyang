using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SubCamComponent : MonoBehaviour
{
    [SerializeField]
    GameObject m_readyImage;

    [SerializeField]
    GameObject m_miniImage;

    [SerializeField]
    GameObject m_subCamera;

    [SerializeField]
    GameObject m_dummyPlanet;

    public void Set_Camera(Transform _parent)
    {
        m_subCamera.transform.SetParent(_parent);
        m_subCamera.transform.localPosition = Vector3.zero;

        m_subCamera.gameObject.SetActive(true);
        m_miniImage.gameObject.SetActive(false);
        m_readyImage.gameObject.SetActive(true);

        m_dummyPlanet.gameObject.SetActive(false);
    }

    public void Set_MiniScreen()
    {
        m_miniImage.gameObject.SetActive(true);
        m_readyImage.gameObject.SetActive(false);
    }
}
