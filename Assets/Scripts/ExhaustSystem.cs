using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExhaustSystem : MonoBehaviour
{
    [SerializeField] ParticleSystem ps = null;
    ParticleSystem.MainModule main = new ParticleSystem.MainModule();

    [Header("Particle Propeties")]
    [SerializeField] private float sizeAcceleration = 150f;
    [SerializeField] private float lifeAcceleration = 150f;
    [SerializeField] private float sizeVelocity = 15f;
    [SerializeField] private float lifeVelocity = 15f;

    [Header("Vehicle Properties")]
    [SerializeField] private float maxSpeed = -1f;
    [SerializeField] private float maxAcceleration = -1f;

    private float finalVelocity = -1f;
    private float initialVelocity = -1f;

    private Vector3 pos = new Vector3();
    private Vector3 posLast = new Vector3();

    void Start()
    {
        main = ps.main;
    }

    void Update()
    {
        posLast = pos;
        pos = transform.position;

        initialVelocity = finalVelocity;
        finalVelocity = (posLast - pos).magnitude / Time.deltaTime;

        float velocityPercent = finalVelocity / maxSpeed;
        float acceleration = (finalVelocity - initialVelocity) / Time.deltaTime;
        float absAccPrct = Mathf.Abs(acceleration / maxAcceleration);

        Debug.Log($"Velocity : {finalVelocity} \n  Veclocity percent : {velocityPercent} \n Acceleration : {acceleration}");

        ShowVehicleEffort(velocityPercent, absAccPrct);
    }

    private void ShowVehicleEffort(float vMod, float aMod)
    {
        if (aMod > .2f)
        {
            main.startSize = sizeAcceleration * aMod;
            main.startLifetime = lifeAcceleration * aMod;
        }
        else
        {
            main.startSize = lifeAcceleration * vMod;
            main.startLifetime = lifeVelocity * vMod;
        }
    }


}
