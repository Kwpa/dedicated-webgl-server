using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerManager : NetworkBehaviour
{
    //---------------------------------------------------------------------//
    // Fields
    //---------------------------------------------------------------------//

    /// <summary>Store GameManager reference</summary>
    GameManager _gmRef;

    /// <summary>Store UIManager reference</summary>
    UIManager _uiManager;

    /// <summary>Is this the local player?</summary>
    bool _localPlayer = false;

    /// <summary>Store player name</summary>
    [SyncVar]
    public string _playerName = "No Name";


    //---------------------------------------------------------------------//
    // Methods
    //---------------------------------------------------------------------//

    /// <summary>
    /// Called for all PlayerManager gameobjects so that it is easier to
    /// reference common elements like UIManager, on server + client
    /// </summary>

    private void OnEnable()
    {
        _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    //---------------------------------------------------------------------//

    /// <summary>
    /// Only called for the local player on client
    /// </summary>

    [Client]
    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        _localPlayer = true;

        SetListerners();

        CmdInitialise(this.netIdentity);
    }

    //---------------------------------------------------------------------//

    /// <summary>
    /// Command on server that initialises the player with a GameManager ref
    /// and updates the _landColourGlobal / _playerName syncvars 
    /// </summary>
    
    [Command(requiresAuthority = false)]
    public void CmdInitialise(NetworkIdentity netid)
    {
        _gmRef = GameObject.Find("GameManager").GetComponent<GameManager>();
        RpcChangeGlobalColour(_gmRef._landColourGlobal);
        string name = _gmRef.AddNewPlayerName();
        _playerName = name;
        RpcSetName(netid.connectionToClient, _playerName);
    }

    //---------------------------------------------------------------------//

    /// <summary>
    /// Rpc run on the returning client only, sets that player's name
    /// quickly - after this the syncvar itself can be accessed
    /// </summary>
    
    [TargetRpc]
    public void RpcSetName(NetworkConnection netconnect, string name)
    {
        print("SetPlayerName: " + name);
        _uiManager.SetPlayerName(name);
    }

    //---------------------------------------------------------------------//

    /// <summary>
    /// Instead of setting listeners in OnEnable, we ensure listeners are
    /// only set on the local PlayerManager this Client controls!
    /// </summary>

    [Client]
    private void SetListerners()
    {
        UIManager.ChangeColourEvent += UpdateColourOnServer;
    }

    //---------------------------------------------------------------------//

    /// <summary>
    /// Only remove listeners / player if it is the local player who
    /// is disabled
    /// </summary>
    
    [Client]
    private void OnDisable()
    {
        if(_localPlayer == true)
        {
            UIManager.ChangeColourEvent -= UpdateColourOnServer;
            _gmRef.RemovePlayer(_playerName);
        }
    }

    //---------------------------------------------------------------------//

    /// <summary>
    /// Wrapper method for command to server 
    /// </summary>

    [Client]
    public void UpdateColourOnServer(string s)
    {
        print(_playerName + " sent " + s + " to server");
        CmdChangeGlobalColour(s, this.netIdentity);
    }

    //---------------------------------------------------------------------//

    /// <summary>
    /// Command on server to set the _landColourGlobal syncvar and propogate
    /// to the clients
    /// </summary>

    [Command(requiresAuthority = false)]
    public void CmdChangeGlobalColour(string s, NetworkIdentity netid)
    {
        print("Server received " + s + " from " + _playerName);
        _gmRef._landColourGlobal = s;
        RpcChangeGlobalColour(_gmRef._landColourGlobal);
    }

    //---------------------------------------------------------------------//

    /// <summary>
    /// RPC to propogate UI update across all clients, current triggers are
    /// initialising PlayerManager and pressing a button
    /// </summary>

    [ClientRpc]
    public void RpcChangeGlobalColour(string s)
    {
        _uiManager.SetLocalLandColour(s);
    }

    //---------------------------------------------------------------------//
}
