using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputEvents : MonoBehaviour
{
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
}
