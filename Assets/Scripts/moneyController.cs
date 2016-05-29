using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Classes;

public class moneyController : MonoBehaviour {

    public Text money;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        money.text = Statistics.getSum();
	}
}
