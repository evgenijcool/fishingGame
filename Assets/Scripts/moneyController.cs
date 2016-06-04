using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Classes;
using Assets.Classes.Stats;

public class moneyController : MonoBehaviour {

    public Text money;
    private IStatable stats;
    // Use this for initialization
    characterController character;
    void Start () {
        stats = ProxyStatistics.instance();
        character = (characterController)FindObjectOfType(typeof(characterController));
    }
	
	// Update is called once per frame
	void Update () {
        money.text = stats.getSum() + "$";
        character.score = stats.getSum();
	}
}
