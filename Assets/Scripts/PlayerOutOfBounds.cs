using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerOutOfBounds : MonoBehaviour
{
    private GameObject plane;
    void Start(){
        plane = GameObject.Find("Plane");
    }

    void Update(){
        // Renderer.bounds()
        float planeX = (plane.transform.position.x + plane.transform.localScale.x);
        float planeZ = plane.transform.position.z + plane.transform.localScale.z;

        float carX = this.gameObject.transform.position.x;
        float carZ = this.gameObject.transform.position.y;

        // if(this.gameObject.){
        //     SceneManager.LoadScene("Game");
        // }
        // Debug.Log($"{carX} {carZ}");
    }
}
