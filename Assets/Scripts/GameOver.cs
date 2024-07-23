using Nakama;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameOver : MonoBehaviour
{
    private int playerHealth;

    //[SerializeField] private UnityEvent<int> gameOverEvent;
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI submitScore;
    
    private const string scheme = "http";
    private const string host = "62.106.95.170";
    private const int port = 7350;
    private const string serverKey = "defaultkey";
    private Client client;
    private ISession session;

    async void Awake() {
        submitScore.text = score.text;
        client =  new Client(scheme, host, port, serverKey);
        session = await client.AuthenticateDeviceAsync(SystemInfo.deviceUniqueIdentifier,"TestUser3",false);
        //score.text = Mathf.RoundToInt(GetComponent<PlayerManage>().Score).ToString();
        if (int.TryParse(submitScore.text, out int scoreInt)) {
            await client.WriteLeaderboardRecordAsync(session,"bucketed_weekly",scoreInt);
        } else {
            Debug.Log("Failed to parse score text to int.");
        }
    }
}
