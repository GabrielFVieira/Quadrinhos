using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageFlip : MonoBehaviour {
    public Sprite[] pages;

    // Use this for initialization
    void Start () {	
	}

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x >= 0)
        {
            GetComponent<Image>().sprite = pages[0];           
        }

        if (transform.localScale.x < 0)
        {
            GetComponent<Image>().sprite = pages[1];
        }
    }
}
