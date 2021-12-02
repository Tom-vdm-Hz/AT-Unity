using System;
using UnityEngine;
public class CollisionWithSea : ScriptableObject, CollisionStrategy
{

    public void Collides(Collider[] hits, MonoBehaviour parent)
    {
        if (hits == null)
        {
            return;
        }

        foreach (Collider hit in hits)
        {
            if (hit != null)
            {
                String name = hit.gameObject.name;
                if (name == "Sea")
                {
                    try
                    {
                        if(parent != null) parent.gameObject.GetComponentInParent<Test>().ChangeModel();
                    }catch(NullReferenceException err){
                        Debug.Log($"{err}");
                    }
                }
                else
                {
                    //    parent.gameObject.GetComponentInParent<Test>().ChangeModel();
                }
            }
        }
    }
}