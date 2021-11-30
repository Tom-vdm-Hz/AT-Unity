using System;
using System.Runtime.InteropServices;
using UnityEngine;
public interface CollisionStrategy {
    void Collides(Collider[] hits, MonoBehaviour parent);
}