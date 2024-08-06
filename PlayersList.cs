using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersList : MonoBehaviour
{
    List<Player> listPlayers;

    public PlayersList(List<Player> listPlayers) => this.listPlayers = listPlayers;
}
