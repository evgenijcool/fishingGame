using Assets.Classes.Stats;
using UnityEngine;
using UnityEngine.UI;

public class characterController : MonoBehaviour{

    public Text leveltxt;
	public float maxSpeed = 10f;
	public float timer;
    public Sprite[] levelSprites;

    private bool wallRight = false;
    private bool wallLeft = false;
    private float move;
    private Rigidbody rb = new Rigidbody();
	private HookController hook;
    
	void Start () {
		rb = GetComponent<Rigidbody> ();
		hook = (HookController)FindObjectOfType(typeof(HookController));
	}
	
	void FixedUpdate () {
		move = Input.GetAxis ("Horizontal");
	}

    void Update()
    {
        changeLavel();
        timer += Time.deltaTime;

        float k = 1;
        if ((wallLeft && move < 0) || (wallRight && move > 0))
            k = 0;

        rb.velocity = new Vector2(move * maxSpeed * k * (hook.stop ? 1 : 0), rb.velocity.y);

        if (!hook.isUsed)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                hook.HookUp();
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                hook.HookDown();
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
        int score = ProxyStatistics.instance().getSum();
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
