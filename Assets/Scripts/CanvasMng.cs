using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasMng : MonoBehaviour
{
    // Start is called before the first frame update
    private Button startBtn;
    private Button exitBtn;
    private Button settingBtn;
    private Button backBtn;
    private Button gearBtn;
    private Button helpBtn;
    private Button doneBtn;
    private Button restartBtn;
    private float startTime;
    private float Timer = 0.0f;
    private float LastTimeSet = 0.0f;
    private bool startTimer = false;
    private int f = 0;
    public List<float> componentTimes;

    public int numOfFans;


    public Canvas mainCanvas;
    public Canvas setCanvas;
    public Canvas ingameCanvas;
    public Canvas endGameCanvas;
    public Canvas timerCanvas;
    public GameObject donePC;
    public InteractableObjects iO;

    public bool turnedOn = false;
    void Start()
    {

        mainCanvas.gameObject.SetActive(true);
        setCanvas.gameObject.SetActive(false);
        ingameCanvas.gameObject.SetActive(false);
        endGameCanvas.gameObject.SetActive(false);


        startBtn = mainCanvas.gameObject.transform.GetChild(0).gameObject.GetComponent<Button>();
        exitBtn = mainCanvas.gameObject.transform.GetChild(2).gameObject.GetComponent<Button>();
        settingBtn = mainCanvas.gameObject.transform.GetChild(1).gameObject.GetComponent<Button>();
        doneBtn = ingameCanvas.gameObject.transform.GetChild(13).gameObject.GetComponent<Button>();

        helpBtn = timerCanvas.gameObject.transform.GetChild(2).gameObject.GetComponent<Button>();

        backBtn = setCanvas.gameObject.transform.GetChild(1).gameObject.GetComponent<Button>();
        restartBtn = setCanvas.gameObject.transform.GetChild(3).gameObject.GetComponent<Button>();  

        gearBtn = ingameCanvas.gameObject.transform.GetChild(0).gameObject.GetComponent<Button>();

        endGameCanvas.gameObject.transform.GetChild(3).gameObject.GetComponent<Button>().onClick.AddListener(goToClassroom);// go to new scene where the test is in the classroom

        startTime = Time.time;


        helpBtn.onClick.AddListener(helpClicked);
        startBtn.onClick.AddListener(startClicked);
        exitBtn.onClick.AddListener(exitClicked);
        settingBtn.onClick.AddListener(settingClicked);
        backBtn.onClick.AddListener(backClicked);
        gearBtn.onClick.AddListener(gearClicked);
        doneBtn.onClick.AddListener(doneClicked);
        restartBtn.onClick.AddListener(restartGame);
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer == true) { 
        Timer += Time.deltaTime; 
        timerCanvas.gameObject.transform.GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text =
                "Time: " + Timer.ToString("n2");
        }
        GuideChange();
    
    }
    public List<float> GetTimes() {
        return componentTimes;
    }


    void restartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void startClicked() {

            startBtn.gameObject.transform.GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "CONTINUE";
            mainCanvas.gameObject.SetActive(false);
            ingameCanvas.gameObject.SetActive(true);
            startTimer = true;
            
    }
    void exitClicked() {
        Application.Quit();
    }

    void goToClassroom() {
        SceneManager.LoadScene("Classroom");
    }

    void doneClicked() {

        if (InteractableObjects.cablesDone == false)
        {
            ingameCanvas.gameObject.transform.GetChild(14).gameObject.SetActive(true);
            float timeOut = 0;
            timeOut += Time.deltaTime;
            if (timeOut > 3)
            {
                ingameCanvas.gameObject.transform.GetChild(14).gameObject.SetActive(false);
            }
        }
        else {
            startTimer = false;
            gameOver();
            
        }

    }
    void settingClicked() {
        mainCanvas.gameObject.SetActive(false);
        setCanvas.gameObject.SetActive(true);
    }

    void backClicked() {
        mainCanvas.gameObject.SetActive(true);
        setCanvas.gameObject.SetActive(false);
    }

    void gearClicked() {
        mainCanvas.gameObject.SetActive(true);
        ingameCanvas.gameObject.SetActive(false);
    }

  
    void gameOver() {

        int br = 0;
        mainCanvas.gameObject.SetActive(false);
        ingameCanvas.gameObject.SetActive(false);
        endGameCanvas.gameObject.SetActive(true);
        timerCanvas.gameObject.SetActive(false);
        endGameCanvas.gameObject.transform.GetChild(1).gameObject.GetComponent< TMPro.TextMeshProUGUI > ().text = "Time: " + Timer.ToString("n2");
        endGameCanvas.gameObject.transform.GetChild(2).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "Pc specifications: \n" +
            "CPU: i7-8400H \n" +
            "GPU: Asus Rog GTX 770\n" +
            "SPACE: 1TB HDD\n" +
            "RAM: " + InteractableObjects.ramsConnected * 8 + "Gb \n" +
            "POWER: 620W\n" +
            "FANS: " + InteractableObjects.numOfFans;


        
        int sakri = GameObject.Find("Objects").gameObject.transform.childCount;
        GameObject objects = GameObject.Find("Objects").gameObject;
        for (int i = 0; i < sakri; i++)
        {
            objects.transform.GetChild(i).gameObject.SetActive(false);
        }
        donePC.gameObject.SetActive(true);
    }

    void helpClicked() {

        if (timerCanvas.gameObject.transform.GetChild(3).gameObject.activeInHierarchy == false)
        {
            timerCanvas.gameObject.transform.GetChild(3).gameObject.SetActive(true);
            turnedOn = true;
        }
        else {
            timerCanvas.gameObject.transform.GetChild(3).gameObject.SetActive(false);
            turnedOn = false;
        }
        if (InteractableObjects.motherBoardDone == false) {
            timerCanvas.gameObject.transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text =
                "A motherboard is the biggest PC component, it is used to connect all other components with each other. \n" +
                "Ports for all external hardware components should be facing towards you.";
        }
        else if(InteractableObjects.powerDone == false) {
            timerCanvas.gameObject.transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "" +
                "The power unit is used to bring power from the wall outlet to the motherboard and other components \n" +
                "It consists of a fan and two different outputs, one for the outside cable leading to the source of power \n" +
                "and another inside the case that is used to power all the components";
        }
        else if(InteractableObjects.CPUDone == false) {
            timerCanvas.gameObject.transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "" +
                "A processor is the smallest part of all the pc components we are using to build a pc. \n" +
                "It is also the main and most crucial chip in a computer, it is responsible for interpreting \n" +
                "most of computers commands";
        }
        else if (InteractableObjects.CPUFanDone == false)
        {
            timerCanvas.gameObject.transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "" +
                "A cooler is usually a big fan that sometimes also consists of a metal conduit on top of it, \n" +
                "metal conduit is used to disperse the air and helps with keeping the processor from overheating";
        }
        else if (InteractableObjects.GPUDone == false)
        {
            timerCanvas.gameObject.transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "" +
                "Graphics processing unit is usually a part of the motherboard, however, when in need of extra power \n" +
                "regarding graphics rendering we use dedicated graphics cards, they can process many pieces of data simultaneously \n" +
                "making them useful with video editing, gaming, machine learning and crypto mining \n" +
                "It looks like a big cuboid with a fan on it";
        }
        else if (InteractableObjects.ramDone == false)
        {
            timerCanvas.gameObject.transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "" +
                "The RAM or Random access memory is a used to handle and solve all active tasks on your computer, \n" +
                "more RAM means more power when handling tasks on your computer \n" +
                "personal computers these days usually use from 8Gb to 32Gb of RAM \n" +
                "RAM should be placed just behind the processors cooler";
        }
        else if (InteractableObjects.diskDone == false)
        {
            timerCanvas.gameObject.transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "" +
                "The HDD or Hard disk drive looks like a small metal box and is used to store data \n" +
                "besides HDD, we also got SSD or solid state disk that is faster, more used and more famous these days \n" +
                "Computers are unable to work without a disk as disks are used to boot OS, \n" +
                "but are also there to store and retrieve digital data";
        }
        else if (InteractableObjects.cablesDone == false)
        {
            timerCanvas.gameObject.transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "" +
                "The cables are used to bring the power from the power unit to the motherboard, \n" +
                "big Graphics cards like the one we have also need extra power from the power unit. \n" +
                "All other parts also get their power from the motherboard or from the power unit directly";
        }

    }

    //ComponentTimes are always arranged by index, 0 - MB, PU, CPU, CPUFan, GPU, RAM, Disk, Cables, Fans(IF)
    void GuideChange() {

        if (InteractableObjects.motherBoardDone == false)
        {
            f = 0;
            timerCanvas.gameObject.transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text =
                "Find the Motherboard and place it inside the computer case, facing the right direction \n" +
                "it is super important to place the screws into the edges of the motherboard \n" +
                "and connect it to the case (We are not going to screw those components together in this tutorial)";
        }
        else if (InteractableObjects.powerDone == false)
        {
            if (f == 0)
            {
                componentTimes.Add(Timer);
                f = 1;
            }
            timerCanvas.gameObject.transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "" +
                "Find the Power unit and place it into the correct place inside the computer case \n" +
                "The power unit, in this case, should be placed at the bottom of the pc with its fan facing out of the box";
        }
        else if (InteractableObjects.CPUDone == false)
        {
            if (f == 1)    
            { 
                componentTimes.Add(Timer);
                f = 2;
            }
        timerCanvas.gameObject.transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "" +
                "Find the processor and place it into the right place on the motherboard \n" +
                "after placing the processor, we use a small amount of thermal paste \n" +
                "before putting the fan/cooler on it (We are not going to do this part in the tutorial, but it is mandatory)";
        }
        else if (InteractableObjects.CPUFanDone == false) {
            if (f == 2)
            {
                componentTimes.Add(Timer);
                f = 3;
            }
            timerCanvas.gameObject.transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "" +
                "Find the processor cooler and place it on top of the processor we placed in the last step, \n" +
                "it is important to attach the cooler to the motherboard, so it always stays on top of the processor";
        }
        else if (InteractableObjects.GPUDone == false)
        {
            if (f == 3)
            {
                componentTimes.Add(Timer);
                f = 4;
            }
            timerCanvas.gameObject.transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "" +
                "Find the Graphics Card and place it into the right spot on the motherboard, \n" +
                "Graphics Card ports should be seen on the back of the computer, just under the motherboard ports";
        }
        else if (InteractableObjects.ramDone == false)
        {
            if (f == 4)
            {
                componentTimes.Add(Timer);
                f = 5;
            }
            timerCanvas.gameObject.transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "" +
                "Find the random access memory card and place it into the pc, \n" +
                "there are 2 different cards that you can use, you can use both of them or one \n";
        }
        else if (InteractableObjects.diskDone == false)
        {
            if (f == 5)
            {
                componentTimes.Add(Timer);
                f = 6;
            }
            timerCanvas.gameObject.transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "" +
                "Find the hard disk drive and place it into its place inside the computer case \n" +
                "there is a special area for the HDD, be carful to make its ports accessibile \n" +
                "when placing the HDD into its designated area";
        }
        else if (InteractableObjects.cablesDone == false)
        {
            if (f == 6)
            {
                componentTimes.Add(Timer);
                f = 7;
            }
            timerCanvas.gameObject.transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "" +
                "After all the components are inside the computer case, we have to connect them with cables \n" +
                "so they can function and exchange information correctly, take the big yellow cable  \n" +
                "and find the place on the motherboard where the cable coming from the power unit should be connected";
        }
        else if (InteractableObjects.numOfFans==0) {
            if (f == 7)
            {
                componentTimes.Add(Timer);
                f = 8;
            }
            timerCanvas.gameObject.transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "" +
                "You were successful in building your PC \n" +
                "To keep your PC from overheating, you can now add 1 to 3 fans and attach them \n" +
                "to the inside roof of the PC case, this is not mandatory but is recommended";
        }
        else{
            timerCanvas.gameObject.transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "" +
                "\n \n Try turning your PC on!";
        }
    }


}
