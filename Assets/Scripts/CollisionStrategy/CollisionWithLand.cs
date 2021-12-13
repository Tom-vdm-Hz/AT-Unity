using System;
using System.Collections.Generic;
using UnityEngine;
public class CollisionWithLand : ScriptableObject, CollisionStrategy
{

    public void Collides(Collider[] hits, MonoBehaviour parent, List<Rigidbody> objects)
    {
        Debug.Log(objects);
    }
}