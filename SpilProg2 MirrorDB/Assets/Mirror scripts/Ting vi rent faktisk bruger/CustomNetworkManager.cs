using System;
using Mirror;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CustomNetworkManager : NetworkManager
{
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
                DH.CharacterDecider++;


        if (DH.CharacterDecider < 1)
        {
            DH.characterIndex = 1;
            print(DH.CharacterDecider);
            // DH.CharacterDecider++;
        }

        else
        {
            DH.characterIndex = 0;
            DH.CharacterDecider--;
        }
        
               CreateCustomAvatarMessage message = new()
            {

                   AvatarIndex = DH.characterIndex
                
             
            };


        NetworkClient.Send(message);
    }



  
}
