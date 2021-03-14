using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StatCharacter))]
public class Movement : MonoBehaviour
{

    [SerializeField] private StatCharacter statCharacter;

    [SerializeField] private float xMovement, yMovement;

    private Animator animator;

    private string currentAnimation;



    public VariableJoystick variableJoystick;

    const string PLAYER_IDLE = "Player_Idle";
    const string PLAYER_RUN = "Player_Run";
    const string PLAYER_UP = "Player_Up";
    const string PLAYER_DOWN = "Player_Down";

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        xMovement = Input.GetAxis("Horizontal");
        yMovement = Input.GetAxis("Vertical");

        if(variableJoystick != null)
        {
            xMovement = variableJoystick.Horizontal;
            yMovement = variableJoystick.Vertical;
        }

        MoveAction();

    }

    private void MoveAction()
    {
        transform.Translate(xMovement * Time.deltaTime * statCharacter.Speed, yMovement * Time.deltaTime * statCharacter.Speed, 0);
        //Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);

        if(yMovement > 0)
        {
            if (yMovement > Mathf.Abs(xMovement))
                ChangeAnimationState(PLAYER_UP);
            else if(xMovement > 0)
            {
                transform.localScale = new Vector2(-1, 1);
                ChangeAnimationState(PLAYER_RUN);
            }   else if(xMovement < 0)
            {
                transform.localScale = new Vector2(1, 1);
                ChangeAnimationState(PLAYER_RUN);
            }
            else{
                transform.localScale = new Vector2(1, 1);
                ChangeAnimationState(PLAYER_IDLE);
            }
        } else
        {
            if (Mathf.Abs(yMovement) > Mathf.Abs(xMovement))
                ChangeAnimationState(PLAYER_DOWN);
            else if (xMovement > 0)
            {
                transform.localScale = new Vector2(-1, 1);
                ChangeAnimationState(PLAYER_RUN);
            }
            else if (xMovement < 0)
            {
                transform.localScale = new Vector2(1, 1);
                ChangeAnimationState(PLAYER_RUN);
            } else
            {
                transform.localScale = new Vector2(1, 1);
                ChangeAnimationState(PLAYER_IDLE);
            }
        }
    }

    void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimation == newAnimation) return;

        animator.Play(newAnimation);
        currentAnimation = newAnimation;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(ConstVariable.TAG_UNBREAKABLE_BLOCK))
        {

        }
    }
}
