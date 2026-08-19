using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public abstract class PlayerCharacterControllerJumpBehaviour : PlayerJumpBehaviour
{
    [SerializeField] private float decay;
    private float jumpModifier;

    private CharacterController controller;

    void Start()
    { controller = GetComponent<CharacterController>(); }

    protected override void ApplyJump()
    {
        jumpModifier = jumpModifier - decay * Time.deltaTime;
        if (jumpModifier < 0)
        {
            jumpModifier = 0;
        }

        Vector3 movementVector = Physics.gravity;
        movementVector += Vector3.up * jumpModifier;

        controller.Move(movementVector * Time.deltaTime);
    }

    protected override void Jump()
    {
        jumpModifier = force;
    }
}
