using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isJumpingHash;
    int isForwardHash;
    int isBackwardHash;
    int isLeftHash;
    int isRightHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isLeftHash = Animator.StringToHash("isLeft");
        isRightHash = Animator.StringToHash("isRight");
        isForwardHash = Animator.StringToHash("isForward");
        isBackwardHash = Animator.StringToHash("isBackward");
        isJumpingHash = Animator.StringToHash("isJumping");
    }

    // Update is called once per frame
    void Update()
    {
        bool forwardPressed = Input.GetKey("z");
        bool backwardPressed = Input.GetKey("s");
        bool leftPressed = Input.GetKey("q");
        bool rightPressed = Input.GetKey("d");
        bool jumpPressed = Input.GetKey("space");
        //
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isLeft = animator.GetBool(isLeftHash);
        bool isRight = animator.GetBool(isRightHash);
        bool isForward = animator.GetBool(isForwardHash);
        bool isBackward = animator.GetBool(isBackwardHash);
        bool isJumping = animator.GetBool(isJumpingHash);
        if (!isWalking)
        {
            // if walk
            if (forwardPressed || backwardPressed || leftPressed || rightPressed)
            {
                animator.SetBool(isWalkingHash, true);
            }
            // walk forward
            if (forwardPressed)
            {
                animator.SetBool(isForwardHash, true);
                animator.SetBool(isBackwardHash, false);
                animator.SetBool(isLeftHash, false);
                animator.SetBool(isRightHash, false);
            }
            // walk backward
            if (backwardPressed)
            {   
                animator.SetBool(isForwardHash, false);
                animator.SetBool(isBackwardHash, true);
                animator.SetBool(isLeftHash, false);
                animator.SetBool(isRightHash, false);
            }
            // walk left
            if (leftPressed)
            {   
                animator.SetBool(isForwardHash, false);
                animator.SetBool(isBackwardHash, false);
                animator.SetBool(isLeftHash, true);
                animator.SetBool(isRightHash, false);
            }
            // walk right
            if (rightPressed)
            {   
                animator.SetBool(isForwardHash, false);
                animator.SetBool(isBackwardHash, false);
                animator.SetBool(isLeftHash, false);
                animator.SetBool(isRightHash, true);
            }
        }
        // change state
        if (isWalking)
        {
            if (!(forwardPressed || backwardPressed || leftPressed || rightPressed))
            {
                animator.SetBool(isWalkingHash, false);
            }
            // forward
            if (forwardPressed)
            {
                animator.SetBool(isForwardHash, true);
            }
            else
            {
                animator.SetBool(isForwardHash, false);
            }
            // backward
            if (backwardPressed)
            {
                animator.SetBool(isBackwardHash, true);
            }
            else
            {
                animator.SetBool(isBackwardHash, false);
            }
            // left
            if (leftPressed)
            {
                animator.SetBool(isLeftHash, true);
            }
            else
            {
                animator.SetBool(isLeftHash, false);
            }
            // right
            if (rightPressed)
            {
                animator.SetBool(isRightHash, true);
            }
            else
            {
                animator.SetBool(isRightHash, false);
            }
        }
        /////
        if (!isJumping && jumpPressed)
        {
            animator.SetBool(isJumpingHash, true);
        }
        if (isJumping && !jumpPressed)
        {
            animator.SetBool(isJumpingHash, false);
        }
    }
}
