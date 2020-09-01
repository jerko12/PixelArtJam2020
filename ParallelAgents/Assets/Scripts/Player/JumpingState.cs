using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingState : PlayerState
{
    public float currentVelocityUp = 0;


    private void Input_onJumpEnter()
    {
        if (player != null)
        {
            currentVelocityUp = player.settings.jumpSpeed;
        }
        StartCoroutine("jumpExitTime");
    }

    private void Input_onJumpHold()
    {
        
    }

    private void Input_onJumpExit()
    {
        player.canJump = false;
        StopCoroutine("jumpExitTime");
    }

    IEnumerator jumpExitTime()
    {

        yield return new WaitForSeconds(player.settings.maxJumpTime);
        player.canJump = false;
    }






    public override void AwakeState()
    {
        base.AwakeState();

    }

    public override void StartState()
    {
        base.StartState();
        player.canJump = false;
    }

    

    public override void EnterState()
    {
        base.EnterState();
        GameManager.game.audioHandler.PlayPlayerJumpSound();
        GameManager.game.eventHandler.input.onJumpEnter += Input_onJumpEnter;
        GameManager.game.eventHandler.input.onJumpHold += Input_onJumpHold;
        GameManager.game.eventHandler.input.onJumpExit += Input_onJumpExit;
    }

    public override void StateCheck()
    {
        base.StateCheck();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if(!player.canJump && !player.grounded)
        {
            if (currentVelocityUp > 0)
            {
                currentVelocityUp -= 1 * Time.deltaTime;
            }
            else
            {
                currentVelocityUp -= 2 * Time.deltaTime;
            }
        }

        if (player.grounded)
        {
            currentVelocityUp = 0;
        }
    }

    public override void FixedUpdateState()
    {
        base.FixedUpdateState();
    }

    public override void ExitState()
    {
        base.ExitState();
        GameManager.game.eventHandler.input.onJumpEnter -= Input_onJumpEnter;
        GameManager.game.eventHandler.input.onJumpHold -= Input_onJumpHold;
        GameManager.game.eventHandler.input.onJumpExit -= Input_onJumpExit;
    }
}
