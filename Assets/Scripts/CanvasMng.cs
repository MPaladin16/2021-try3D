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
            timerCanvas.gameObject.transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text =
                "Mati?na plo?a je najve?a komponenta ra?unala, koristi se za me?usobno spajanje svih drugih komponenta \n" +
                "Utori za sve vanjske hardverske komponente trebali bi biti okrenuti prema vama";
        }
        else if(InteractableObjects.powerDone == false) {
            timerCanvas.gameObject.transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "" +
                "Jedinica za napajanje dovodi napajanje iz uti?nice do mati?ne plo?e i drugih komponenta \n" +
                "Sastoji se od ventilatora i dva razli?ita izlaza, jedan za vanjski kabel koji vodi do izvora napajanja \n" +
                "i drugi unutar ku?išta koji se koristi za napajanje svih komponenta";
        }
        else if(InteractableObjects.CPUDone == false) {
            timerCanvas.gameObject.transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "" +
                "Procesor je najmanji od svih komponenta koje koristimo za sastavljanje ra?unala \n" +
                "Tako?er je glavni i najvažniji ?ip u ra?unalu, odgovoran je za interpretaciju \n" +
                "ve?ine ra?unalnih naredbi";
        }
        else if (InteractableObjects.CPUFanDone == false)
        {
            timerCanvas.gameObject.transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "" +
                "Hladnjak je naj?eš?e veliki ventilator koji tako?er ponekad ima metalnu cijev na sebi \n" +
                "metalna cijev raspršuje zrak i sprje?ava procesor od pregrijavanja";
        }
        else if (InteractableObjects.GPUDone == false)
        {
            timerCanvas.gameObject.transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "" +
                "Grafi?ka procesorska jedinica obi?no je dio mati?ne plo?e, me?utim, kada je potrebna dodatna snaga \n" +
                "pri prikazu grafike koristimo namjenske grafi?ke kartice, one mogu obraditi mnogo podataka istovremeno \n" +
                "što ih ?ini korisnim za ure?ivanje videa, igranje, strojno u?enje i kripto rudarenje \n" +
                "Izgleda kao veliki kvadar s ventilatorom na sebi";

        }
        else if (InteractableObjects.ramDone == false)
        {
            timerCanvas.gameObject.transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "" +
                "RAM ili memorija s nasumi?nim pristupom koristi se za rukovanje i rješavanje svih aktivnih zadataka na vašem ra?unalu \n" +
                "više RAM-a zna?i više snage pri obavljanju zadataka na vašem ra?unalu \n" +
                "osobna ra?unala ovih dana obi?no koriste od 8 Gb do 32 Gb RAM-a \n" +
                "RAM treba postaviti odmah iza hladnjaka procesora";
        }
        else if (InteractableObjects.diskDone == false)
        {
            timerCanvas.gameObject.transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "" +

                "Tvrdi disk izgleda kao malena metalna kutija te se koristi za pohranu podataka \n" +
                "osim tvrdog diska, postoji i SSD koji je brži te se danas puno ?eš?e koristi \n" +
                "Kompjuteri ne mogu funkcionirati bez diska jer se oni koriste za podizanje operacijskog, \n" +
                "sustava, ali su tako?er tu da pohranu digitalnih podataka";
        }
        else if (InteractableObjects.cablesDone == false)
        {
            timerCanvas.gameObject.transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "" +

                "Kabeli služe kako bi se razmjenjivale informacije ili prenosila struja, \n" +
                "velika i snažne grafi?ke kartice obi?no trebaju dodatnu struju direktno od napajanja \n" +
                "Sve ostale komponente ra?unala dobiju struju preko mati?ne plo?e ili direktno od napajanja";
        }

    }

    //ComponentTimes are always arranged by index, 0 - MB, PU, CPU, CPUFan, GPU, RAM, Disk, Cables, Fans(IF)
    void GuideChange() {

        if (InteractableObjects.motherBoardDone == false)
        {
            f = 0;
            timerCanvas.gameObject.transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text =
                "Prona?ite mati?nu plo?u i stavite ju unutar ku?išta, okrenutu u pravom smjeru\n" +
                "vrlo je bitno zavidati vijke na krajevima mati?ne plo?e i tako u?vrstiti mati?nu plo?u \n" +
                "(Ovaj dio ne?emo napraviti u sklopu ovih instrukcija)";
        }
        else if (InteractableObjects.powerDone == false)
        {
            if (f == 0)
            {
                componentTimes.Add(Timer);
                f = 1;
            }
            timerCanvas.gameObject.transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "" +
                "Prona?i napajanje i postavi ga na pravilno mjesto unutar ra?unala \n" +
                "Napajanje ?e u ovom slu?aju biti postavljeno u donji dio ra?unala s ventilatorom okrenutim van ku?išta";
        }
        else if (InteractableObjects.CPUDone == false)
        {
            if (f == 1)    
            { 
                componentTimes.Add(Timer);
                f = 2;
            }
        timerCanvas.gameObject.transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "" +
                "Prona?i procesor i stavi ga na pravilno mjesto na mati?noj plo?i \n" +
                "nakon postavljanja procesora, koristimo malu koli?inu termalne paste \n" +
                "prije stavljanja ventilatora/hladnjaka na procesor (Pastu ne stavljamo kao dio ovih uputa, ali to je vitalan dio)";
        }
        else if (InteractableObjects.CPUFanDone == false) {
            if (f == 2)
            {
                componentTimes.Add(Timer);
                f = 3;
            }
            timerCanvas.gameObject.transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "" +
                "Prona?i hladnjak za procesor te ga postavi na procesor koji smo koristili u prošlom koraku, \n" +
                "vrlo je bitno pri?vrstiti hladnjak za mati?nu plo?u kako bi uvijek sigurno stajao iznad procesora";
        }
        else if (InteractableObjects.GPUDone == false)
        {
            if (f == 3)
            {
                componentTimes.Add(Timer);
                f = 4;
            }
            timerCanvas.gameObject.transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "" +
                "Prona?i grafi?ku karticu i stavi ju na pravilo mjesto na mati?noj plo?i, \n" +
                "Priklju?nici grafi?ke kartice trebali bi biti vidljivi izvan ku?išta, uz priklju?nike mati?ne plo?e";
        }
        else if (InteractableObjects.ramDone == false)
        {
            if (f == 4)
            {
                componentTimes.Add(Timer);
                f = 5;
            }
            timerCanvas.gameObject.transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "" +
                "Prona?i radnu memoriju te ju postavi unutar ra?unala na za nju predvi?eno mjesto, \n";
        }
        else if (InteractableObjects.diskDone == false)
        {
            if (f == 5)
            {
                componentTimes.Add(Timer);
                f = 6;
            }
            timerCanvas.gameObject.transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "" +
                "Prona?i tvrdi disk te ga postavi unutar ku?išta \n" +
                "Napravljeno je posebno mjesto za tvrdi disk, pripazi da su portovi dostupni za kasnije spajanje";
        }
        else if (InteractableObjects.cablesDone == false)
        {
            if (f == 6)
            {
                componentTimes.Add(Timer);
                f = 7;
            }
            timerCanvas.gameObject.transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "" +
                "Nakon što su sve komponente unutar ra?unala, potrebno je povezati komponente kabelima\n" +
                "kako bi mogle funkcionirati. Prona?i žuti kabel i mjesto na mati?noj plo?i gdje ga je \n" +
                "potrebno spojiti s napajanjem";
        }
        else if (InteractableObjects.numOfFans==0) {
            if (f == 7)
            {
                componentTimes.Add(Timer);
                f = 8;
            }
            timerCanvas.gameObject.transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "" +
                "Uspješno si sklopio vlastito ra?unalo \n" +
                "Kako se tvoje ra?unalo ne bi pregrijalo, možeš dodati jedan do tri ventilatora. \n" +
                "Ovo nije obavezan korak, ali je preporu?en kod sklapanja ra?unala.";
        }
        else{
            timerCanvas.gameObject.transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "" +
                "\n \n Pokušaj upaliti ra?unalo";
        }
    }


}
