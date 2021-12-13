using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionWithLink : ScriptableObject, CollisionStrategy
{
    private bool intervalPassed = true;

    private IEnumerator WaitAction(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        intervalPassed = true;
    }

    public void Collides(Collider[] hits, MonoBehaviour parent, List<Rigidbody> objects)
    {
        if (hits == null)
        {
            return;
        }

        foreach (Collider hit in hits)
        {
            if (hit != null)
            {
                if (hit.GetComponent<LinkInfo>() != null)
                {
                    LinkInfo info = hit.GetComponent<LinkInfo>();
                    string url = info.url;
                    string sceneName = info.scene;

                    if (url != null && Input.GetKeyDown(KeyCode.Return) && intervalPassed)
                    {
                        Application.OpenURL(url);
                        intervalPassed = false;
                        parent.StartCoroutine(WaitAction(1.0f));
                    }

                    if (!String.IsNullOrEmpty(sceneName) && Input.GetKeyDown(KeyCode.Return))
                    {
                        SceneManager.LoadScene(sceneName);
                    }
                }
            }
        }
    }
}