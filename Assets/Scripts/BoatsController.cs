
using UnityEngine;
public class BoatsController : MonoBehaviour
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
        HandleMotor();
        HandleSteering();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleMotor()
    {
        this.gameObject.transform.Translate(Vector3.forward * (verticalInput / 5));
    }

    private void HandleSteering()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up * motorForce * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(-Vector3.up * motorForce * Time.deltaTime);
        }
    }

}