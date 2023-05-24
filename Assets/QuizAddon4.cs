using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizAddon4 : MonoBehaviour
{
    public GameObject Addon;
    public GameObject Quiz4Question;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Quiz4Question.activeInHierarchy)
        {
            Addon.SetActive(true);
        }
        else
        {
            Addon.SetActive(false);
        }

    }
}
