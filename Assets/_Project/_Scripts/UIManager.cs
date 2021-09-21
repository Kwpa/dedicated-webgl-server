using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    GameManager _gmRef;
    public TextMeshProUGUI _text;

    private void Start()
    {
        _gmRef = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = _gmRef._landColourGlobal;
    }
}
