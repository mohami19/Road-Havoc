using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Nakama;
using Nakama.TinyJson;


public class LeaderBoardManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI leaderBoardNames;
    [SerializeField] private TextMeshProUGUI leaderBoardScore;

    // Start is called before the first frame update

    private const string scheme = "http";
    private const string host = "127.0.0.1";
    private const int port = 7350;
    private const string serverKey = "defaultkey";
    private Client client;
    private string deviceId = "f49da7fc-91e8-49e1-befb-960aaef15cc1";
    private ISession session;

    async void Start()
    {   
        leaderBoardNames.text = "";
        leaderBoardScore.text = "";
        client =  new Client(scheme, host, port, serverKey);
        session = await client.AuthenticateDeviceAsync(deviceId);
        GetLeaderBoard();
    }

    private async void GetLeaderBoard()
    {   

        var result = await client.RpcAsync(session, "get_bucket_records");
        var shit = result.Payload.FromJson<Records>();
        for (int i = 0; i < shit.records.Count; i++) {
            leaderBoardNames.text += shit.records[i].username.value + "\n";
            leaderBoardScore.text += shit.records[i].score + "\n";
        }

    }
}


public class Records
{
    public List<Record> records { get; set; }
}

public class Record
{
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

public class Username
{
    public string value { get; set; }
}

public class CreateTime
{
    public int seconds { get; set; }
}

public class UpdateTime
{
    public int seconds { get; set; }
}

public class ExpiryTime
{
    public int seconds { get; set; }
}