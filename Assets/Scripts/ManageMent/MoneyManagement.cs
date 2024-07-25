using Nakama;
using Nakama.TinyJson;
using TMPro;
using UnityEngine;

public class MoneyManagement : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI numberOfGem;
    [SerializeField] private TextMeshProUGUI numberOfCoins;
    [SerializeField] private TextMeshProUGUI gemCollect;

    private string _gems = "0";
    private string _coins = "0";

    public string Gems { get => _gems; set => _gems = value; }
    public string Coins { get => _coins; set => _coins = value; }
    private ClientManager clientManager;

    void Start() {
        clientManager = FindObjectOfType<ClientManager>();
        clientManager.GetWallet(numberOfGem,numberOfCoins);
        gemCollect.text = Gems;
    }


    void Update() {
        gemCollect.text = Gems;
    }
    
}



