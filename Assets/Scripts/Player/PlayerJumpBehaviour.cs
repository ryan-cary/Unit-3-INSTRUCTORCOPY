using UnityEngine;

public abstract class PlayerJumpBehaviour : MonoBehaviour
{
    private bool isGrounded;
    protected bool jumpInput;

    [SerializeField] protected float force;

    /*
     * void GetReferences()
    {
        rigidbody = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
    }
    */

    void Update()
    {
        ApplyJump();

        if (ShouldJump())
        { Jump(); }
    }

    protected virtual void ApplyJump() 
    { }

    protected abstract void Jump();

    private bool ShouldJump()
    { return jumpInput && isGrounded; }

    public void SetGrounded(bool value)
    { isGrounded = value; }

    public void SetJumpInput(bool value)
    { jumpInput = value; }
}