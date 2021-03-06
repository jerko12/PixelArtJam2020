﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public Player player;
    private void Awake()
    {
       
        AwakeState();
    }

    private void Start()
    {
        player = GameManager.game.player;
        StartState();
    }

    public virtual void AwakeState()
    {

    }

    public virtual void StartState()
    {

    }

    public virtual void EnterState()
    {

    }

    public virtual void StateCheck()
    {

    }

    public virtual void UpdateState()
    {

    }

    public virtual void FixedUpdateState()
    {

    }

    public virtual void ExitState()
    {

    }
}
