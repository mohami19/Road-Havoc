using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI submitScore;
    [SerializeField] TextMeshProUGUI gemCollect;

    private ClientManager clientManager;


    void Awake() {
        submitScore.text = score.text;
        // clientManager = FindObjectOfType<ClientManager>();
        // clientManager.UpdateScore(submitScore);
        // clientManager.UpdateWallet(int.Parse(gemCollect.text),0);
    }

    public void RestartLvl(){
        SceneManager.LoadScene(0);
    }
}
