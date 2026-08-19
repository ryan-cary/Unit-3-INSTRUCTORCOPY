using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class PlayerRigidBodyJumpBehaviour : PlayerJumpBehaviour
{
    [SerializeField] private ForceMode forceMode = ForceMode.Impulse;
    new private Rigidbody rigidbody;

    void Start()
    { rigidbody = GetComponent<Rigidbody>(); }

    protected virtual void ApplyJump()
    { }

    protected override void Jump()
    {
        rigidbody.AddForce(Vector3.up * force, ForceMode.Impulse);
    }
}