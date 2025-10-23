using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    float rotation = .6f;
    InputAction moveAction;
    Rigidbody2D myRigidBody;
    ParticleSystem particles;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 moveVector;
        moveVector = moveAction.ReadValue<Vector2>();
        if (moveVector.x < 0) myRigidBody.AddTorque(rotation);
        if (moveVector.x > 0) myRigidBody.AddTorque(-rotation);

    }
}
