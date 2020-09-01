using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerSettings settings;
    public Animator animator;
    public Rigidbody2D rigidbody;
   
    public float groundCheckDistance;
    public LayerMask groundCheckLayerMask;
    public bool grounded = false;
    public bool canJump = false;

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
        grounded = false;
        


    }

    public void SwitchState(state newState)
    {
        if(newState != currentState)
        {
            switch (currentState)
            {
                case state.run: run.ExitState();break ;
                case state.jump: jump.ExitState(); break;
                case state.jetpack: jetpack.ExitState(); break;
                case state.dead: dead.ExitState(); break;
            }
            currentState = newState;

            switch (currentState)
            {
                case state.run: run.EnterState(); break;
                case state.jump: jump.EnterState(); break;
                case state.jetpack: jetpack.EnterState(); break;
                case state.dead: dead.EnterState(); break;
            }
        }
    }

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        rigidbody = gameObject.GetComponent<Rigidbody2D>();

        run = GetComponent<RunningState>();
        jump = GetComponent<JumpingState>();
        jetpack = GetComponent<JetpackingState>();
        dead = GetComponent<DeadState>();

        GameManager.game.eventHandler.input.onJumpEnter += Input_onJumpEnter;



        init();
        GameManager.game.player = this;
    }

    private void Input_onJumpEnter()
    {
        SwitchState(state.jump);
        GameManager.game.audioHandler.PlayPlayerJumpSound();
    }






    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        grounded = IsGrounded();
        if (grounded)
        {
            if (!canJump)
            {
                canJump = true;
                SwitchState(state.run);
            }
        }
       
        
        animator.SetBool("IsJumping", GameManager.game.input.jump);
        
        animator.SetBool("IsGrounded", grounded);

        switch (currentState)
        {
            case state.run: ; break;
            case state.jump:; break;
            case state.jetpack:; break;
            case state.dead:; break;
        }

        //animator.SetBool("",GameManager.game.input.);
    }

    
    bool IsGrounded()
    {
        bool isGrounded = false;
        RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, Vector2.down,groundCheckDistance,groundCheckLayerMask);
        if (hit)
        {
            isGrounded = true;
        }

        return isGrounded;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(gameObject.transform.position, gameObject.transform.position + Vector3.down * groundCheckDistance);
    }
}
