using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaycastHandler : MonoBehaviour
{
    private Ray ray;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                ExecuteLinkInfo(hit);
                // Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
            }
        }
    }

    private void ExecuteLinkInfo(RaycastHit hit)
    {
        if (hit.collider.GetComponent<LinkInfo>() != null)
        {
            var url = hit.collider.GetComponent<LinkInfo>().url;
            var scene = hit.collider.GetComponent<LinkInfo>().scene;
            // Debug.Log($"{url} {scene}");
            if (url != null)
            {
                Application.OpenURL(url);
            }

            if (!String.IsNullOrEmpty(scene))
            {
                SceneManager.LoadScene(scene);
            }
        }
    }
}
