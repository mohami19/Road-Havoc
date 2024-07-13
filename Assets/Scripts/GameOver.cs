using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameOver : MonoBehaviour
{
    private int playerHealth;

    [SerializeField] private UnityEvent<int> gameOverEvent;
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] Canvas gameCanvas;
    [SerializeField] TextMeshProUGUI score;
    
    void Update()
    {
        playerHealth = gameObject.GetComponent<PlayerManage>().Health;
        if (playerHealth <= 1) {
            score.text = Mathf.RoundToInt(GetComponent<PlayerManage>().Score).ToString();
            if (int.TryParse(score.text, out int scoreInt))
            {
                gameOverEvent.Invoke(scoreInt);
            }
            else
            {
                Debug.Log("Failed to parse score text to int.");
            }
            //gameOverCanvas.enabled = true;
            gameCanvas.enabled = false;
            Time.timeScale = 0;
        }
    }
}
