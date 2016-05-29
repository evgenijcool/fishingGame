﻿using UnityEngine;
using System.Collections;
using System;

public class MenuControl : MonoBehaviour {

    public GameObject menu;
    private float showedMenuPosition = 0;
    private float hidedMenuPosition = 1300;
    private static bool isShow = true;
	// Use this for initialization
	void Start () {
        if (menu != null)
        {
            showedMenuPosition = menu.GetComponent<RectTransform>().localPosition.y;
        }
        if (name == "pauseButton")
        {
            GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => Pause());
        }
        if (name == "continue")
        {
            GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => Continue());
        }
        if (name == "exit") {
            GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => Exit());
        }
    }

    // Update is called once per frame
    void Update () {

    }

    private void Pause()
    {
        if (!isShow)
        {
            Debug.Log("Pause");
            Time.timeScale = 0;
            show();
            isShow = true;
        }
    }

    private void Continue() {
        if (isShow)
        {
            Debug.Log("Continue");
            Time.timeScale = 1;
            hide();
            isShow = false;
        }
    }

    private void Exit() {
        Application.Quit();
    }

    private void show() {
        Debug.Log(menu.GetComponent<RectTransform>().localPosition.ToString());
        menu.GetComponent<RectTransform>().localPosition = new Vector3(menu.GetComponent<RectTransform>().localPosition.x, showedMenuPosition, menu.GetComponent<RectTransform>().localPosition.z);
    }

    private void hide() {
        Debug.Log(menu.GetComponent<RectTransform>().localPosition.ToString());
        menu.GetComponent<RectTransform>().localPosition = new Vector3(menu.GetComponent<RectTransform>().localPosition.x, hidedMenuPosition, menu.GetComponent<RectTransform>().localPosition.z);
    }

}