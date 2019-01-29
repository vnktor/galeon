using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallControl : MonoBehaviour {
    private Rigidbody rb;
    private int count;
    public Text textCont;
    public Text winText;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetTextCount(count);
        winText.text = "";
    }

    private void FixedUpdate() {
        float MoveHorizontal = Input.GetAxis("Horizontal");
        float MoveVertical = Input.GetAxis("Vertical");
        float speed = 10.0f;
        Vector3 movement = new Vector3(MoveHorizontal, 0.0f, MoveVertical);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Cube")) {
            other.gameObject.SetActive(false);
            count++;
            SetTextCount(count);
        }
    }

    private void SetTextCount(int count) {
        textCont.text = "Count :" + count.ToString();
        if (count > 11)
            winText.text = "Вы выйграли!";
    }
}
