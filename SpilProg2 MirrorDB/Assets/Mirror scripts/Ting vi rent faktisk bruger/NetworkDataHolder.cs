using Mirror;
using UnityEngine;

public class NetworkDataHolder : NetworkBehaviour
{
    [SyncVar] public int CharacterDecider;

    [SyncVar] public bool Player1Taken = false;
    [SyncVar] public int characterIndex = 0;






}
