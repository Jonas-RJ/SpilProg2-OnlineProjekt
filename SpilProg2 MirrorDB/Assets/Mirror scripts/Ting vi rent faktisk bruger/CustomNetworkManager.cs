using Mirror;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CustomNetworkManager : NetworkManager
{
    public NetworkDataHolder DH;
        public int characterIndex = 0;
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
            characterIndex = 1;
        }

        else
        {
            characterIndex = 0;
         }
        
               CreateCustomAvatarMessage message = new()
            {

                   AvatarIndex = characterIndex
                
             
            };


        NetworkClient.Send(message);
    }



  
}
