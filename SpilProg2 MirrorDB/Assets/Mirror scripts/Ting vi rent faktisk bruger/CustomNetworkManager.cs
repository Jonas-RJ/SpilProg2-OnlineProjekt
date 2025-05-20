using Mirror;
using UnityEngine;

public class CustomNetworkManager : NetworkManager
{
    public GameObject[] avatars;

    void onCreateCharacter(NetworkConnectionToClient connection, CreateCustomAvatarMessage message)
    {
        GameObject gameObject = Instantiate(avatars[message.AvatarIndex]);

        Player player = gameObject.GetComponent<Player>();

        NetworkServer.AddPlayerForConnection(connection, gameObject);
    }


    public override void OnStartHost()
    {
        base.OnStartHost();

        NetworkServer.RegisterHandler<CreateCustomAvatarMessage>(onCreateCharacter);
    }

    public override void OnClientConnect()
    {
        base.OnClientConnect();

        CreateCustomAvatarMessage message = new()
        {
            AvatarIndex = Random.Range(0, avatars.Length)
        };
        NetworkClient.Send(message);
    }



  
}
