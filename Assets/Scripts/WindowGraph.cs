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
        gameObject.gameObject.transform.localScale = new Vector3(4, 4, 4);
        gameObject.gameObject.GetComponent<Image>().color = Color.red;

        return gameObject;
    }

    public void GetInfo() {
        errorCanvas.SetActive(true);
        List<float> test = cnv.GetTimes();
        NumOfErrors = io.GetnumOfErrors();
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
        gameObject.gameObject.transform.localScale = new Vector3(4.4f, 4.4f, 5);

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
            float posY = valueList[i] / yMax * 400;
            float posX = 150 + 100 * i;
            GameObject CircleUser = CreateCircleUser(new Vector2(posX, posY));
            if (lastUserGO != null)
            {
                CreateDotConnection(lastUserGO.GetComponent<RectTransform>().anchoredPosition, CircleUser.GetComponent<RectTransform>().anchoredPosition, 1);
            }
            lastUserGO = CircleUser;
        }

        for (int i = 0; i < valueListGeneral.Count; i++)
        {
            float posY = valueListGeneral[i] / yMax * 400;
            float posX = 150 + 100 * i;
            GameObject CircleGeneral = CreateCircleGeneral(new Vector2(posX, posY));
            if (lastGeneralGO != null)
            {
                CreateDotConnection(lastGeneralGO.GetComponent<RectTransform>().anchoredPosition, CircleGeneral.GetComponent<RectTransform>().anchoredPosition, 2);
            }
            lastGeneralGO = CircleGeneral;
        }

        //Mistakes Graph

        UserErrors.text = "USER ERRORS -" + NumOfErrors.ToString();
        GeneralErrors.text = "GENERAL ERRORS - 4";

        int GenNumOfErrors = 4;
        float ErrorDiff = 0;
        if (NumOfErrors > GenNumOfErrors)
        {
            ErrorDiff = (NumOfErrors / GenNumOfErrors);
            UserErrorsBar.GetComponent<RectTransform>().localPosition =new Vector3(0, -250,0);
            UserErrorsBar.GetComponent<RectTransform>().localScale = new Vector3(1, 3, 1);

            GeneralErrorsBar.GetComponent<RectTransform>().localPosition = new Vector3(0, -400 + 50* (NumOfErrors / GenNumOfErrors), 0);
            GeneralErrorsBar.GetComponent<RectTransform>().localScale = new Vector3(1, (GenNumOfErrors / NumOfErrors)*3, 1);
        }
        else {
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

        Debug.Log(distance);

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
