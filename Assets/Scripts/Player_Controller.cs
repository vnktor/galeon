using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour {

    public float speed;
    private Rigidbody rb;

    private int count;
    // Text fields
    public Text countText, winText;

    void Start() {
        rb = GetComponent<Rigidbody>();
        count = 0;
        winText.text = "";
        setCount ();
    }

    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter (Collider gold) { 
        if (gold.tag == "Point") {
            Destroy (gold.gameObject);
            count++;
            setCount();
        }
    }

    void setCount () {
        countText.text = "Gold: " + count.ToString ();
        if (count >= 11)
            winText.text = "You Win!";
    }

}