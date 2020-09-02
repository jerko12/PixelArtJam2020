using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningState : PlayerState
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
        player.canJump = true;
        if (player != null)
        {
            player.animator.SetBool("isRunning", true);
        }
    }

    public override void StateCheck()
    {
        base.StateCheck();
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void FixedUpdateState()
    {
        base.FixedUpdateState();
    }

    public override void ExitState()
    {
        base.ExitState();
        if (player != null)
        {
            player.animator.SetBool("isRunning", false);
        }
    }
}
