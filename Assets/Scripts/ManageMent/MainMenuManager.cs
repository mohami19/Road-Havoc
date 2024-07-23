using System;
using System.Collections.Generic;
using Nakama;
using Nakama.TinyJson;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI leaderBoardNames;
    [SerializeField] private TextMeshProUGUI leaderBoardScore;

    private const string scheme = "http";
    private const string host = "62.106.95.170";
    private const int port = 7350;
    private const string serverKey = "defaultkey";
    private Client client;
    private string deviceId;
    private ISession session;

    public void LoadScene(String sceneName){
        SceneManager.LoadScene(sceneName);
    }

    async void Start() {   
        // myDeviceID = 514f368d37e872c3bc97aa11a3daf2180cb7bd14
        deviceId = SystemInfo.deviceUniqueIdentifier;
        leaderBoardNames.text = "";
        leaderBoardScore.text = "";
        client =  new Client(scheme, host, port, serverKey);
        session = await client.AuthenticateDeviceAsync(deviceId,"TestUser3");
        GetLeaderBoard();
    }

    private async void GetLeaderBoard() {   
        var result = await client.RpcAsync(session, "get_bucket_records");
        var records = result.Payload.FromJson<Records>();
        for (int i = 0; i < records.records.Count; i++) {
            leaderBoardNames.text += records.records[i].username.value + "\n";
            leaderBoardScore.text += records.records[i].score + "\n";
        }
    }
}

public class Records {
    public List<Record> records { get; set; }
}

public class Record {
    public string leaderboard_id { get; set; }
    public string owner_id { get; set; }
    public Username username { get; set; }
    public int score { get; set; }
    public int num_score { get; set; }
    public string metadata { get; set; }
    public CreateTime create_time { get; set; }
    public UpdateTime update_time { get; set; }
    public ExpiryTime expiry_time { get; set; }
    public int rank { get; set; }
    public int max_num_score { get; set; }
}

public class Username {
    public string value { get; set; }
}

public class CreateTime {
    public int seconds { get; set; }
}

public class UpdateTime {
    public int seconds { get; set; }
}

public class ExpiryTime {
    public int seconds { get; set; }
}
