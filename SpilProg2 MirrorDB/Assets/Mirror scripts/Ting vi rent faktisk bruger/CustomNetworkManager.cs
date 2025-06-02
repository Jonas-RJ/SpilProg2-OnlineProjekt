using System;
using Mirror;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CustomNetworkManager : NetworkManager
{
    public HealthManager HM;
    public NetworkDataHolder DH;
    public GameObject[] avatars;


  //  [SyncVar]
    //    public int CharacterDecider;
    void onCreateCharacter(NetworkConnectionToClient connection, CreateCustomAvatarMessage message)
    {
        GameObject gameObject = Instantiate(avatars[message.AvatarIndex]);

        Player player = gameObject.GetComponent<Player>();

        NetworkServer.AddPlayerForConnection(connection, gameObject);
    }


    public override void OnStartServer()
    {
        base.OnStartServer();

        NetworkServer.RegisterHandler<CreateCustomAvatarMessage>(onCreateCharacter);
    }


    public override void OnServerConnect(NetworkConnectionToClient conn)
    {
     
    }

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
          // base.OnServerAddPlayer(conn);

        int characterIndex = 0;

        if (!DH.Player1Taken)
        {
            DH.CmdDecidePlayer1();
            characterIndex = 0;

        }

        else
        {
            DH.CmdDecidePlayer2();
            characterIndex = 1;
        }

        CreateCustomAvatarMessage message = new()
        {

            AvatarIndex = characterIndex


        };

        onCreateCharacter(conn, message);
      // NetworkClient.Send(message);
    }
    public override void OnClientConnect()
    {


    }



  
}
