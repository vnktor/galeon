using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;
	public Transform trPlayer;
	private Rigidbody rb;
	private int count;
	private float UpdTimer;

	private void Start() {
		this.rb = GetComponent<Rigidbody>();
		this.count = 0;
		SetCountText();
		this.winText.text = "";
		this.UpdTimer = -1;
		this.trPlayer.position=new Vector3(PlayerPrefs.GetFloat("PlayerX"),0.5f,PlayerPrefs.GetFloat("PlayerZ"));
	}

	private void FixedUpdate() {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		this.rb.AddForce(movement * this.speed);

		if (Input.GetMouseButton(0)) {
			// Нажатие левой кнопки
			PlayerPrefs.SetFloat("PlayerX", this.trPlayer.position.x);
			PlayerPrefs.SetFloat("PlayerZ", this.trPlayer.position.z);
			this.rb.AddForce(transform.up * 25);
		}

		if (Input.GetMouseButton(1)) {
			// Нажатие правой кнопки
			this.trPlayer.localScale = new Vector3(0.6f, 0.6f, 0.6f);
			this.UpdTimer = 0.15f;
			this.trPlayer.position = new Vector3(PlayerPrefs.GetFloat("PlayerX"), 0.5f, PlayerPrefs.GetFloat("PlayerZ"));
		}

		if (this.UpdTimer != -1f) {
			UpdTimer -= Time.deltaTime;
			if (this.UpdTimer <= 0) {
				this.trPlayer.localScale = new Vector3(1, 1, 1);
				this.UpdTimer = -1f;
			}
		}
	}

	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("PickUp")) {
			other.gameObject.SetActive(false);
			this.count = this.count + 1;
			SetCountText();
		}
	}

	private void SetCountText() {
		this.countText.text = "Count: " + this.count.ToString();
		if(this.count >=12) {
			this.winText.text = "Победа";
		}
	}
}