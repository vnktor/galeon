using RollaBall;
using System.Collections;
using UnityEngine;

namespace CkicktoPlayer {
	public class ClickMouse : MonoBehaviour {
		public Animation animObject;
		
		private RollaBall.PlayerMove Pause;
		
		IEnumerator SetCollider(PlayerMove obj, bool value, float time) {
			yield return new WaitForSeconds(time);
			obj.enabled = value;
		}
		
		private void OnMouseDown() {
			Pause = GetComponent<PlayerMove>();
			StartCoroutine(SetCollider(GetComponent<PlayerMove>(), false, 2.5f));
			StartCoroutine(SetCollider(GetComponent<PlayerMove>(), true, 2.5f));
			Pause.enabled = !Pause.enabled;
			
			animObject.Rewind("playerAnim");
			animObject.Play("playerAnim");
		}
	}
}