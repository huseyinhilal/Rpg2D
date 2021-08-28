using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private float currentMoveSpeed;
    public float diagonalMoveModifier;

    private Animator anim;
    private bool playerMoving;
    public Vector2 lastMove;
    private Rigidbody2D myRigidBody;

    private static bool playerExist;

    private bool atacking;
    public float atackTime;
    private float atackTimeCounter;

    public string startPoint;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
        if (!playerExist)
        {
            playerExist = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        playerMoving = false;
        
        if(!atacking)
        {


            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") <-0.5)
            {
                //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
                myRigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * currentMoveSpeed, myRigidBody.velocity.y);
                playerMoving = true;
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            }

            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5)
            {
                //transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, Input.GetAxisRaw("Vertical") * currentMoveSpeed);
                playerMoving = true;
                lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
            }
        
            if(Input.GetAxisRaw("Horizontal")<0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
            {
                myRigidBody.velocity = new Vector2(0f, myRigidBody.velocity.y);
            }

            if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, 0f);
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                atackTimeCounter = atackTime;
                atacking = true;
                myRigidBody.velocity = Vector2.zero;
                anim.SetBool("Attack", true);
            }

            if(Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f && Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f)
            {
                currentMoveSpeed = moveSpeed * diagonalMoveModifier;
            }
            else
            {
                currentMoveSpeed = moveSpeed; 
            }

        }

        if(atackTimeCounter > 0)
        {
            atackTimeCounter -= Time.deltaTime;
        }
        if(atackTimeCounter <= 0)
        {
            atacking = false;
            anim.SetBool("Attack", false);
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
        

    }
}
