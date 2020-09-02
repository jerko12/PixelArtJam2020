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

    //enemy oneshot sound call methods

    public void PlaySmallEnemyDeathSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Enemies/SmallMonsterDeath");
        print("Small enemy death sound event called");
    }

    public void PlayBossMonsterDeathSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Enemies/BossMonsterDeath");
        print("Boss Monster death sound event called");
    }

    public void PlayBossMonsterShootSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Enemies/BossMonsterShoot");
        print("Boss Monster Shoot sound event called");
    }

    public void PlayLargeMonsterDeathSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Enemies/LargeMonsterDeath");
        print("LargeMonster death sound event called");
    }

    public void PlayLargeMonsterShootSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Enemies/LargeMonsterShoot");
        print("LargeMonster shoot sound event called");
    }

    public void PlayLargeMonsterStepSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Enemies/LargeMonsterStep");
        print("LargeMonster step sound event called");
    }

    //player oneshot sound call methods

    public void PlayPlayerJumpSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Player/PlayerJump");
        print("Jump sound event Called");
    }

    public void PlayDimensionJumpSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Player/DimensionJump");
        print("Dimension jump sound event Called");
    }

    public void PlayPlayerDeathSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Player/PlayerDeath");
        print("PlayerDeath sound event Called");
    }

    public void PlayPlayerShootSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Player/PlayerShoot");
        print("PlayerShoot sound event Called");
    }

    public void PlayPlayerStepSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Player/PlayerStep");
        print("PlayerStep sound event Called");
    }
}
