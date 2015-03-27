using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	private int count;

	public GameObject textGuiObj;
	private Text gameText;

	// Use this for initialization
	void Start () {
		count = 0;
		gameText = textGuiObj.GetComponent<Text> ();
		SetCountText();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		GetComponent<Rigidbody>().AddForce (movement * speed * Time.deltaTime);

	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "PickUp") {
			other.gameObject.SetActive(false);
			count = count + 1;
			SetCountText();
		}
	}

	void SetCountText(){
		gameText.text = "Player Score: " +  count;
	}

}
