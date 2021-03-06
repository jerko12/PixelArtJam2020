﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackingState : PlayerState
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
            player.animator.SetBool("isJetpacking", true);
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
        if (player != null)
        {
            player.currentVelocityUp = Mathf.Lerp(player.currentVelocityUp, player.settings.jetpackSpeed * Time.fixedDeltaTime * player.rigidbody.gravityScale, player.settings.jetpackSpeedChange * Time.fixedDeltaTime);
            player.rigidbody.velocity = new Vector2(0, player.currentVelocityUp);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
        if (player != null)
        {
            player.animator.SetBool("isJetpacking", false);
        }
    }
}
