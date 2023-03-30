using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableObjects : MonoBehaviour
{
    public GameObject PC;
    public GameObject MotherBoard;
    public static bool motherBoardDone;
    public static bool powerDone;
    public static bool CPUDone;
    public static bool CPUFanDone;
    public static bool GPUDone;
    public static bool cablesDone;
    public static bool diskDone;
    public static int ramsConnected;
    public static int numOfFans;
    public static bool ramDone;
    public Canvas iGCanvas;

    public GameObject MB;
    public GameObject PU;
    public GameObject CPU;
    public GameObject GPU;
    public GameObject CPUCOOL;
    static bool onlyOnceRAM, onlyOnceRAM2, onlyOnceFAN1, onlyOnceFAN2, onlyOnceFAN3;
    // Start is called before the first frame update
    void Start()
    {
         motherBoardDone = false;
         powerDone = false;
         CPUDone = false;   
         GPUDone = false;
         cablesDone = false;
         diskDone = false;
         ramDone = false;
        CPUFanDone = false;
        ramsConnected = 0;
        numOfFans = 0;
        onlyOnceRAM = false;
        onlyOnceRAM2 = false;
        onlyOnceFAN1 = false;
        onlyOnceFAN2 = false;
        onlyOnceFAN3 = false;
        //iGCanvas = GameObject.Find("ingameCanvas").GetComponent<Canvas>();
        MotherBoard = GameObject.Find("jarst_motherboard_2");
        // this.gameObject.GetComponent<Rigidbody>().useGravity = false;
       // MB = GameObject.Find("jarst_motherboard_2 (1)");
        PU = GameObject.Find("jarst_power_supply_2 (1)");
        CPU = GameObject.Find("jarst_processor_11 (1)");
        GPU = GameObject.Find("jarst_graphics_card_1 (1)");
        CPUCOOL = GameObject.Find("jarst_cooling_unit (1)");
       // MB.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name.Contains("Controller")) {

            if (this.gameObject.GetComponent<Rigidbody>() != null) { 
            this.gameObject.GetComponent<Rigidbody>().useGravity = true;
            this.gameObject.GetComponent<Rigidbody>().isKinematic = false; }
        }

        if (this.gameObject.transform.name.Contains("placeCollider")) { 
        if (this.gameObject.transform.parent.name.Contains("motherboard") && collider.gameObject.name.Contains("motherboard_col")) {

                //this.gameObject.transform.parent.gameObject.SetActive(false);
                //MB.gameObject.SetActive(true);
                //MB.gameObject.transform.parent = PC.transform;
                //MB.gameObject.transform.position = new Vector3(0.216000006f, 0.59799999f, 0.838f);
                //MB.gameObject.transform.rotation = new Quaternion(0, 0.707106829f, 0, 0.707106829f);
                this.gameObject.transform.parent.parent = PC.transform;
                this.gameObject.transform.parent.position = new Vector3(0.216000006f, 0.59799999f, 0.838f);
                this.gameObject.transform.parent.rotation = new Quaternion(0, 0.707106829f, 0, 0.707106829f);
                this.gameObject.transform.parent.GetComponent<Rigidbody>().isKinematic = true;

                motherBoardDone = true;
                iGCanvas.gameObject.transform.GetChild(7).gameObject.GetComponent<Image>().color = Color.green;
        } }

        if (this.gameObject.transform.name.Contains("placeColliderPOWER"))
        {

            if (this.gameObject.transform.parent.name.Contains("power_supply") && motherBoardDone == true
                && collider.gameObject.name.Contains("power_col") && this.gameObject.transform.parent.localRotation.y < 0.85f
                && this.gameObject.transform.parent.localRotation.y > 0.6f)
            {
                this.gameObject.transform.parent.gameObject.SetActive(false);
                PU.gameObject.SetActive(true);
                PU.gameObject.transform.parent = PC.transform;
                PU.gameObject.transform.position = new Vector3(0.250999987f, 0.737999976f, 0.508000016f);
                PU.gameObject.transform.rotation = new Quaternion(0.707106829f, 0.707106829f, 0, 0);
                //this.gameObject.transform.parent.parent = PC.transform;
                //this.gameObject.transform.parent.position = new Vector3(0.250999987f, 0.737999976f, 0.508000016f);
                //this.gameObject.transform.parent.rotation = new Quaternion(0.707106829f, 0.707106829f, 0, 0);
                //this.gameObject.transform.parent.GetComponent<Rigidbody>().isKinematic = true;
                powerDone = true;
                iGCanvas.gameObject.transform.GetChild(11).gameObject.GetComponent<Image>().color = Color.green;
            }
        }

        if (this.gameObject.transform.name.Contains("placeColliderCPU"))
        {
            if (this.gameObject.transform.parent.name.Contains("processor_11") && powerDone == true
                && collider.gameObject.name.Contains("cpu_col") && CPUDone == false)
            {
                this.gameObject.transform.parent.gameObject.SetActive(false);
                CPU.gameObject.SetActive(true);
                MotherBoard = GameObject.Find("jarst_motherboard_2");
                CPU.gameObject.transform.parent = MotherBoard.transform;
                CPU.gameObject.transform.position = new Vector3(-0.204467237f, 0.6045403516f, 0.612131468f); 
                CPU.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0.707106829f);
                //this.gameObject.transform.parent.parent = MotherBoard.transform;
                //this.gameObject.transform.parent.position = new Vector3(-0.204467237f, 0.6045403516f, 0.612131468f);
                //this.gameObject.transform.parent.rotation = new Quaternion(0, 0, 0, 0.707106829f);
                //this.gameObject.transform.parent.GetComponent<Rigidbody>().isKinematic = true;
                CPUDone = true;
                iGCanvas.gameObject.transform.GetChild(9).gameObject.GetComponent<Image>().color = Color.green;
            }
        }
        if (this.gameObject.transform.name.Contains("placeColliderFanCPU"))
        {
            if (this.gameObject.transform.parent.name.Contains("cooling_unit") && CPUDone == true
                && collider.gameObject.name.Contains("fancpu_col"))
            {
                this.gameObject.transform.parent.gameObject.SetActive(false);
                CPUCOOL.gameObject.SetActive(true);
                CPUCOOL.gameObject.transform.parent = MotherBoard.transform;
                CPUCOOL.gameObject.transform.position = new Vector3(-0.204467237f, 0.6045403516f, 0.612131468f);
                CPUCOOL.gameObject.transform.rotation = new Quaternion(0, 0.707106829f, 0, 0.707106829f);
                //this.gameObject.transform.parent.parent = MotherBoard.transform;
                //this.gameObject.transform.parent.position = new Vector3(-0.204467237f, 0.6045403516f, 0.612131468f);
                //this.gameObject.transform.parent.rotation = new Quaternion(0, 0.707106829f, 0, 0.707106829f);
                //this.gameObject.transform.parent.GetComponent<Rigidbody>().isKinematic = true;
                CPUFanDone = true;
                iGCanvas.gameObject.transform.GetChild(9).gameObject.GetComponent<Image>().color = Color.green;
            }
        }

        if (this.gameObject.transform.name.Contains("placeColliderGPU"))
        {
            if (this.gameObject.transform.parent.name.Contains("graphics_card") && CPUFanDone == true
                && collider.gameObject.name.Contains("graphic_col"))
            {
                this.gameObject.transform.parent.gameObject.SetActive(false);
                GPU.gameObject.SetActive(true);
                GPU.gameObject.transform.parent = MotherBoard.transform;
                GPU.gameObject.transform.position = new Vector3(0.016000006f, 0.59999999f, 0.55f);
                GPU.gameObject.transform.rotation = new Quaternion(0, 0.707106829f, 0, 0.707106829f);
                //this.gameObject.transform.parent.parent = MotherBoard.transform;
                //this.gameObject.transform.parent.position = new Vector3(0.016000006f, 0.59999999f, 0.55f);
                //this.gameObject.transform.parent.rotation = new Quaternion(0, 0.707106829f, 0, 0.707106829f);
                //this.gameObject.transform.parent.GetComponent<Rigidbody>().isKinematic = true;
                GPUDone = true;
                iGCanvas.gameObject.transform.GetChild(8).gameObject.GetComponent<Image>().color = Color.green;
                //this.gameObject.transform.parent.
            }
        }

        if (this.gameObject.transform.name.Contains("placeCollider1RAM"))
        {
            if (this.gameObject.transform.parent.name.Contains("RAM") && GPUDone == true
                && collider.gameObject.name.Contains("RAM1_col"))
            {

                MotherBoard = GameObject.Find("jarst_motherboard_2 (1)");
                //this.gameObject.transform.parent.parent = MotherBoard.transform;
                this.gameObject.transform.parent.position = new Vector3(-0.204467237f, 0.6045403516f, 0.7392131468f);
                this.gameObject.transform.parent.rotation = new Quaternion(0, 0.707106829f, 0, 0.707106829f);
                this.gameObject.transform.parent.GetComponent<Rigidbody>().isKinematic = true;
                ramDone = true;
                if (onlyOnceRAM == false)
                {
                    onlyOnceRAM = true;
                    ramsConnected++;
                }
                iGCanvas.gameObject.transform.GetChild(10).gameObject.GetComponent<Image>().color = Color.green;
                //this.gameObject.transform.parent.
            }
        }

        if (this.gameObject.transform.name.Contains("placeCollider2RAM"))
        {
            if (this.gameObject.transform.parent.name.Contains("RAM") && GPUDone == true
                && collider.gameObject.name.Contains("RAM2_col") //&& this.gameObject.transform.parent.localRotation.y > 0.65f
                //&& this.gameObject.transform.parent.localRotation.y < 0.95f
                )
            {

                MotherBoard = GameObject.Find("jarst_motherboard_2 (1)");
                //this.gameObject.transform.parent.parent = MotherBoard.transform;
                this.gameObject.transform.parent.position = new Vector3(-0.204467237f, 0.6045403516f, 0.797131468f);
                this.gameObject.transform.parent.rotation = new Quaternion(0, 0.707106829f, 0, 0.707106829f); ;
                this.gameObject.transform.parent.GetComponent<Rigidbody>().isKinematic = true;
                ramDone = true;
                if (onlyOnceRAM2 == false)
                {
                    onlyOnceRAM2 = true;
                    ramsConnected++;
                }
                iGCanvas.gameObject.transform.GetChild(10).gameObject.GetComponent<Image>().color = Color.green;
                //this.gameObject.transform.parent.
            }
        }

        //HDD connect
        if (this.gameObject.transform.name.Contains("hddCollider"))
        {
            if (this.gameObject.transform.parent.name.Contains("hard_disk") && ramDone == true
                && collider.gameObject.name.Contains("hdd_col")
                )
            {
                this.gameObject.transform.parent.parent = PC.transform;
                this.gameObject.transform.parent.rotation = new Quaternion(-0.5f, 0.5f, 0.5f, 0.5f);
                this.gameObject.transform.parent.position = new Vector3(0.2330000011f, 0.76000011f, 0.95000002f);
                this.gameObject.transform.parent.GetComponent<Rigidbody>().isKinematic = true;
                    diskDone = true;
                iGCanvas.gameObject.transform.GetChild(12).gameObject.GetComponent<Image>().color = Color.green;
            }
        }


        if (this.gameObject.transform.name.Contains("placeCollider1FAN"))
        {
            if (this.gameObject.transform.parent.name.Contains("jarst_cooler (1)") && diskDone == true
                && collider.gameObject.name.Contains("cooler_col") 
                )
            {
                this.gameObject.transform.parent.parent = PC.transform;
                this.gameObject.transform.parent.position = new Vector3(-0.342999995f, 0.769999981f, 0.953999996f);
                this.gameObject.transform.parent.rotation = new Quaternion(0, 0, 0.707106829f, 0.707106829f);
                this.gameObject.transform.parent.GetComponent<Rigidbody>().isKinematic = true;
                if (onlyOnceFAN1 == false)
                {
                    onlyOnceFAN1 = true;
                    numOfFans++;
                }
            }
        }
        if (this.gameObject.transform.name.Contains("placeCollider2FAN"))
        {
            if (this.gameObject.transform.parent.name.Contains("jarst_cooler (2)") && diskDone == true
                && collider.gameObject.name.Contains("cooler_col")
                )
            {
                this.gameObject.transform.parent.parent = PC.transform;
                this.gameObject.transform.parent.position = new Vector3(-0.342999995f, 0.769999981f, 0.72299999f);
                this.gameObject.transform.parent.rotation = new Quaternion(0, 0, 0.707106829f, 0.707106829f);
                this.gameObject.transform.parent.GetComponent<Rigidbody>().isKinematic = true;
                if (onlyOnceFAN2 == false)
                {
                    onlyOnceFAN2 = true;
                    numOfFans++;
                }
            }
        }
        if (this.gameObject.transform.name.Contains("placeCollider3FAN"))
        {
            if (this.gameObject.transform.parent.name.Contains("jarst_cooler (3)") && diskDone == true
                && collider.gameObject.name.Contains("cooler_col")
                )
            {
                this.gameObject.transform.parent.parent = PC.transform;
                this.gameObject.transform.parent.position = new Vector3(-0.342999995f, 0.769999981f, 0.490999997f);
                this.gameObject.transform.parent.rotation = new Quaternion(0, 0, 0.707106829f, 0.707106829f);
                this.gameObject.transform.parent.GetComponent<Rigidbody>().isKinematic = true;

                if (onlyOnceFAN3 == false)
                {
                    onlyOnceFAN3 = true;
                    numOfFans++;
                }
            }
        }

        if (this.gameObject.transform.name.Contains("mainCableCollider"))
        {
            if (this.gameObject.transform.parent.name.Contains("jarst_cable") && diskDone == true
                && collider.gameObject.name.Contains("mainCable_col")
                )
            {
                this.gameObject.transform.parent.position = new Vector3(-0.174999997f, 0.623000026f, 0.825999975f);
                this.gameObject.transform.parent.rotation = new Quaternion(0.0538421832f, 0.703044355f, 0.0369597152f, 0.708140969f);
                this.gameObject.transform.parent.GetComponent<Rigidbody>().isKinematic = true;
                cablesDone=true;
            }
        }




    }
}