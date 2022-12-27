using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCamComponent : MonoBehaviour
{
    [SerializeField]
    GameObject m_rowImage;

    [SerializeField]
    GameObject m_subCamera;

    public void Set_Camera(Transform _parent)
    {
        m_subCamera.transform.SetParent(_parent);
        m_subCamera.transform.localPosition = Vector3.zero;

        m_subCamera.gameObject.SetActive(true);
        m_rowImage.gameObject.SetActive(true);
    }
}
