using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {

	public float speed;
	private Rigidbody rb;
	private int count;
	public Text countText;
	public Text winText;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText ();
		winText.text = "";
	}

	void FixedUpdate()
	{
		float moveHorizontal;
		float moveVertical;

		if (SystemInfo.deviceType == DeviceType.Desktop) {
			moveHorizontal = Input.GetAxis ("Horizontal");
			moveVertical = Input.GetAxis ("Vertical");
		} else {
			moveHorizontal = Input.acceleration.x;
			moveVertical = Input.acceleration.y;
		}

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Pickup")) 
		{
			other.gameObject.SetActive (false);
			count++;

			SetCountText ();
		}
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 12) 
		{
			winText.text = "You Win! Biatch";
		}
	}
}
