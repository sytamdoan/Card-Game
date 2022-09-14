using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
public class UImanager : NetworkBehaviour
{
    public PlayerManager PlayerManager;
    public GameManager GameManager;
    public GameObject Button;
    public GameObject PlayerText;
    public GameObject OpponentText;

    Color blueColor = new Color32(17, 216, 238, 255);
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); 
    }

    public void UpdatePlayerText()
    {
        PlayerText.GetComponent<Text>().text = "Player BP: " + GameManager.PlayerBP + "\nPlayer Variables: " + GameManager.PlayerVariable;
        OpponentText.GetComponent<Text>().text = "Opponent BP: " + GameManager.OpponentBP + "\nOpponent Variables: " + GameManager.OpponentVariable;
    }

    public void UpdateButtonText(string gameState)
    {
        Button = GameObject.Find("Button");
        Button.GetComponentInChildren<Text>().text = gameState;
    }
    // Update is called once per frame
    public void highLightTurn (int turnOrder)
    {
        PlayerManager = NetworkClient.connection.identity.GetComponent<PlayerManager>();
        if(turnOrder < 10)
        {
            if(turnOrder == 0)
            {
                if (PlayerManager.IsMyTurn)
                {
                    PlayerManager.PlayerSockets[PlayerManager.cardsPlayed].GetComponent<Outline>().effectColor = Color.magenta;
                } else
                {
                    PlayerManager.EnemySockets[PlayerManager.cardsPlayed].GetComponent<Outline>().effectColor = Color.magenta;
                }
            } else if (turnOrder > 0)
            {
                if (PlayerManager.IsMyTurn)
                {
                    PlayerManager.PlayerSockets[PlayerManager.cardsPlayed].GetComponent<Outline>().effectColor = Color.magenta;

                    if(isClientOnly && turnOrder > 1)
                    {
                        PlayerManager.EnemySockets[PlayerManager.cardsPlayed - 1].GetComponent<Outline>().effectColor = blueColor;
                    } 
                    else
                    {
                        PlayerManager.EnemySockets[PlayerManager.cardsPlayed].GetComponent<Outline>().effectColor = blueColor;
                    }
                } 
                else
                {
                    PlayerManager.PlayerSockets[PlayerManager.cardsPlayed].GetComponent<Outline>().effectColor = blueColor;

                    if(isClientOnly)
                    {
                        PlayerManager.EnemySockets[PlayerManager.cardsPlayed - 1].GetComponent<Outline>().effectColor = Color.magenta;
                    }
                    else
                    {
                        PlayerManager.EnemySockets[PlayerManager.cardsPlayed].GetComponent<Outline>().effectColor = Color.magenta;
                    }
                }
            }
        }
        else if(turnOrder == 10)
        {
            for(int i = 0; i < 5; i++)
            {
                PlayerManager.PlayerSockets[i].GetComponent<Outline>().effectColor = blueColor;
                PlayerManager.EnemySockets[i].GetComponent<Outline>().effectColor = blueColor;
            }
        }
    }
}
