using UnityEngine;

public class waveController : MonoBehaviour {
	public float period;
	public bool side;
	public int speed;

    private float timer;

    void Start () {
	}
	
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
