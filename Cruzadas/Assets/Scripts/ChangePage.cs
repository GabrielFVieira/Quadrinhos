using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePage : MonoBehaviour {
    public bool controle;
    public bool controle2;

    public float timer;
    public float x;
    public float x2;

    public GameObject page;

    public bool controleNxt;
    public bool controleLst;

    void Start () {
        x = 1;
	}
	
	void Update() { 
        if(controleNxt == true && page.transform.localScale.x <= 0)
        {
            page.GetComponent<Card>().page += 1;
            controleNxt = false;
        }

        if (controleLst == true && page.transform.localScale.x >= 0)
        {
            page.GetComponent<Card>().page -= 1;
            controleLst = false;
        }
        


        if (controle == true && page.transform.localScale.x <= -1f)
        {
            page.transform.localScale = new Vector3(-1, 1, 1);
            controle = false;
        }
        
        if (controle2 == true)
        {
            page.transform.SetAsLastSibling();
            timer += Time.deltaTime;

            if (timer > 0.01)
            {
                x2 += 0.05f;
                timer = 0;
            }

            page.transform.localScale = new Vector3(x2, 1, 1);
        }
        
        if (page.transform.localScale.x >= 1)
        {
            page.transform.localScale = new Vector3(1, 1, 1);
            x2 = -1;
            timer = 0;
            controle2 = false;
        }


        if (Input.GetKeyDown(KeyCode.LeftArrow))
            LastPage();

        if (Input.GetKeyDown(KeyCode.RightArrow))
            NextPage();

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    public void NextPage()
    {
        if (page.GetComponent<Card>().page < page.GetComponent<Card>().images.Length / 2 && controle2 == false)
        {
            page.transform.localScale = new Vector3(1, 1, 1);
            page.transform.SetAsLastSibling();
            page.GetComponent<Animation>().Play();
            controle = true;
            controleNxt = true;
        }
    }
    
    public void LastPage()
    {
        if (page.GetComponent<Card>().page > 1 && controle == false)
        {
            controle2 = true;
            controleLst = true;
        }
    }
}
