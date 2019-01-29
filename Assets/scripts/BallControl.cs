﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallControl : MonoBehaviour {
	private Rigidbody rb;
	private int count;
	public Text textCont;
	public Text winText;

	private void Start() {
		this.rb = GetComponent<Rigidbody>();
		this.count = 0;
		this.SetTextCount(this.count);
		this.winText.text = "";
	}

	private void FixedUpdate() {
		float MoveHorizontal=Input.GetAxis("Horizontal");
		float MoveVertical=Input.GetAxis("Vertical");
		float speed = 10.0f;
		Vector3 movement = new Vector3(MoveHorizontal,0.0f,MoveVertical);
		this.rb.AddForce(movement * speed);
	}

	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Cube")) {
			other.gameObject.SetActive(false);
			this.count++;
			this.SetTextCount(this.count);
		}
	}

	private void SetTextCount(int aCount) {
		this.textCont.text = "Count :" + aCount.ToString();
		if(aCount > 11) {
			this.winText.text = "Вы выйграли!";
		}
	}
}