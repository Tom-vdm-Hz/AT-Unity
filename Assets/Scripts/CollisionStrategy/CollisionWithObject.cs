using System.Collections.Generic;
using UnityEngine;

public class CollisionWithObject : ScriptableObject, CollisionStrategy
{

    public void Collides(Collider[] hits, MonoBehaviour parent, List<Rigidbody> objects)
    {
        if (objects != null)
        {
            foreach (var body in objects)
            {
                if ((body != null && !body.isKinematic) && body.GetComponent<PhysicsObject>() != null)
                {
                    body.velocity = new Vector3(5, 0, 5);
                }
                // this.GetComponent<CarController>().motorForce;
            }
        }
    }
}