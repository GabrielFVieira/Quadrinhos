using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBook : MonoBehaviour {
    public GameObject bookOpened;
    public PageManager book;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bookOpened.SetActive(true);
            gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

    }

    public void Open()
    {
        bookOpened.SetActive(true);
        gameObject.SetActive(false);
    }
}
