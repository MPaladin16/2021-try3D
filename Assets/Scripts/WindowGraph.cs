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


    private void Start()
    {
        List<float> test = new List<float>() { 3,13,8,4,10,5,5,7};
        ShowGraph(test);

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

    private void ShowGraph(List<float> valueList) {

        List<float> valueListGeneral = new List<float>(8);

            
        valueListGeneral.Add(5f);
        valueListGeneral.Add(4f);
        valueListGeneral.Add(3f);
        valueListGeneral.Add(10f);
        valueListGeneral.Add(15f);
        valueListGeneral.Add(3f);
        valueListGeneral.Add(7f);
        valueListGeneral.Add(12f);

        // 1000,400
        float maxOfBoth = 0;
        if (valueList.Max() > valueListGeneral.Max())
        {
            maxOfBoth = valueList.Max();
        }
        else {
            maxOfBoth = valueListGeneral.Max();
        }
        float yMax = maxOfBoth * 1.2f;

        MaxValueText.text = yMax.ToString("n2") + "s";

        GameObject lastUserGO = null;
        GameObject lastGeneralGO = null;

        for (int i = 0; i < valueList.Count; i++) {
            float posY =  valueList[i]/ yMax * 400;
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
            float posY = valueListGeneral[i]/ yMax * 400;
            float posX = 150 + 100 * i;
            GameObject CircleGeneral = CreateCircleGeneral(new Vector2(posX, posY));
            if (lastGeneralGO != null)
            {
                CreateDotConnection(lastGeneralGO.GetComponent<RectTransform>().anchoredPosition, CircleGeneral.GetComponent<RectTransform>().anchoredPosition, 2);
            }
            lastGeneralGO = CircleGeneral;
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

        rectTransform.rotation = Quaternion.Euler(0, -55, angleX);
    }

}
