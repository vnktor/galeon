using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallControl : MonoBehaviour {
	public Text textCont;
	public Text winText;
	public Camera aCurrentCamera;
	private int aCount;
	private Ray aRay;
	private RaycastHit[] aHits;
	private bool aFlagClickMouse;
	private Vector3 aStartScale;
	private Vector3 aCurrentScale;
	private Vector3 aCurrentPointRescale;
	private bool isReScale;
	private float aSpeedReScale;
	private int aWayRescale;

	private void Start() {
		this.aCount = 0;
		this.SetTextCount(this.aCount);
		this.winText.text = "";
		this.aFlagClickMouse = true;
		this.aStartScale= transform.localScale;
		this.isReScale = false;
		this.aSpeedReScale = 2.0f;
	}

	private void Update() {
		if (Input.GetMouseButtonDown(0) && !this.isReScale) {
			this.aRay = this.aCurrentCamera.ScreenPointToRay(Input.mousePosition);
			this.aHits = UnityEngine.Physics.RaycastAll(this.aRay);
			for (int i = 0; i < this.aHits.Length; i++) {
				if (this.aHits[i].collider.gameObject.CompareTag("MainPlane")) {
					if (this.aFlagClickMouse) {
						this.aFlagClickMouse = false;
						this.SetMakeReScale(-1, new Vector3(this.transform.position.x, 0, this.transform.position.z));
					}
					else {
						this.aFlagClickMouse = true;
						this.SetMakeReScale(1, new Vector3(this.aHits[i].point.x, this.aStartScale.y / 2.0f, this.aHits[i].point.z));
					}
				}
			}
		}
	}

	private void FixedUpdate() {
		if(this.isReScale) {
			this.MakeReScale();
		}
	}

	private void SetMakeReScale(int aWayReScale,Vector3 PointReScale) {
		this.isReScale = true;
		this.aWayRescale = aWayReScale;
		this.aCurrentScale=this.transform.localScale;
		this.aCurrentPointRescale = PointReScale;
	}

	private void MakeReScale() {
		this.aCurrentScale += this.aStartScale * this.aSpeedReScale * Time.deltaTime * this.aWayRescale;
		if (this.aCurrentScale.x <= 0) {
			this.aCurrentScale = new Vector3(0, 0, 0);
			this.isReScale = false;
		}
		if (this.aCurrentScale.x >= this.aStartScale.x) {
			this.aCurrentScale = this.aStartScale;
			this.isReScale = false;
		}
		this.transform.position = (new Vector3(this.aCurrentPointRescale.x, this.aCurrentScale.y / 2.0f, this.aCurrentPointRescale.z));
		this.transform.localScale = (Vector3)this.aCurrentScale;
	}

	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Cube")) {
			other.gameObject.SetActive(false);
			this.aCount++;
			this.SetTextCount(this.aCount);
		}
	}

	private void SetTextCount(int aCount) {
		this.textCont.text = "Count :" + aCount.ToString();
		if(aCount > 11) {
			this.winText.text = "Вы выйграли!";
		}
	}
}