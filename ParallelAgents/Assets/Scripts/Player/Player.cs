using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;

    public RunningState run;
    public JumpingState jump;
    public JetpackingState jetpack;
    public DeadState dead;

    public enum state
    {
        run,
        jump,
        jetpack,
        dead
    }

    public state currentState;

    public void init()
    {
        currentState = state.run;
    }
    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("IsJumping", GameManager.game.input.jump);
        //animator.SetBool("",GameManager.game.input.);
    }
}
