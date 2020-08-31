using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    private void Awake()
    {
        GameManager.game.audioHandler = this;
        //Calls Level Music Event
        FMOD.Studio.EventInstance LevelMusic;

    }

    private void Start()
    {
        GameManager.game.eventHandler.game.afterChangeUniverse += AudioUniverseSwitch;
        LevelMusic = FMODUnity.RuntimeManager.CreateInstance("event:/Music/LevelMusic")
    }

    public void AudioUniverseSwitch()
    {
        Debug.Log("Switch Audio to Universe " + GameManager.game.scene.currentUniverse);

        //calls parameters for each level, maybe these should be nested inside a switch
        //statement that corresponds with the level???
        LevelMusic.setParameterByName("World", "Base");
        LevelMusic.setParameterByName("World", "Neon");
        LevelMusic.setParameterByName("World", "Noir");
        LevelMusic.setParameterByName("World", "Spaceship");
        // Audio switch code here!
        // This code every time you press spacebar
        // use: GameManager.game.scene.currentUniverse; to get the current universe

    }

}
