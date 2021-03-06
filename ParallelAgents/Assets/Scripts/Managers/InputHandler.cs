﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private InputSystem input;

    public bool jump;
    public bool shift;
    public bool shoot;
    public Vector2 shootPos;
    private void Awake()
    {
        input = new InputSystem();

        input.Player.Jump.performed += ctx => { jump = (ctx.ReadValue<float>() > 0.85f); GameManager.game.eventHandler.input.JumpEnter(); };
        input.Player.Jump.canceled += ctx => { jump = false; GameManager.game.eventHandler.input.JumpExit(); };

        input.Player.ShiftDimension.performed += ctx => { shift = (ctx.ReadValue<float>() > 0.85f); GameManager.game.eventHandler.input.ShiftDimensionEnter(); };
        input.Player.ShiftDimension.canceled += ctx => { shift = false; GameManager.game.eventHandler.input.ShiftDimensionExit(); };

        input.Player.Shoot.performed += ctx => {shoot = (ctx.ReadValue<float>() > 0.85f); GameManager.game.eventHandler.input.ShootEnter(); };
        input.Player.Shoot.canceled += ctx => { shoot = false; GameManager.game.eventHandler.input.ShootExit(); };

        input.Player.ShootLocation.performed += ctx => shootPos = ctx.ReadValue<Vector2>();
        input.Player.ShootLocation.canceled += ctx => shootPos = Vector2.zero;

        GameManager.game.input = this;
    }

    private void OnEnable()
    {
        input.Enable();
    }
}
