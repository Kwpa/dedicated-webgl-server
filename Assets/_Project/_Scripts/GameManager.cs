using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameManager : NetworkBehaviour
{
    //---------------------------------------------------------------------//
    // Fields
    //---------------------------------------------------------------------//

    /// <summary>A variable synced across all GameManager instances</summary>
    [SyncVar]
    public string _landColourGlobal;

    /// <summary>A variable synced across all GameManager instances</summary>
    [SyncVar]
    public int _numberOfPlayers;

    /// <summary>...</summary>
    public List<string> _playerNames;

    /// <summary>...</summary>
    List<string> _names = new List<string>
    {
        "Liam", "Emma", "William", "Olivia", "Noah", "Charlotte", "Benjamin", "Sophia", "Jacob", "Emily", "Logan", "Chloe", "Nathan", "Ava"
    };

    //---------------------------------------------------------------------//
    // Methods
    //---------------------------------------------------------------------//

    /// <summary>
    /// Called for all PlayerManager gameobjects so that it is easier to
    /// reference common elements like UIManager, on server + client
    /// </summary>
    
    public string AddNewPlayerName()
    {
        _numberOfPlayers++;
        string newPlayerName = SelectName();
        _playerNames.Add(newPlayerName);
        return newPlayerName;
    }

    //---------------------------------------------------------------------//

    /// <summary>
    /// Method on applied to Buttons to trigger ChangeColourEvent
    /// </summary>

    public void RemovePlayer(string s)
    {
        if(_playerNames.Contains(s))
        {
            _playerNames.Remove(s);
            _numberOfPlayers--;
        }
    }

    //---------------------------------------------------------------------//

    /// <summary>
    /// Method on applied to Buttons to trigger ChangeColourEvent
    /// </summary>
    
    private string SelectName()
    {
        string tempName = "";
        bool validName = false;
        while (!validName)
        {
            tempName = _names[UnityEngine.Random.Range(0, _names.Count)];
            if (_playerNames.Contains(tempName))
            {
                validName = false;
            }
            else
            {
                validName = true;
            }
        }
        return tempName;
    }

    //---------------------------------------------------------------------//
}
