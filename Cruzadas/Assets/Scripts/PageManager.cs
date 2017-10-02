using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageManager : MonoBehaviour {
    public GameObject[] pages;

    public int pg;

    public bool controle;

    public float timer;
    public float scaleX;

    public bool left;
    public bool right;

    public Text txt;

    public float delayTimer;
    public bool delayActive;

    public GameObject bookOpened;
    public GameObject bookClosed;

    // Use this for initialization
    void Start () {
        pg = 0;
        scaleX = -1;
	}

    private void FixedUpdate()
    {
        txt.text = "Página: " + ((pg + 1) * 2) + "/" + (pages.Length * 2);
    }

    // Update is called once per frame
    void Update() {
        if (delayActive == true)
            delayTimer += Time.deltaTime;

        if(delayTimer > 1.2f)
        {
            delayActive = false;
            delayTimer = 0;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && delayActive == false)
        {
            bookOpened.SetActive(false);
            bookClosed.SetActive(true);
            delayActive = true;
        }

            if (bookOpened.activeSelf == true)
        {
            if (pg < pages.Length - 1)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow) && delayActive == false)
                {
                    right = true;
                    delayActive = true;
                }
            }

            if (pg > 0)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow) && delayActive == false)
                {
                    left = true;
                    delayActive = true;
                }
            }

            else if (pg == 0)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow) && delayActive == false)
                {
                    bookOpened.SetActive(false);
                    bookClosed.SetActive(true);
                    delayActive = true;
                }
            }

            if (right == true && pg < pages.Length - 1)
            {
                pages[pg].transform.SetAsLastSibling();
                pages[pg].GetComponent<Animation>().Play("next");
                right = false;
            }

            if (pages[pg].transform.localScale.x == -1)
            {
                pages[pg].GetComponent<Animation>().Stop();
                pages[pg].transform.localScale = new Vector3(-1.01f, 1, 1);
                pg += 1;
            }

            if (pg > 0 && pages[pg].transform.localScale.x >= 1)
            {
                if (left == true)
                {
                    pages[pg - 1].transform.SetAsLastSibling();
                    //pages[pg - 1].GetComponent<Animation>().Play("last");
                    controle = true;
                    left = false;
                }

                if (pages[pg - 1].transform.localScale.x >= 1)
                {
                    //pages[pg - 1].GetComponent<Animation>().Stop();
                    pages[pg - 1].transform.localScale = new Vector3(1.01f, 1, 1);
                    scaleX = -1;
                    timer = 0;
                    controle = false;
                    pg -= 1;
                }

                if (controle == true)
                {
                    timer += Time.deltaTime;

                    if (timer > 0.02)
                    {
                        scaleX += 0.05f;
                        timer = 0;
                    }

                    pages[pg - 1].transform.localScale = new Vector3(scaleX, 1, 1);
                }
            }
        }
    }

    public void Left()
    {
        if (delayActive == false)
        {
            if (pg > 0)
            {
                left = true;
            }
            else if (pg == 0)
            {
                bookOpened.SetActive(false);
                bookClosed.SetActive(true);
            }

            delayActive = true;
        }
    }

    public void Right()
    {
        if (delayActive == false)
        {
            if (pg < pages.Length - 1 && pages[pg].transform.localScale.x >= 1)
                right = true;

            delayActive = true;
        }
    }
}
