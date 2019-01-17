using UnityEngine;

public class Rotator : MonoBehaviour {

	private void Update (){
		this.transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
	}
}