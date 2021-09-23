using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class DWSNetworkManager : NetworkManager
{
    //---------------------------------------------------------------------//
    // Methods
    //---------------------------------------------------------------------//

    /// <param name="conn">Connection from client.</param>
    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        base.OnServerAddPlayer(conn);

        /// additional code can be put here, however the GameManager/PlayerManagers
        /// in this example is in control of things you could put here

    }

    //---------------------------------------------------------------------//

    /// <summary>
    /// Called on the server when a client disconnects.
    /// <para>This is called on the Server when a Client disconnects from the Server. Use an override to decide what should happen when a disconnection is detected.</para>
    /// </summary>
    /// <param name="conn">Connection from client.</param>
    public override void OnServerDisconnect(NetworkConnection conn)
    {
        base.OnServerDisconnect(conn);

        /// additional code can be put here, however the GameManager/PlayerManagers
        /// in this example is in control of things you could put here
    }

    //---------------------------------------------------------------------//
}
