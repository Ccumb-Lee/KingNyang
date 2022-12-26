using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMovement : MonoBehaviour
{
    const float m_maxAngle = 360.0f;

    [SerializeField]
    float m_speed = 5;

    public void Init_Planet()
    {
        this.transform.eulerAngles = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        if (!GameManager.instance().IsStart)
            return;

        Rotate();
    }

    void Rotate()
    {
        this.transform.Rotate(new Vector3(Time.deltaTime * m_speed, 0, 0));
    }
}
