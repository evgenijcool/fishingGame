using UnityEngine;
using System.Collections;

public class waveController : MonoBehaviour {

	public float timer;
	public float period;
	public bool side;
	public int speed;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if (timer > period) 
		{
			timer -= period;
			side = !side;
		}

		transform.Translate(new Vector3(side ? speed : - speed, 0, 0) * Time.deltaTime);
	}

}
