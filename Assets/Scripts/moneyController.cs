using UnityEngine;
using UnityEngine.UI;
using Assets.Classes.Stats;

public class moneyController : MonoBehaviour {
    public Text money;
    private IStatable stats;

    void Start () {
        stats = ProxyStatistics.instance();
    }
	
	void Update () {
        money.text = stats.getSum() + "$";
	}
}
