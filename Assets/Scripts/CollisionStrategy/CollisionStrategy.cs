using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface CollisionStrategy {
    #nullable enable
    void Collides(Collider[] hits, MonoBehaviour parent, List<Rigidbody>? objects);
    #nullable disable
}