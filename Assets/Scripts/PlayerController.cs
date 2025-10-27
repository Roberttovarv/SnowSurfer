using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    float rotation = 3f;
    float baseSpeed = 15f;
    float boostSpeed = 20f;
    float previousRotation;
    float totalRotation;
    bool isTouchingFloor;
    bool canControlPlayer = true;
    int flipCount;
        int boostCounter;




    InputAction moveAction;
    Rigidbody2D myRigidBody;
    ParticleSystem[] particles;
    Vector2 moveVector;
    SurfaceEffector2D surface;
    CrashDetector crashDetector;


    void Start()
    {
        surface = Object.FindFirstObjectByType<SurfaceEffector2D>();
        crashDetector = Object.FindFirstObjectByType<CrashDetector>();
        moveAction = InputSystem.actions.FindAction("Move");
        myRigidBody = GetComponent<Rigidbody2D>();
        particles = GetComponentsInChildren<ParticleSystem>();
        boostCounter = 0;
    }

    void Update()
    {
        if (canControlPlayer)
        {
            RotatePlayer();
            BoostPlayer();
            CalculateFlips();
        }

    }

    void RotatePlayer()
    {
        moveVector = moveAction.ReadValue<Vector2>();
        if (moveVector.x < 0) myRigidBody.AddTorque(rotation);
        if (moveVector.x > 0) myRigidBody.AddTorque(-rotation);
    }

    void BoostPlayer()
    {
        if (moveVector.y > 0)
        {
            surface.speed = boostSpeed;
        }
        else
        {
            surface.speed = baseSpeed;
        }
    }

    public void DisableControls()
    {
        canControlPlayer = false;
    }
    void CalculateFlips()
    {
        float currentRotation = transform.rotation.eulerAngles.z;
        totalRotation += Mathf.DeltaAngle(previousRotation, currentRotation);

        if (totalRotation > 340 || totalRotation < -340)
        {
            flipCount += 1;
            totalRotation = 0f;
        }
        previousRotation = currentRotation;
    }

    public int GetFlipsScore()
    {
        return flipCount * 100;
    }

    public void ActivatePowerUp(PowerUp powerUp)
    {
        if (powerUp.GetPowerUpType() == "LongSpeed")
        {
            baseSpeed += powerUp.GetValueChange();
            boostSpeed += powerUp.GetValueChange();
        }
        if (powerUp.GetPowerUpType() == "torque")
        {
            rotation += powerUp.GetValueChange();
            print($"Activating, new value {rotation}");
        }
        boostCounter++;
        particles[0].Stop();
        particles[1].Play();
    }
    public void DeactivatePowerUp(PowerUp powerUp)
    {
        if (powerUp.GetPowerUpType() == "LongSpeed")
        {
            baseSpeed -= powerUp.GetValueChange();
            boostSpeed -= powerUp.GetValueChange();
        }
        if (powerUp.GetPowerUpType() == "torque")
        {
            rotation -= powerUp.GetValueChange();
            print($"Deactivating, comng to original value {rotation}");

        }
        boostCounter--;
        if (boostCounter == 0)
        {
            
        particles[0].Play();
        particles[1].Stop();
        }

    }
}
