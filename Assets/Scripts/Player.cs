using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Action PlayerDetected;

    [SerializeField] private Joystick joystick;
    [SerializeField] private CharacterController playerController;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Transform barrel;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;

    private Vector2 stickInput;
    private Vector3 moveDirection;
    private Vector3 lookDirection;

    private bool isHidden;
    private bool isDetected;
    private bool animationSwitched;

    private void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        if (isDetected) return;

        stickInput = joystick.Direction;

        if (stickInput.magnitude > 0.1f)
        {
            moveDirection = new Vector3(stickInput.x, 0, stickInput.y);
            playerController.SimpleMove(moveDirection.normalized * moveSpeed);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDirection), rotationSpeed * Time.deltaTime);
            lookDirection = new Vector3(stickInput.x, 0, stickInput.y);

            if (animationSwitched) return;

            playerAnimator.SetBool("Run", true);
            animationSwitched = true;
            barrel.localPosition = new Vector3(0, 0.7f, 0);

            isHidden = false;
        }
        else
        {
            playerAnimator.SetBool("Run", false);
            animationSwitched = false;
            barrel.localPosition = new Vector3(0, 0.1f, 0);

            isHidden = true;
        }
    }

    public void Detected()
    {
        playerAnimator.SetBool("Run", false);
        joystick.gameObject.SetActive(false);
        isDetected = true;
        PlayerDetected?.Invoke();
    }

    public bool GetStatusHidden()
    {
        return isHidden;
    }
}
