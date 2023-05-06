using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WindowGraph : MonoBehaviour
{
    [SerializeField] private Sprite circleSprite;
    [SerializeField] private RectTransform graphContainer;
    [SerializeField] private TextMeshProUGUI MaxValueText;

    private int NumOfErrors;

    [SerializeField] private TextMeshProUGUI UserErrors;
    [SerializeField] private Image UserErrorsBar;

    [SerializeField] private TextMeshProUGUI GeneralErrors;
    [SerializeField] private Image GeneralErrorsBar;


    [SerializeField]  private CanvasMng cnv;
    [SerializeField] private InteractableObjects io;

    [SerializeField] private Button infoBtn;
    [SerializeField] private GameObject errorCanvas;
    [SerializeField] private ErrorScript es;

    [SerializeField] private List<TextMeshProUGUI> times;
    private void Start()
    {
        infoBtn.onClick.AddListener(GetInfo);
        errorCanvas.SetActive(false);

    }
    private GameObject CreateCircleUser(Vector2 pos) {
        GameObject gameObject = new GameObject("circle", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().sprite = circleSprite;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = pos;
        rectTransform.sizeDelta = new Vector2(8, 8);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        gameObject.gameObject.transform.localScale = new Vector3(4, pos.y/4, 4);
        gameObject.gameObject.GetComponent<Image>().color = Color.red;


        return gameObject;
    }

    public void GetInfo() {
        errorCanvas.SetActive(true);
        List<float> test = cnv.GetTimes();
        NumOfErrors =  es.getNumOfErrors();
        ShowGraph(test);
        infoBtn.gameObject.SetActive(false);
    }

    private GameObject CreateCircleGeneral(Vector2 pos)
    {
        GameObject gameObject = new GameObject("circle", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().sprite = circleSprite;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = pos;
        rectTransform.sizeDelta = new Vector2(8, 8);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        gameObject.gameObject.transform.localScale = new Vector3(4, pos.y/4, 4);

        gameObject.gameObject.GetComponent<Image>().color = Color.blue;


        return gameObject;
    }

    private void ShowGraph(List<float> valueList)
    {
        List<float> valueListGeneral = new List<float>(8);


        valueListGeneral.Add(11f);
        valueListGeneral.Add(15f);
        valueListGeneral.Add(7f);
        valueListGeneral.Add(8f);
        valueListGeneral.Add(5f);
        valueListGeneral.Add(12f);
        valueListGeneral.Add(10f);
        valueListGeneral.Add(10.5f);

        // 1000,400
        float maxOfBoth = 0;


        

        for (int i = valueList.Count-1; i > 0; i--) {
            valueList[i] = valueList[i] - valueList[i - 1];
        }

        times[0].text = valueList[0].ToString("n2") + "s - " + valueListGeneral[0].ToString("n2") + "s";
        times[1].text = valueList[1].ToString("n2") + "s - " + valueListGeneral[1].ToString("n2") + "s";
        times[2].text = valueList[2].ToString("n2") + "s - " + valueListGeneral[2].ToString("n2") + "s";
        times[3].text = valueList[3].ToString("n2") + "s - " + valueListGeneral[3].ToString("n2") + "s";
        times[4].text = valueList[4].ToString("n2") + "s - " + valueListGeneral[4].ToString("n2") + "s";
        times[5].text = valueList[5].ToString("n2") + "s - " + valueListGeneral[5].ToString("n2") + "s";
        times[6].text = valueList[6].ToString("n2") + "s - " + valueListGeneral[6].ToString("n2") + "s";
        times[7].text = valueList[7].ToString("n2") + "s - " + valueListGeneral[7].ToString("n2") + "s";

        if (valueList.Max() > valueListGeneral.Max())
        {
            maxOfBoth = valueList.Max();
        }
        else
        {
            maxOfBoth = valueListGeneral.Max();
        }
        float yMax = maxOfBoth * 1.2f;

        MaxValueText.text = yMax.ToString("n2") + "s";

        GameObject lastUserGO = null;
        GameObject lastGeneralGO = null;

        for (int i = 0; i < valueList.Count; i++)
        {
            float posY = valueList[i] / yMax * 200;
            float posX = 25 + 125 * i;
            GameObject CircleUser = CreateCircleUser(new Vector2(posX, posY));
            lastUserGO = CircleUser;
        }

        for (int i = 0; i < valueListGeneral.Count; i++)
        {
            float posY = valueListGeneral[i] / yMax * 200;
            float posX = 70 + 125 * i;
            GameObject CircleGeneral = CreateCircleGeneral(new Vector2(posX, posY));
            lastGeneralGO = CircleGeneral;
        }

        //Mistakes Graph

        UserErrors.text = UserErrors.text + " - " + NumOfErrors.ToString();
        GeneralErrors.text = GeneralErrors.text + " - 2";

        int GenNumOfErrors = 4;
        float ErrorDiff = 0;
        if (NumOfErrors > GenNumOfErrors)
        {
            if (NumOfErrors == 0)
            {
                NumOfErrors = 1;
            }
            ErrorDiff = (NumOfErrors / GenNumOfErrors);
            UserErrorsBar.GetComponent<RectTransform>().localPosition =new Vector3(0, -250,0);
            UserErrorsBar.GetComponent<RectTransform>().localScale = new Vector3(1, 3, 1);

            GeneralErrorsBar.GetComponent<RectTransform>().localPosition = new Vector3(0, -400 + 50* (NumOfErrors / GenNumOfErrors), 0);
            GeneralErrorsBar.GetComponent<RectTransform>().localScale = new Vector3(1, (GenNumOfErrors / NumOfErrors)*3, 1);
        }
        else {
            if (NumOfErrors == 0) {
                NumOfErrors = 1;
            }
            ErrorDiff = GenNumOfErrors / NumOfErrors;
            GeneralErrorsBar.GetComponent<RectTransform>().localPosition = new Vector3(0, -250, 0);
            GeneralErrorsBar.GetComponent<RectTransform>().localScale = new Vector3(1, 3, 1);

            UserErrorsBar.GetComponent<RectTransform>().localPosition = new Vector3(0, -400 + 50* (GenNumOfErrors / NumOfErrors), 0);
            UserErrorsBar.GetComponent<RectTransform>().localScale = new Vector3(1, 3* (NumOfErrors / GenNumOfErrors), 1);
        }



    }

    private void CreateDotConnection(Vector2 dotPositionA, Vector2 dotPositionB, int flag) {
        GameObject gameObject = new GameObject("Malena", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        Color colorI = Color.white;
        if (flag == 1) {
            colorI = Color.red;
        }
        else {
            colorI = Color.blue;
            }


        gameObject.GetComponent<Image>().color = colorI;

        Vector2 dir = (dotPositionB - dotPositionA).normalized;
        float distance = Vector2.Distance(dotPositionA, dotPositionB);

        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(distance, 3f);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.anchoredPosition = dotPositionA + dir * distance * 0.5f ;
        float Tan = (dotPositionB.y - dotPositionA.y)/ (dotPositionB.x - dotPositionA.x);

        float angleX = Mathf.Rad2Deg * Mathf.Atan(Tan);

        rectTransform.rotation = Quaternion.Euler(0, -52.312f, angleX);
    }

}
