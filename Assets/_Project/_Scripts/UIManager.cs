using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    //---------------------------------------------------------------------//
    // Fields
    //---------------------------------------------------------------------//

    /// <summary>A static event that, when a Button is clicked, sends the
    /// string value of a Button component</summary>
    public static event System.Action<string> ChangeColourEvent;

    /// <summary>A TMPro reference to a text box - must be filled in
    /// in the Editor - is used to display player name</summary>
    public TextMeshProUGUI _playerNameText;

    /// <summary>A TMPro reference to a text box - must be filled in
    /// in the Editor - is used to display button click output</summary>
    public TextMeshProUGUI _buttonOutputText;

    //---------------------------------------------------------------------//
    // Methods
    //---------------------------------------------------------------------//

    /// <summary>
    /// Sets the player name text element string value
    /// </summary>

    public void SetPlayerName(string s)
    {
        _playerNameText.text = s;
    }

    //---------------------------------------------------------------------//

    /// <summary>
    /// Method on applied to Buttons to trigger ChangeColourEvent
    /// </summary>

    public void PressButtonToSetColour(string s)
    {
        ChangeColourEvent?.Invoke(s);
    }

    //---------------------------------------------------------------------//

    /// <summary>
    /// Sets the output text element string value
    /// </summary>

    public void SetLocalLandColour(string landColour)
    {
        _buttonOutputText.text = landColour;
    }

    //---------------------------------------------------------------------//
}
