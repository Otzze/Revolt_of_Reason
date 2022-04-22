using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneScript : MonoBehaviour
{
    public string ScenetoLoad;
    void Start()
    {
        
    }

    public void changeScene()
    {
        SceneManager.LoadScene(ScenetoLoad);
    }
}
