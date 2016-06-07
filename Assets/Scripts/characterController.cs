using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class characterController : MonoBehaviour{

    public Text leveltxt;

	public float maxSpeed = 10f;
	bool wallRight = false;
	bool wallLeft = false;
	public Transform wallCheckRight;
	public Transform wallCheckLeft;
	public float groundRadius = 10f;
	public float score;
	public float move;
	public float timer;
    public Sprite[] levelSprites;

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
        changeLavel();
		timer += Time.deltaTime;

		float k = 1;
		if ((wallLeft && move < 0) || (wallRight && move > 0))
			k = 0;

		rb.velocity = new Vector2 (move * maxSpeed * k * (hook.stop ? 1:0) , rb.velocity.y);

		if (Input.GetKey(KeyCode.UpArrow))
		{
			if (!hook.isUsed) {
				hook.HookUp ();
			}
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			if (!hook.isUsed) {
				hook.HookDown ();
			}
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

    private void changeLavel()
    {
        if (score < 10000)
        {
            leveltxt.text = "1";
            GetComponent<SpriteRenderer>().sprite = levelSprites[0];
        }
        else if (score < 20000)
        {
            leveltxt.text = "2";
            GetComponent<SpriteRenderer>().sprite = levelSprites[1];
        }
        else if (score < 30000)
        {
            leveltxt.text = "3";
            GetComponent<SpriteRenderer>().sprite = levelSprites[2];
        }
        else
        {
            leveltxt.text = "4";
            GetComponent<SpriteRenderer>().sprite = levelSprites[3];
        }
    }
}
