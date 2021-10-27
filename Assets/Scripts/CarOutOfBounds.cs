using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarOutOfBounds : MonoBehaviour
{
    private GameObject plane;
    private float x;
    private float z;
    void Start(){
        plane = GameObject.Find("Plane");
        x = (plane.transform.position.x + plane.transform.localScale.x);
        z = plane.transform.position.z + plane.transform.localScale.z;
    }

    void Update(){
        Debug.Log($"{plane.transform.position.x} {plane.transform.localScale.x}");
    }
}
