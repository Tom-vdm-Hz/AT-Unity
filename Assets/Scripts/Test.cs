using UnityEngine;
public class Test : MonoBehaviour
{
    [SerializeField]
    private GameObject carModel;

    [SerializeField]
    private GameObject boatModel;

    private GameObject currentModel;

    void Start()
    {
        if (currentModel == null)
        {
            currentModel = Instantiate(carModel, new Vector3(4, 5, 4), transform.rotation);
            currentModel.transform.parent = transform;
            CameraFollow follow = Camera.main.GetComponent<CameraFollow>();
            follow.target = currentModel.transform;

            currentModel.GetComponent<CarController>().enabled = true;
            currentModel.GetComponent<PlayerCollision>().enabled = true;
        }
    }

    private void makeModel(GameObject model, string m)
    {
        GameObject transformation = Instantiate(model, currentModel.transform.position, currentModel.transform.rotation);
        transformation.transform.parent = transform;
        CameraFollow follow = Camera.main.GetComponent<CameraFollow>();
        follow.target = transformation.transform;
        Destroy(currentModel);
        currentModel = transformation;
        if(currentModel.GetComponent<CarController>() != null) currentModel.GetComponent<CarController>().enabled = true;
        if(currentModel.GetComponent<PlayerCollision>() != null) currentModel.GetComponent<PlayerCollision>().enabled = true;
        if(currentModel.GetComponent<BoatController>() != null) currentModel.GetComponent<BoatController>().enabled = true;
    }

    public void ChangeModel(string model)
    {   
        if(model == "car") makeModel(carModel,"car");
        if(model == "boat") makeModel(boatModel,"boat");
    }
}