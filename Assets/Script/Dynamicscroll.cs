using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Dynamicscroll : MonoBehaviour
{
    public ScrollRect scrollRect;
    public GameObject scrollContent;
    public GameObject scrollItemPrefab;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
       // for(int a =1;a<=20;a++)
       // {
            generateItem(1);
        generateItem(1); generateItem(1); generateItem(1);
        generateItem(1);
        // }
        scrollRect.verticalNormalizedPosition = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void generateItem(int itemnumber)
    {
        Debug.Log("working");
        GameObject scrollItemObj = Instantiate(scrollItemPrefab);
        scrollItemObj.transform.SetParent(scrollContent.transform, false);
        scrollItemObj.GetComponentInChildren<TextMeshProUGUI>().text = itemnumber.ToString();
    }
}
