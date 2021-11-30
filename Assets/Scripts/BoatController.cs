
using UnityEngine;
public class BoatController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";

    private const string VERTICAL = "Vertical";

    public float horizontalInput;

    public float verticalInput;

    private float currentSteerAngle;

    private float currentbreakForce;

    private bool isBreaking;

    [SerializeField]
    public float motorForce;

    [SerializeField]
    private float breakForce;

    [SerializeField]
    private float maxSteerAngle;


    private void FixedUpdate()
    {
        GetInput();
        // HandleMotor();
        // HandleSteering();
        // UpdateWheels();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        isBreaking = Input.GetKey(KeyCode.Space);
    }

}