using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class DrawCards : NetworkBehaviour
{
    public PlayerManager PlayerManager;
    public GameManager GameManager;

    private void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void onClick()
    {
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        PlayerManager = networkIdentity.GetComponent<PlayerManager>();
        if(GameManager.GameState == "Initialize {}")
        {
            InitializeClick();
        } else if (GameManager.GameState == "Execute {}")
        {
            ExecuteClick();
        }
    }

    void InitializeClick()
    {
        PlayerManager.CmdDealCards();
        PlayerManager.cardsPlayed = 0;
    }

    void ExecuteClick()
    {
        PlayerManager.CmdExecute();
        PlayerManager.CmdGMChangeState("Initialize {}");
    }
}
