using UnityEngine;
using TMPro;
using Nakama;
using UnityEngine.UI;

public class ChangeName : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;



    private const string scheme = "http";
    private const string host = "62.106.95.170";
    private const int port = 7350;
    private const string serverKey = "defaultkey";
    private Client client;
    private ISession session;
    
    async void Start()
    {
        client =  new Client(scheme, host, port, serverKey);
        session = await client.AuthenticateDeviceAsync(SystemInfo.deviceUniqueIdentifier);
    }

    public async void ChangeUsername(){
        Debug.Log("Name is : " + inputField.text);
        await client.UpdateAccountAsync(session,inputField.text);
    }
}
