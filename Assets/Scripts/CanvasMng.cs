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

        

        startTime = Time.time;


        helpBtn.onClick.AddListener(helpClicked);
        startBtn.onClick.AddListener(startClicked);
        exitBtn.onClick.AddListener(exitClicked);
        settingBtn.onClick.AddListener(settingClicked);
        backBtn.onClick.AddListener(backClicked);
        gearBtn.onClick.AddListener(gearClicked);
        doneBtn.onClick.AddListener(doneClicked);
        restartBtn.onClick.AddListener(restartGame);


        timerCanvas.gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.SetActive(false);
        timerCanvas.gameObject.transform.GetChild(2).gameObject.transform.GetChild(1).gameObject.SetActive(false);
        timerCanvas.gameObject.transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.SetActive(false);
        timerCanvas.gameObject.transform.GetChild(4).gameObject.transform.GetChild(1).gameObject.SetActive(false);
        timerCanvas.gameObject.transform.GetChild(5).gameObject.transform.GetChild(0).gameObject.SetActive(false);
        timerCanvas.gameObject.transform.GetChild(6).gameObject.transform.GetChild(1).gameObject.SetActive(false);
        timerCanvas.gameObject.transform.GetChild(7).gameObject.transform.GetChild(0).gameObject.SetActive(false);
        timerCanvas.gameObject.transform.GetChild(8).gameObject.transform.GetChild(1).gameObject.SetActive(false);
        timerCanvas.gameObject.transform.GetChild(9).gameObject.transform.GetChild(0).gameObject.SetActive(false);

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
        endGameCanvas.gameObject.transform.GetChild(1).gameObject.GetComponent< TMPro.TextMeshProUGUI > ().text = "Vrijeme: " + Timer.ToString("n2");
        //endGameCanvas.gameObject.transform.GetChild(2).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "Pc specifications: \n" +
        //    "CPU: i7-8400H \n" +
         //   "GPU: Asus Rog GTX 770\n" +
        //    "SPACE: 1TB HDD\n" +
         //   "RAM: " + InteractableObjects.ramsConnected * 8 + "Gb \n" +
         //   "POWER: 620W\n" +
         //   "FANS: " + InteractableObjects.numOfFans;


        
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
            timerCanvas.gameObject.transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if(InteractableObjects.powerDone == false) {
            timerCanvas.gameObject.transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.SetActive(false);
            timerCanvas.gameObject.transform.GetChild(3).gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
        else if(InteractableObjects.CPUDone == false) {
            timerCanvas.gameObject.transform.GetChild(3).gameObject.transform.GetChild(1).gameObject.SetActive(false);
            timerCanvas.gameObject.transform.GetChild(3).gameObject.transform.GetChild(2).gameObject.SetActive(true);
        }
        else if (InteractableObjects.CPUFanDone == false)
        {
            timerCanvas.gameObject.transform.GetChild(3).gameObject.transform.GetChild(2).gameObject.SetActive(false);
            timerCanvas.gameObject.transform.GetChild(3).gameObject.transform.GetChild(3).gameObject.SetActive(true);
        }
        else if (InteractableObjects.GPUDone == false)
        {
            timerCanvas.gameObject.transform.GetChild(3).gameObject.transform.GetChild(3).gameObject.SetActive(false);
            timerCanvas.gameObject.transform.GetChild(3).gameObject.transform.GetChild(4).gameObject.SetActive(true);

        }
        else if (InteractableObjects.ramDone == false)
        {
            timerCanvas.gameObject.transform.GetChild(3).gameObject.transform.GetChild(4).gameObject.SetActive(false);
            timerCanvas.gameObject.transform.GetChild(3).gameObject.transform.GetChild(5).gameObject.SetActive(true);
        }
        else if (InteractableObjects.diskDone == false)
        {
            timerCanvas.gameObject.transform.GetChild(3).gameObject.transform.GetChild(5).gameObject.SetActive(false);
            timerCanvas.gameObject.transform.GetChild(3).gameObject.transform.GetChild(6).gameObject.SetActive(true);
        }
        else if (InteractableObjects.cablesDone == false)
        {
            timerCanvas.gameObject.transform.GetChild(3).gameObject.transform.GetChild(6).gameObject.SetActive(false);
            timerCanvas.gameObject.transform.GetChild(3).gameObject.transform.GetChild(7).gameObject.SetActive(true);
        }

    }

    //ComponentTimes are always arranged by index, 0 - MB, PU, CPU, CPUFan, GPU, RAM, Disk, Cables, Fans(IF)
    void GuideChange() {

        if (InteractableObjects.motherBoardDone == false)
        {
            f = 0;
            timerCanvas.gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (InteractableObjects.powerDone == false)
        {
            if (f == 0)
            {
                componentTimes.Add(Timer);
                f = 1;
            }

            timerCanvas.gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.SetActive(false);
            timerCanvas.gameObject.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (InteractableObjects.CPUDone == false)
        {
            if (f == 1)    
            { 
                componentTimes.Add(Timer);
                f = 2;
            }
            timerCanvas.gameObject.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.SetActive(false);
            timerCanvas.gameObject.transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.SetActive(true);
        }
        else if (InteractableObjects.CPUFanDone == false) {
            if (f == 2)
            {
                componentTimes.Add(Timer);
                f = 3;
            }
            timerCanvas.gameObject.transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.SetActive(false);
            timerCanvas.gameObject.transform.GetChild(1).gameObject.transform.GetChild(3).gameObject.SetActive(true);
        }
        else if (InteractableObjects.GPUDone == false)
        {
            if (f == 3)
            {
                componentTimes.Add(Timer);
                f = 4;
            }
            timerCanvas.gameObject.transform.GetChild(1).gameObject.transform.GetChild(3).gameObject.SetActive(false);
            timerCanvas.gameObject.transform.GetChild(1).gameObject.transform.GetChild(4).gameObject.SetActive(true);
           
        }
        else if (InteractableObjects.ramDone == false)
        {
            if (f == 4)
            {
                componentTimes.Add(Timer);
                f = 5;
            }
            timerCanvas.gameObject.transform.GetChild(1).gameObject.transform.GetChild(4).gameObject.SetActive(false);
            timerCanvas.gameObject.transform.GetChild(1).gameObject.transform.GetChild(5).gameObject.SetActive(true);
            
        }
        else if (InteractableObjects.diskDone == false)
        {
            if (f == 5)
            {
                componentTimes.Add(Timer);
                f = 6;
            }
            timerCanvas.gameObject.transform.GetChild(1).gameObject.transform.GetChild(5).gameObject.SetActive(false);
            timerCanvas.gameObject.transform.GetChild(1).gameObject.transform.GetChild(6).gameObject.SetActive(true);
            
        }
        else if (InteractableObjects.cablesDone == false)
        {
            if (f == 6)
            {
                componentTimes.Add(Timer);
                f = 7;
            }
            timerCanvas.gameObject.transform.GetChild(1).gameObject.transform.GetChild(6).gameObject.SetActive(false);
            timerCanvas.gameObject.transform.GetChild(1).gameObject.transform.GetChild(7).gameObject.SetActive(true);
            
        }
        else if (InteractableObjects.numOfFans==0) {
            if (f == 7)
            {
                componentTimes.Add(Timer);
                f = 8;
            }
            timerCanvas.gameObject.transform.GetChild(1).gameObject.transform.GetChild(7).gameObject.SetActive(false);
            timerCanvas.gameObject.transform.GetChild(1).gameObject.transform.GetChild(8).gameObject.SetActive(true);
        }
        else{
            timerCanvas.gameObject.transform.GetChild(1).gameObject.transform.GetChild(8).gameObject.SetActive(false);
            timerCanvas.gameObject.transform.GetChild(1).gameObject.transform.GetChild(9).gameObject.SetActive(true);
            
        }
    }


}
