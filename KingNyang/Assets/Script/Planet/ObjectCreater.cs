using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreater : MonoBehaviour
{
    [SerializeField]
    Transform m_createRoot;

    public GameObject Create_Object(GameObject _obj)
    {
        if (_obj == null)
            return null;
        GameObject obj = Instantiate(_obj, this.transform);
        obj.transform.SetParent(m_createRoot);
        return obj;
    }
}
