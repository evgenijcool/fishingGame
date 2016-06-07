using UnityEngine;

public class MenuControl : MonoBehaviour {

    public GameObject menu;
    private float showedMenuPosition = 0;
    private float hidedMenuPosition = 1300;
    private static bool isShow = true;

	void Start () {
        if (menu != null)
        {
            showedMenuPosition = menu.GetComponent<RectTransform>().localPosition.y;
        }
        if (name == "pauseButton")
        {
            GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => Paused());
        }
        if (name == "continue")
        {
            GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => Continue());
        }
        if (name == "exit") {
            GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => Exit());
        }
        Time.timeScale = 0;
    }

    void Update () {

    }

    private void Paused()
    {
        if (!isShow)
        {
            Time.timeScale = 0;
            show();
            isShow = true;
        }
    }

    private void Continue() {
        if (isShow)
        {
            Time.timeScale = 1;
            hide();
            isShow = false;
        }
    }

    private void Exit() {
        Application.Quit();
    }

    private void show() {
        menu.GetComponent<RectTransform>().localPosition = new Vector3(menu.GetComponent<RectTransform>().localPosition.x, showedMenuPosition, menu.GetComponent<RectTransform>().localPosition.z);
    }

    private void hide() {
        menu.GetComponent<RectTransform>().localPosition = new Vector3(menu.GetComponent<RectTransform>().localPosition.x, hidedMenuPosition, menu.GetComponent<RectTransform>().localPosition.z);
    }

}
