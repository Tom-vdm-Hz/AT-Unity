using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollidesWithCar : MonoBehaviour
{
    private bool triggered = false;

    private bool physicsTriggered = false;

    private List<Rigidbody> objects;

    private string url;

    private string scene;

    [SerializeField]
    private WheelCollider frontLeftWheelCollider;

    [SerializeField]
    private WheelCollider frontRightWheelCollider;

    [SerializeField]
    private WheelCollider rearLeftWheelCollider;

    [SerializeField]
    private WheelCollider rearRightWheelCollider;

    private Collider frontLeftHit;
    private Collider frontRightHit;
    private Collider rearLeftHit;
    private Collider rearRightHit;

    void Update()
    {
        if (url != null && Input.GetKeyDown(KeyCode.Return) && triggered)
        {
            Application.OpenURL(url);
        }

        if (!String.IsNullOrEmpty(scene) && Input.GetKeyDown(KeyCode.Return) && triggered)
        {
            SceneManager.LoadScene(scene);
        }
    }

    void FixedUpdate()
    {
        Collider[] hits = GetWheelHits();
        CollidesWithLink(hits);
        CollidesWithPhysicsObject();
    }

    private void CollidesWithLink(Collider[] hits)
    {
        for (int i = 0; i < hits.Length; i++)
        {
            Collider hit = hits[i];
            if (hit != null)
            {
                if (hit.GetComponent<LinkInfo>() != null)
                {
                    triggered = true;
                    url = hit.GetComponent<LinkInfo>().url;
                    scene = hit.GetComponent<LinkInfo>().scene;
                }
                else
                {
                    triggered = false;
                }
            }
        }
    }

    private void CollidesWithPhysicsObject()
    {
        if (physicsTriggered)
        {
            foreach (var body in objects)
            {
                if ((body != null || !body.isKinematic) && body.GetComponent<PhysicsObject>() != null)
                {
                    body.velocity = new Vector3(100, 0, 100);
                }
                return;
                // this.GetComponent<CarController>().motorForce;
            }
        }
    }

    private Collider[] GetWheelHits()
    {
        frontLeftHit = GetWheelHit(frontLeftWheelCollider);
        frontRightHit = GetWheelHit(frontRightWheelCollider);
        rearLeftHit = GetWheelHit(rearLeftWheelCollider);
        rearRightHit = GetWheelHit(rearRightWheelCollider);
        Collider[] hits = { frontLeftHit, frontRightHit, rearLeftHit, rearRightHit };
        return hits;
    }

    private Collider GetWheelHit(WheelCollider wheelCollider)
    {
        WheelHit hit;
        wheelCollider.GetGroundHit(out hit);
        return hit.collider;
    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        Debug.Log($"Collision enter {collisionInfo.gameObject.name}");
        objects.Add(collisionInfo.collider.attachedRigidbody);
        physicsTriggered = true;
    }

    private void OnCollisionStay(Collision collisionInfo)
    {
        Debug.Log($"Collision");
    }

    private void OnCollisionExit(Collision collisionInfo)
    {
        Debug.Log("Collision Exit");
        objects.Remove(collisionInfo.collider.attachedRigidbody);
        physicsTriggered = false;
    }

}
