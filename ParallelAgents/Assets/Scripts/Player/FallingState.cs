using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingState : PlayerState
{
    public override void AwakeState()
    {
        base.AwakeState();

    }

    public override void StartState()
    {
        base.StartState();
    }

    public override void EnterState()
    {
        base.EnterState();
        if (player != null)
        {
            player.animator.SetBool("isFalling", true);
        }
    }

    public override void StateCheck()
    {
        player.grounded = player.IsGrounded();
        if (player.grounded)
        {
            
            player.SwitchState(Player.state.run);
        }
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void FixedUpdateState()
    {
        base.FixedUpdateState();

        if (player != null)
        {
            player.currentVelocityUp = Mathf.Lerp(player.currentVelocityUp, -player.settings.fallSpeed * Time.fixedDeltaTime * player.rigidbody.gravityScale, player.settings.fallSpeedChange * Time.fixedDeltaTime);
            player.rigidbody.velocity = new Vector2(0, player.currentVelocityUp);
        }
    }

    public override void ExitState()
    {
        base.ExitState();

        if (player != null)
        {
            player.animator.SetBool("isFalling", false);
        }
    }
}