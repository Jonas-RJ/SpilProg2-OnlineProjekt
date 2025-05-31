using Mirror;
using UnityEngine;

public class NetworkDataHolder : NetworkBehaviour
{
    [SyncVar] public int CharacterDecider;

    [SyncVar] public bool Player1Taken = false;
    [SyncVar] public int characterIndex = 0;



    [Command(requiresAuthority = false)]
    public void CmdDecidePlayer2()
    {
        characterIndex = 0;
        CharacterDecider++;
        Player1Taken = true;
                        Debug.Log(Player1Taken);
        Debug.Log("player1 decided" + CharacterDecider);
    }

    [Command(requiresAuthority = false)]
    public void CmdDecidePlayer1()
    {
        characterIndex = 1;
        CharacterDecider++;
                        Debug.Log("player2 decided" + "  " + CharacterDecider);

                }


}
