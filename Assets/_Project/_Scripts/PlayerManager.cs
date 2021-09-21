using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


public class PlayerManager : NetworkBehaviour
{
    GameManager _gmRef;


    public override void OnStartServer()
    {
        base.OnStartServer();
        _gmRef = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void PressButtonToSetColour(string s)
    {
        PressButtonToSetColour(s);
    }

    [Command(requiresAuthority = false)]
    public void ChangeColour(string s)
    {
        _gmRef._landColourGlobal = s;
        
    }
}
