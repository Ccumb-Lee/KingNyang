using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleComponent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Disable_Cor());
    }

    IEnumerator Disable_Cor()
    {
        yield return new WaitForSeconds(3.0f);
        //this.gameObject.SetActive(false);
        Destroy(this.gameObject);
    }
}
