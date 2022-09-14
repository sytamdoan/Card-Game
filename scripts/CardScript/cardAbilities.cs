using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public abstract class cardAbilities : NetworkBehaviour
{

    public PlayerManager playerManager;
    // Start is called before the first frame update
    void Start()
    {
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        playerManager = networkIdentity.GetComponent<PlayerManager>();
    }

    public abstract void OnCompile();

    public abstract void OnExecute();
}
