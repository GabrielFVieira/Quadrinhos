using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour {
    public int page;

    public GameObject pageBack;
    public GameObject pageFront;

    public bool voltar;
    public bool avançar;

    public Sprite[] images;
	// Use this for initialization
	void Start () {
        page = 1;
	}
    
	// Update is called once per frame
	void Update () {
        int i = 0;
        if(pageBack.GetComponent<Image>().sprite == pageFront.GetComponent<Image>().sprite)
        {
            Debug.Log("Aqui" + page);
        }

        if(page == 1)
        {
            pageBack.GetComponent<Image>().sprite = images[0];
            pageFront.GetComponent<Image>().sprite = images[3];

            if (transform.localScale.x >= 0)
                GetComponent<Image>().sprite = images[1];
        }

        else if(page == 2)
        {
            if (transform.localScale.x >= 0 && GetComponent<Image>().sprite != images[3])
                GetComponent<Image>().sprite = images[3];

            else if (transform.localScale.x < 0 && GetComponent<Image>().sprite != images[2])
                GetComponent<Image>().sprite = images[2];

            
            if (transform.localScale.x < 1 && transform.localScale.x >= 0 && pageFront.GetComponent<Image>().sprite != images[5])
            {
                pageFront.GetComponent<Image>().sprite = images[5];
            }

            else if (transform.localScale.x > -1 && transform.localScale.x <= 0 && pageBack.GetComponent<Image>().sprite != images[0])
            {
                pageBack.GetComponent<Image>().sprite = images[0];
            }
            
            if (transform.localScale.x == 1)
                pageFront.GetComponent<Image>().sprite = GetComponent<Image>().sprite = images[3];

            else if (transform.localScale.x == -1)
                pageBack.GetComponent<Image>().sprite = GetComponent<Image>().sprite = images[2];
        }

        else if (page == 3)
        {
            if (transform.localScale.x >= 0 && GetComponent<Image>().sprite != images[5])
                GetComponent<Image>().sprite = images[5];

            else if (transform.localScale.x < 0 && GetComponent<Image>().sprite != images[4])
                GetComponent<Image>().sprite = images[4];
            
            if (transform.localScale.x < 1 && transform.localScale.x > 0 && pageFront.GetComponent<Image>().sprite != images[5])
            {
                pageFront.GetComponent<Image>().sprite = images[5];
            }
            
            if (transform.localScale.x > -1 && transform.localScale.x < 0 && pageBack.GetComponent<Image>().sprite != images[2])
            {
                pageBack.GetComponent<Image>().sprite = images[2];
            }
            
            if (transform.localScale.x == 1)
                pageFront.GetComponent<Image>().sprite = GetComponent<Image>().sprite = images[5];

            else if (transform.localScale.x == -1)
                pageBack.GetComponent<Image>().sprite = GetComponent<Image>().sprite = images[4];
        }
    }
}
