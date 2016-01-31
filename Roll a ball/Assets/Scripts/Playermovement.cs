using UnityEngine;
using System.Collections;

public class Playermovement : MonoBehaviour {
	public float speed;
	public AudioClip sound;
	public AudioClip winsound;
	private float timecount;
	public GUIText screentime;
	public GUIText counttext;
	public GUIText restarttext;
	private bool restart;
	public GUIText wintext;
	public GUIText timer;
	private int count;
	public int dublicatecount=0;
	void Start ()
	{
		restart = false;
		count = 0;
		timecount = 0;
		setcounttext ();
		wintext.text = "";
		timer.text = "";
		restarttext.text = "";
	}
	void Update()
	{
		timecount += Time.deltaTime;
		screentime.text = "Time: " + timecount.ToString ("F2");
		if (restart && Input.GetKeyDown (KeyCode.R))
						Application.LoadLevel (Application.loadedLevel);


	}
	void FixedUpdate(){

		float movehorizontal = Input.GetAxis("Horizontal");
		float movevertical = Input.GetAxis("Vertical");
		Vector3 vec = new Vector3 (movehorizontal, 0.0f, movevertical);
		rigidbody.AddForce (vec * Time.deltaTime * speed);
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag=="pickup")
		{
			other.gameObject.SetActive(false);
			GetComponent<AudioSource>().PlayOneShot(sound);
			count = count + 1;
			dublicatecount = count;
			setcounttext();
			if(count>=16)
			{
				wintext.text = "YOU WIN!";
				timer.text = "TIME TAKEN: " + timecount.ToString("F2") + " sec";
				restarttext.text = "Press 'R' to restart";
				restart = true;
				GetComponent<AudioSource>().PlayOneShot(winsound);
			}

		}
	}
	void setcounttext()
	{
		counttext.text  = "Cubes: " + count.ToString ();
	}
}
