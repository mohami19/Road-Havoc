using System.Collections.Generic;
using Nakama;
using Nakama.TinyJson;
using TMPro;
using UnityEngine;
using UnityEngine.Analytics;

public class ClientManager : MonoBehaviour
{
    private const string scheme = "http";
    private const string host = "62.106.95.170";
    private const int port = 7350;
    private const string serverKey = "defaultkey";
    private Client client;
    private string deviceId;
    private ISession session;
    private Records records;

    private bool isLogIn = false;

    async void Awake() {
        int numScenePersists = FindObjectsOfType<ClientManager>().Length;
        if (numScenePersists > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
        // myDeviceID = 514f368d37e872c3bc97aa11a3daf2180cb7bd14
        deviceId = SystemInfo.deviceUniqueIdentifier;
        client =  new Client(scheme, host, port, serverKey);
        session = await client.AuthenticateDeviceAsync(deviceId);
        isLogIn = true;
    }

    public async void ChangeUsername(TMP_InputField inputField){
        await client.UpdateAccountAsync(session,inputField.text);
    }

    public async void FillLeaderBoard(TextMeshProUGUI leaderBoardNames,TextMeshProUGUI leaderBoardScore){
        var result = await client.RpcAsync(session, "get_bucket_records");
        records = result.Payload.FromJson<Records>(); 
        leaderBoardNames.text = "";
        leaderBoardScore.text = "";
        for (int i = 0; i < records.records.Count; i++) {
            leaderBoardNames.text += records.records[i].username.value + "\n";
            leaderBoardScore.text += records.records[i].score + "\n";
        }
    }

    public async void UpdateScore(TextMeshProUGUI submitScore){
        if (int.TryParse(submitScore.text, out int scoreInt)) {
            await client.WriteLeaderboardRecordAsync(session,"bucketed_weekly",scoreInt);
        } else {
            Debug.Log("Failed to parse score text to int.");
        }
    }

    public async void GetWallet(TextMeshProUGUI gems,TextMeshProUGUI coins) {
        var result = await client.GetAccountAsync(session);
        gems.text = result.Wallet.FromJson<Wallet>().gems.ToString();
        coins.text = result.Wallet.FromJson<Wallet>().coins.ToString();
    }

    public async void UpdateWallet(int gemNum,int coinNum){
        Debug.Log(gemNum);
        Wallet updateWallet = new(gemNum,coinNum);
        string json = JsonWriter.ToJson(updateWallet);
        Debug.Log(json);
        await client.RpcAsync(session,"update_wallet",json);
    }


}

public class Wallet {

    public Wallet(int gems, int coins)
    {
        this.gems = gems;
        this.coins = coins;
    }

    public int gems { get; set; }
    public int coins { get; set; }
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

