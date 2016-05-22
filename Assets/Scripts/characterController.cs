using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class characterController : MonoBehaviour{
	public float maxSpeed = 10f;
	bool facingRight = true;
	bool wallRight = false;
	bool wallLeft = false;
	bool move_left= false;
	bool move_right= false; 
	public Transform wallCheckRight;
	public Transform wallCheckLeft;
	public float groundRadius = 10f;
	public float score;
	public float move;
	public float timer;
	Rigidbody rb = new Rigidbody();
	HookController hook;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		hook = (HookController)FindObjectOfType(typeof(HookController));
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		move = Input.GetAxis ("Horizontal");

	}

	void Update(){

		timer += Time.deltaTime;

		float k = 1;
		if ((wallLeft && move < 0) || (wallRight && move > 0))
			k = 0;

		rb.velocity = new Vector2 (move * maxSpeed * k, rb.velocity.y);

		if (Input.GetKey(KeyCode.UpArrow))
		{
			hook.HookUp();
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			hook.HookDown();
		}
		if (Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}

		if (Input.GetKey(KeyCode.R))
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.name == "leftWall")
		{
			wallLeft=true;
		}
		if(col.name == "rightWall")
		{
			wallRight=true;
		}
	}

	void OnTriggerExit(Collider col)
	{
		if(col.name == "leftWall")
		{
			wallLeft=false;
		}
		if(col.name == "rightWall")
		{
			wallRight=false;
		}
	}
}
