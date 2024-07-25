using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI leaderBoardNames;
    [SerializeField] private TextMeshProUGUI leaderBoardScore;
    [SerializeField] TMP_InputField inputField;

    [SerializeField] private float loadDelay = 1.5f; 

    private ClientManager clientManager;

    public void LoadScene(String sceneName){
        SceneManager.LoadScene(sceneName);
    }

    void Start() {   
        clientManager = FindObjectOfType<ClientManager>();
        StartCoroutine(FillLeaderBoard());
    }

    public void ChangeName(){
        clientManager.ChangeUsername(inputField);
    }

    IEnumerator FillLeaderBoard(){
        yield return new WaitForSecondsRealtime(loadDelay);
        clientManager.FillLeaderBoard(leaderBoardNames,leaderBoardScore);
    }
}
