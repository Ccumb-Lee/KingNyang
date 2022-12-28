using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Title : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnClick_Title()
    {
        SceneManager.LoadScene("Lobby");
    }
}
