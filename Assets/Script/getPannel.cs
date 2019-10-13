using DanielLochner.Assets.SimpleScrollSnap;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getPannel : MonoBehaviour
{
    // Start is called before the first frame update
    public SimpleScrollSnap simpleScrollSnap;
    public int index;
    void Start()
    {
        index =0;
    }

    // Update is called once per frame
    void Update()
    {
        index = simpleScrollSnap.CurrentPanel;
        Debug.Log(index);
    }
}
