using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public InputEvents input;
    public GameEvents game;

    private void Awake()
    {
        GameManager.game.eventHandler = this;   
    }
}
