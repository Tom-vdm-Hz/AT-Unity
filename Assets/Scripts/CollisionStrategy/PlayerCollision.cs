using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public enum CollisionType
    {
        Water,
        Object,
        Link,
        Land,
    }

    private bool initialized = false;

    private Dictionary<CollisionType, CollisionStrategy> strategies;
    private List<Rigidbody> objects;

    private bool physicsTriggered;

    [SerializeField]
    public WheelCollider frontLeftWheelCollider;

    [SerializeField]
    public WheelCollider frontRightWheelCollider;

    [SerializeField]
    public WheelCollider rearLeftWheelCollider;

    [SerializeField]
    public WheelCollider rearRightWheelCollider;

    void Awake()
    {
        strategies = new Dictionary<CollisionType, CollisionStrategy>();
        strategies.Add(CollisionType.Link, ScriptableObject.CreateInstance<CollisionWithLink>());
        strategies.Add(CollisionType.Water, ScriptableObject.CreateInstance<CollisionWithSea>());
        strategies.Add(CollisionType.Object, ScriptableObject.CreateInstance<CollisionWithObject>());
        strategies.Add(CollisionType.Land, ScriptableObject.CreateInstance<CollisionWithLand>());
        initialized = true;
    }

    void Update()
    {
        if (initialized)
        {
            foreach (KeyValuePair<CollisionType, CollisionStrategy> strategy in strategies)
            {
                Collides(strategy.Key);
            }
        }
    }

    void FixedUpdate()
    {
        if (initialized)
        {
            foreach (KeyValuePair<CollisionType, CollisionStrategy> strategy in strategies)
            {
                Collides(strategy.Key);
            }
        }
    }

    private GameObject[] GetGameObjects()
    {
        return GameObject.FindGameObjectsWithTag("Untagged");
    }

    private Collider[] GetWheelHits()
    {

        Collider frontLeftHit = GetWheelHit(frontLeftWheelCollider);
        Collider frontRightHit = GetWheelHit(frontRightWheelCollider);
        Collider rearLeftHit = GetWheelHit(rearLeftWheelCollider);
        Collider rearRightHit = GetWheelHit(rearRightWheelCollider);
        Collider[] hits = { frontLeftHit, frontRightHit, rearLeftHit, rearRightHit };
        return hits;
    }

    private Collider GetWheelHit(WheelCollider wheelCollider)
    {
        WheelHit hit;
        wheelCollider.GetGroundHit(out hit);
        return hit.collider;
    }

    public void Collides(CollisionType action)
    {
        CollisionStrategy strategy;

        if (!strategies.TryGetValue(action, out strategy))
        {
            return;
        }

        Collider[] hits = GetWheelHits();

        // if (hits == null)
        // {
        //     GameObject[] gameObjects = GetGameObjects();
        //     List<Collider> colliders = new List<Collider>();
        //     foreach (GameObject gameObject in gameObjects)
        //     {
        //         colliders.Add(gameObject.GetComponent<Collider>());
        //     }
        //     hits = colliders.ToArray();
        //     Debug.Log(hits);
        // }
        // Debug.Log(hits);
        strategy.Collides(hits, this, objects);
    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        Debug.Log($"{collisionInfo.collider.name}");
        if (objects == null) objects = new List<Rigidbody>();
        objects.Add(collisionInfo.collider.attachedRigidbody);
        physicsTriggered = true;
    }

    private void OnCollisionStay(Collision collisionInfo)
    {
        // Debug.Log($"Collision stay");
    }

    private void OnCollisionExit(Collision collisionInfo)
    {
        Debug.Log($"{collisionInfo.collider.gameObject.name}");
        if (objects.Contains(collisionInfo.collider.attachedRigidbody))
        {
            objects.Remove(collisionInfo.collider.attachedRigidbody);
        }
        physicsTriggered = false;
    }
}