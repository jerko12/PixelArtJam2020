using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputEvents : MonoBehaviour
{

    private void Update()
    {
        if (GameManager.game.input.jump) { JumpHold(); }
        if (GameManager.game.input.shift) { ShiftDimensionHold(); }
        if (GameManager.game.input.shoot) { ShootHold(); }
    }

    // Jump Event
    public event Action onJumpEnter;
    public void JumpEnter()
    {
        onJumpEnter?.Invoke();
    }

    public event Action onJumpHold;
    public void JumpHold()
    {
        onJumpHold?.Invoke();
    }

    public event Action onJumpExit;
    public void JumpExit()
    {
        onJumpExit?.Invoke();
    }

    // Shift Dimension Event
    public event Action onShiftDimensionEnter;
    public void ShiftDimensionEnter()
    {
        onShiftDimensionEnter?.Invoke();
    }

    public event Action onShiftDimensionHold;
    public void ShiftDimensionHold()
    {
        onShiftDimensionHold?.Invoke();
    }

    public event Action onShiftDimensionExit;
    public void ShiftDimensionExit()
    {
        onShiftDimensionExit?.Invoke();
    }

    // Shoot Event
    public event Action onShootEnter;
    public void ShootEnter()
    {
        onShootEnter?.Invoke();
    }

    public event Action onShootHold;
    public void ShootHold()
    {

        onShootHold?.Invoke();
    }

    public event Action onShootExit;
    public void ShootExit()
    {
        onShootExit?.Invoke();
    }
}
