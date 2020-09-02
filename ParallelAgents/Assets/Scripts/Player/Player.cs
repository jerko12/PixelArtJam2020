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

    public bool canShoot = true;

    public GameObject gunArm;
    public GameObject gunBarrel;
    public GameObject bullet;

    public RunningState run;
    public JumpingState jump;
    public JetpackingState jetpack;
    public FallingState fall;
    public DeadState dead;

    public int energy;

    //Hide from inspector later
    public float currentVelocityUp = 0;

    public enum state
    {
        run,
        jump,
        jetpack,
        fall,
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
                case state.fall: fall.ExitState(); break;
                case state.dead: dead.ExitState(); break;
            }
            currentState = newState;

            switch (currentState)
            {
                case state.run: run.EnterState(); break;
                case state.jump: jump.EnterState(); break;
                case state.jetpack: jetpack.EnterState(); break;
                case state.fall: fall.EnterState();break;
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
        GameManager.game.eventHandler.input.onJumpExit += Input_onJumpExit;
        init();
        GameManager.game.player = this;
    }

   

    private void Input_onJumpEnter()
    {
        if (grounded)
        {
            SwitchState(state.jump);
            GameManager.game.audioHandler.PlayPlayerJumpSound();
        }
        else
        {
            SwitchState(state.jetpack);
        }
    }

    private void Input_onJumpExit()
    {
        SwitchState(state.fall);
    }




    // Start is called before the first frame update
    void Start()
    {
        GameManager.game.eventHandler.input.onShootEnter += Input_onShootEnter;
    }

    private void Input_onShootEnter()
    {
        Debug.Log("Shoot");
        
    }

    // Update is called once per frame
    void Update()
    {
        
        switch (currentState)
        {
            case state.run: run.StateCheck(); run.UpdateState(); break;
            case state.jump: jump.StateCheck(); jump.UpdateState(); break;
            case state.jetpack: jetpack.StateCheck(); jetpack.UpdateState(); break;
            case state.fall: fall.StateCheck(); fall.UpdateState(); break;
            case state.dead: dead.StateCheck(); dead.UpdateState(); break;
        }


        

        animator.SetBool("IsGrounded", grounded);
        //animator.SetBool("",GameManager.game.input.);
    }

    void FixedUpdate()
    {
        switch (currentState)
        {
            case state.run: run.FixedUpdateState();  break;
            case state.jump: jump.FixedUpdateState(); break;
            case state.jetpack: jetpack.FixedUpdateState(); break;
            case state.fall: fall.FixedUpdateState(); break;
            case state.dead: dead.FixedUpdateState(); break;
        }

        //gun arm system and shooting
        gunSystem();
        
    }

    public void gunSystem()
    {
        Vector3 aimPos = GameManager.game.mainCam.ScreenToWorldPoint(new Vector3(GameManager.game.input.shootPos.x, GameManager.game.input.shootPos.y,10));
        //print(aimPos);
        Vector3 lookDirection = aimPos.normalized - (transform.position +  gunArm.transform.position);

        //float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        //gunArm.transform.rotation = Quaternion.LookRotation(lookDirection.normalized);
        gunArm.transform.LookAt(aimPos, transform.forward);
        if (GameManager.game.input.shoot && canShoot)
        {
            Instantiate(bullet, gunBarrel.transform.position, gunArm.transform.rotation);
            canShoot = false;
        }
        if(!GameManager.game.input.shoot && !canShoot)
        {
            canShoot = true;
        }

        
    }

    public bool IsGrounded()
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
