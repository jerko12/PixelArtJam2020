using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    private void Awake()
    {
        AwakeState();
    }

    private void Start()
    {
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
