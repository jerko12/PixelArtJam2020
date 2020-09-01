using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{

    [FMODUnity.EventRef]
    public string smallEnemyDeathEvent;

    [FMODUnity.EventRef]
    public string playerJumpSoundEvent;



    FMOD.Studio.EventInstance LevelMusic;
    private void Awake()
    {
        GameManager.game.audioHandler = this;
        //Calls Level Music Event

        LevelMusic.start();
    }

    private void Start()
    {
        GameManager.game.eventHandler.game.afterChangeUniverse += AudioUniverseSwitch;
        LevelMusic = FMODUnity.RuntimeManager.CreateInstance("event:/Music/LevelMusic");
    }

    public void AudioUniverseSwitch()
    {
        Debug.Log("Switch Audio to Universe " + GameManager.game.scene.currentUniverse);

        //calls parameters for each level, maybe these should be nested inside a switch
        //statement that corresponds with the level???

        switch (GameManager.game.scene.currentUniverse)
        {
            case SceneHandler.Universe.Main: LevelMusic.setParameterByName("World", 0); break;
            case SceneHandler.Universe.Neon: LevelMusic.setParameterByName("World", 1); break ;
            case SceneHandler.Universe.Noir: LevelMusic.setParameterByName("World", 2); break;
            case SceneHandler.Universe.Space: LevelMusic.setParameterByName("World", 3); break;
        }

        // Audio switch code here!
        // This code every time you press spacebar
        // use: GameManager.game.scene.currentUniverse; to get the current universe

    }

    public void PlaySmallEnemyDeathSound()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached(smallEnemyDeathEvent, gameObject);
    }

    public void PlayPlayerJumpSound()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached(playerJumpSoundEvent, gameObject);
    }
}
