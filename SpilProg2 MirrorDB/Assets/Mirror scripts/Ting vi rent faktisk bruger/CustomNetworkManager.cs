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


    public override void OnStartHost()
    {
        base.OnStartHost();

        NetworkServer.RegisterHandler<CreateCustomAvatarMessage>(onCreateCharacter);
    }

    public override void OnClientConnect()
    {
        base.OnClientConnect();
        if (DH.Player1Taken)
        {
            DH.CmdDecidePlayer1();

        }

        else
        {
            DH.CmdDecidePlayer2();

        }

        CreateCustomAvatarMessage message = new()
        {

            AvatarIndex = DH.characterIndex


        };


        NetworkClient.Send(message);




       
    }



  
}
