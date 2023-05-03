using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject MB;
    public GameObject PU;
    public GameObject CPU;
    public GameObject GPU;
    public GameObject CPUCOOL;
    public GameObject RAM;
    public GameObject Cable;
    public GameObject HDD;

    public List<string> lista;
    private int numofErrors = -8;
    void Start()
    {

        lista.Add("jarst_motherboard_2");
        lista.Add("jarst_power_supply_2");
        lista.Add("jarst_graphics_card_1");
        lista.Add("jarst_cooling_unit");

        lista.Add("jarst_RAM_51");
        lista.Add("jarst_processor_11");
        lista.Add("jarst_cable");
        lista.Add("jarst_hard_disk_2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (lista.Contains(other.gameObject.name)) {
            numofErrors++;
            Debug.Log(other.gameObject.name);
        }
    }

    public int getNumOfErrors() {
        return numofErrors;
    }
}
