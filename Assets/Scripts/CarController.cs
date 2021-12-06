using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class CarController : MonoBehaviour
{
	
    private const string HORIZONTAL = "Horizontal";

    private const string VERTICAL = "Vertical";

    private float horizontalInput;

    private float verticalInput;

    private float currentSteerAngle;

    private float currentbreakForce;

    private bool isBreaking;

    [SerializeField]
    private float motorForce;   
	

    [SerializeField]
    private float breakForce;

    [SerializeField]
    private float maxSteerAngle;

    [SerializeField]
    private WheelCollider frontLeftWheelCollider;

    [SerializeField]
    private WheelCollider frontRightWheelCollider;

    [SerializeField]
    private WheelCollider rearLeftWheelCollider;

    [SerializeField]
    private WheelCollider rearRightWheelCollider;

    [SerializeField]
    private Transform frontLeftWheelTransform;

    [SerializeField]
    private Transform frontRightWheeTransform;

    [SerializeField]
    private Transform rearLeftWheelTransform;

    [SerializeField]
    private Transform rearRightWheelTransform;

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
		Update();
    }
	public int startingPitch = 0;
    AudioSource audioSource;
	
     void Start()
    {
        //Fetch the AudioSource from the GameObject
        audioSource = GetComponent<AudioSource>();

        //Initialize the pitch
        audioSource.pitch = startingPitch;
    }
	
    void Update()
    {
        
        if (frontLeftWheelCollider.motorTorque != 0)
        {
            audioSource.pitch = this.GetComponent<Rigidbody>().velocity.x/2;
            audioSource.pitch = this.GetComponent<Rigidbody>().velocity.z/2;
			
        }
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;
        currentbreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();
    }
	
	

    private void ApplyBreaking()
    {
        frontRightWheelCollider.brakeTorque = currentbreakForce;
        frontLeftWheelCollider.brakeTorque = currentbreakForce;
        rearLeftWheelCollider.brakeTorque = currentbreakForce;
        rearRightWheelCollider.brakeTorque = currentbreakForce;
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheeTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    } 
	
	
	

    private void UpdateSingleWheel(
        WheelCollider wheelCollider,
        Transform wheelTransform
    )
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
	
	
}
