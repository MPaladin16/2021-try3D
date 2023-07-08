using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    // Start is called before the first frame update
    private BoxCollider TrashReset;
    private int numofErrors = -8;
    private int flag;
    void Start()
    {
        TrashReset = GetComponent<BoxCollider>();
        releaseFlag();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getNumOfErrors()
    {
        return numofErrors;
    }

    public void numOfErrorPlus()
    {
        if (flag == 0)
        {
            Debug.Log("Error+1");
            numofErrors++;
            flag = 1;
            Invoke("releaseFlag", 1f);
        }
    }

    public void releaseFlag()
    {
        flag= 0;
    }



    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Rigidbody>().useGravity = false;
        other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        //other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        //other.gameObject.GetComponent<Rigidbody>().freezeRotation = true;
        //other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;

        if (other.gameObject.name.Contains("RAM_52")) {
            other.gameObject.transform.position = new Vector3(2.42799997f, 1.13600004f, 0.639999986f);
            other.gameObject.transform.rotation = new Quaternion(0f, 0.953716993f, 0f, 0.30070582f);
        }
        if (other.gameObject.name.Contains("RAM_51"))
        {
            other.gameObject.transform.position = new Vector3(2.42799997f, 1.32000005f, 0.639999986f);
            other.gameObject.transform.rotation = new Quaternion(0, 0.953716993f, 0, 0.30070582f);
        }
        if (other.gameObject.name.Contains("cooler (1)"))
        {
            other.gameObject.transform.position = new Vector3(2.71000004f, 0.873000026f, 0.202000007f);
            other.gameObject.transform.rotation = new Quaternion(0.627211392f, 0.326505572f, -0.326505572f, 0.627211392f);
        }
        if (other.gameObject.name.Contains("cooler (2)"))
        {
            other.gameObject.transform.position = new Vector3(2.71000004f, 1.26800001f, 0.202000007f);
            other.gameObject.transform.rotation = new Quaternion(0.627211392f, 0.326505572f, -0.326505572f, 0.627211392f);
        }
        if (other.gameObject.name.Contains("cooler (3)"))
        {
            other.gameObject.transform.position = new Vector3(2.71000004f, 1.63800001f, 0.202000007f);
            other.gameObject.transform.rotation = new Quaternion(0.627211392f, 0.326505572f, -0.326505572f, 0.627211392f);
        }
       if (other.gameObject.name.Contains("graphics_card_1"))
       {
            //other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            //other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            //other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            //other.gameObject.GetComponent<Rigidbody>().freezeRotation = true;
            //other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            other.gameObject.transform.position = new Vector3(1.329f, 1.56300008f, 2.18000007f);
            other.gameObject.transform.rotation = new Quaternion(0, 0.887010872f, 0, -0.46174863f);
        }
        if (other.gameObject.name.Contains("cooling_unit"))
        {
            other.gameObject.transform.position = new Vector3(1.28999996f, 0.959999979f, 2.20000005f);
            other.gameObject.transform.rotation = new Quaternion(0, 0.46174863f, 0, 0.887010872f);
        }
        if (other.gameObject.name.Contains("hard_disk_2"))
        {
            other.gameObject.transform.position = new Vector3(1.67799997f, 1.40999997f, 1.69400001f);
            other.gameObject.transform.rotation = new Quaternion(-0.627211392f, 0.326505572f, 0.326505572f, 0.627211392f);
        }
        if (other.gameObject.name.Contains("motherboard_2"))
        {
            other.gameObject.transform.position = new Vector3(1.91999996f, 1.88999987f, 1.35099995f);
            other.gameObject.transform.rotation = new Quaternion(-0.627211392f, 0.326505572f, 0.326505572f, 0.627211392f);
        }
        if (other.gameObject.name.Contains("power_supply_2"))
        {
            other.gameObject.transform.position = new Vector3(1.627f, 0.977f, 1.476f);
            other.gameObject.transform.rotation = new Quaternion(0.627211392f, 0.326505572f, -0.326505572f, 0.627211392f);
        }
        if (other.gameObject.name.Contains("power_supply_cable"))
        {
            other.gameObject.transform.position = new Vector3(1.57700002f, 0.850000024f, 1.64600003f);
            other.gameObject.transform.rotation = new Quaternion(0, 0.887010872f, 0, -0.46174863f);
        }
        if (other.gameObject.name.Contains("Cube_47")) {
            other.gameObject.transform.position = new Vector3(2.28699994f, 0.179000005f, 0.791999996f);
            other.gameObject.transform.rotation = new Quaternion(-0.212631077f, 0.212631077f, 0.674379766f, -0.674379766f);
        }
        if (other.gameObject.name.Contains("Cylinder_2"))
        {
            other.gameObject.transform.position = new Vector3(2.28699994f, 0.179000005f, 0.791999996f);
            other.gameObject.transform.rotation = new Quaternion(-0.212631077f, 0.212631077f, 0.674379766f, -0.674379766f);
        }
        if (other.gameObject.name.Contains("jarst_cable"))
        {
            other.gameObject.transform.position = new Vector3(2.25f, 0.843999982f, 0.853999972f);
            other.gameObject.transform.rotation = new Quaternion(0.674379766f, 0.674379766f, 0.212631121f, 0.212631121f);
        }
        if (other.gameObject.name.Contains("processor_11"))
        {
            other.gameObject.transform.position = new Vector3(2.45700002f, 1.61300004f, 0.617999971f);
            other.gameObject.transform.rotation = new Quaternion(0.326505572f, -0.627211392f, 0.627211392f, 0.326505572f);
        }

        //other.gameObject.GetComponent<Rigidbody>().useGravity = false;

        if (Random.Range(0f, 1f) > 0.5f)
        {
            this.gameObject.transform.position = new Vector3(Random.Range(1f, 2.5f), 0f, Random.Range(0f, -1.5f));
        }
        else {
            this.gameObject.transform.position = new Vector3(Random.Range(-1f, -2.5f), 0f, Random.Range(0f, -1.5f));
        }

    }
}
