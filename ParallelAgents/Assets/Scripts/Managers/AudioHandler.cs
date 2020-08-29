using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    private void Awake()
    {
        GameManager.game.audioHandler = this;

    }

    private void Start()
    {
        GameManager.game.eventHandler.game.afterChangeUniverse += AudioUniverseSwitch;
    }

    public void AudioUniverseSwitch()
    {
        Debug.Log("Switch Audio to Universe " + GameManager.game.scene.currentUniverse);
        // Audio switch code here!
        // This code every time you press spacebar
        // use: GameManager.game.scene.currentUniverse; to get the current universe
        
    }

}
