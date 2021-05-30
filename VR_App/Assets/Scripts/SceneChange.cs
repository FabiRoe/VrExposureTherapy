using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChange : MonoBehaviour
{

    public string levelToLoad;

    public void LoadScene()
    {
        SceneManager.LoadScene(levelToLoad);
    }

}
