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
            //currentModel.GetComponent<CollidesWithCar>().enabled = true;
            currentModel.GetComponent<PlayerCollision>().enabled = true;
        }
    }

    private void makeModel(GameObject model){
            GameObject transformation = Instantiate(model, currentModel.transform.position, currentModel.transform.rotation);
            transformation.transform.parent = transform;
            CameraFollow follow = Camera.main.GetComponent<CameraFollow>();
            follow.target = transformation.transform;
            Destroy(currentModel);
            currentModel = transformation;
            currentModel.GetComponent<CarController>().enabled = true;
            currentModel.GetComponent<CollidesWithCar>().enabled = true;
    }

    public void ChangeModel()
    {   
        Debug.Log(currentModel == carModel);
        if (currentModel.name.Contains("Car"))
        {
            makeModel(boatModel);
        }
        else
        {
            makeModel(carModel);
        }
    }
}