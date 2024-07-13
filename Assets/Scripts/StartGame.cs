using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void LoadScene(String sceneName){
        SceneManager.LoadScene(sceneName);
    }
}
