using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Classes;
using Assets.Classes.Stats;

public class moneyController : MonoBehaviour {

    public Text money;
    private IStatable stats; 
	// Use this for initialization
	void Start () {
        stats = ProxyStatistics.instance();	
	}
	
	// Update is called once per frame
	void Update () {
        money.text = stats.getSum() + "$";
	}
}
