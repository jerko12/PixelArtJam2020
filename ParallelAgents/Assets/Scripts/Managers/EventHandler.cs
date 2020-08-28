using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public InputEvents input;

    private void Awake()
    {
        GameManager.game.eventHandler = this;   
    }
}
