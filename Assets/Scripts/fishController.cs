using UnityEngine;
using Classes;
using Classes.FishFactories;
using UnityEngine.UI;

public class fishController : MonoBehaviour {

    public bool angry;
    public AudioClip soundFish;
    public Sprite[] sprites;
    public Text cointxt;

    public float starNotificationTime;
    private bool timerOn = false;
    private int timeNotification = 1;

    private float y;
    private bool direction = false;
    private Fish fish;
    private IFishFactory ff;
    private GameObject hookObject;
    
	void Start () {
        if (angry) ff = new AngryFishFactory(); else ff = new GoodFishFactory();
        fish = ff.generateFish();
        GetComponent<SpriteRenderer>().sprite = sprites[fish.SpriteNumber];
        y = transform.position.y;
    }
	
	void Update () {
        characterController charecter = ((characterController)FindObjectOfType(typeof(characterController)));
        if (timerOn) {
            if (charecter.timer - starNotificationTime > timeNotification) {
                cointxt.text = "";
                timerOn = false;
            }
        }
        transform.Translate(new Vector3(fish.Speed, 0, 0) * Time.deltaTime);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.name == "leftWall") 
        {
            transform.Rotate(Vector3.up, 180);
            direction = !direction;
        }
        if (col.name == "rightWall")
        {
            transform.Rotate(Vector3.up, 180);
            direction = !direction;
        }
        if (col.name == "hook")
        {
            HookController hook = ((HookController)FindObjectOfType(typeof(HookController)));
			if (!hook.isUsed)
            {
                hook.hookIn();
                hookObject = col.gameObject;
                hookObject.GetComponent<SpriteRenderer>().sprite = null;
				transform.position = hook.transform.position;
                transform.Rotate(Vector3.forward, 90);
                hook.isUsed = true;
                hook.stop = false;
                hook.side = false;
                fish.Speed = ((HookController)FindObjectOfType(typeof(HookController))).speed;
            }
        }
        if (col.name == "upWall")
        {
            transform.Rotate(Vector3.forward, -90);
            transform.position = new Vector3(-55.4F, y, 9.3F);
            fish.updateStats();
            fish = ff.generateFish();
            GetComponent<SpriteRenderer>().color = Color.white;
            GetComponent<SpriteRenderer>().sprite = sprites[fish.SpriteNumber];
            HookController hook = ((HookController)FindObjectOfType(typeof(HookController)));

            hookObject.GetComponent<SpriteRenderer>().sprite = hook.sprite;
            
            direction = true;

        }
        if (col.name == "upWallEffect")
        {
            if (fish.Money < 0)
            {
                cointxt.color = Color.red;
                cointxt.text = fish.Money + " $";
                starNotificationTime = ((characterController)FindObjectOfType(typeof(characterController))).timer;
                timerOn = true;
            }
            else {
                cointxt.text = "+ " + fish.Money + " $";
                cointxt.color = Color.yellow;
                starNotificationTime = ((characterController)FindObjectOfType(typeof(characterController))).timer;
                timerOn = true;
            }
            GetComponent<SpriteRenderer>().color = fish.Money > 0 ? Color.green : Color.red;
            GetComponent<AudioSource>().clip = soundFish;
            GetComponent<AudioSource>().Play();
        }
    }
}
