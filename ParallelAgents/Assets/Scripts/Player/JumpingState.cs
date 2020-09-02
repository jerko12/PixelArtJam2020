using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingState : PlayerState
{
    

    /*
    private void Input_onJumpEnter()
    {
        if (player != null)
        {
            currentVelocityUp = player.settings.jumpSpeed;
        }
        StartCoroutine("jumpExitTime");
    }


    private void Input_onJumpExit()
    {
        player.canJump = false;
        StopCoroutine("jumpExitTime");
    }

    
    */

    private float timer = 0;





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
        if (player != null)
        {
            //player.currentVelocityUp = player.settings.jumpSpeed;
            player.animator.SetBool("isJumping", true);
            player.currentVelocityUp = player.settings.jumpSpeed * Time.fixedDeltaTime * player.rigidbody.gravityScale;
        }

        timer = 0;
    }


    public override void StateCheck()
    {
        base.StateCheck();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        timer += Time.deltaTime;
        if(timer >= player.settings.maxJumpTime && player != null)
        {
            player.SwitchState(Player.state.fall);
        }

        if (!player.canJump && !player.grounded)
        {
            if (player.currentVelocityUp > 0)
            {
                player.currentVelocityUp -= 1 * Time.deltaTime;
            }
            else
            {
                player.SwitchState(Player.state.fall);
            }
        }
        
    }


    public override void FixedUpdateState()
    {
        base.FixedUpdateState();
        if (player != null)
        {
            player.rigidbody.velocity = new Vector2(0, player.currentVelocityUp);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
        if (player != null)
        {
            player.animator.SetBool("isJumping", false);
        }

    }
}
