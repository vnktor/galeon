using System.Collections;
using UnityEngine;

namespace Roll_a_Ball
{
	public class ChangePlayerModel : MonoBehaviour {
		public GameObject[] playerModels;
		private GameObject currentPlayerModel;
		private int i;

		void Start() {
			currentPlayerModel = Instantiate(playerModels[0], playerModels[0].transform.position, Quaternion.identity);
		}

		void Update() {

			if (Input.GetMouseButtonDown(0)) {
				i++;
			}

			switch (i) {
				case 0:
					Destroy(currentPlayerModel);
					currentPlayerModel = Instantiate(playerModels[0], playerModels[0].transform.position, Quaternion.identity);
					break;

				case 1:
					Destroy(currentPlayerModel);
					currentPlayerModel = Instantiate(playerModels[1], playerModels[1].transform.position, Quaternion.identity);
					break;

				case 2:
					Destroy(currentPlayerModel);
					currentPlayerModel = Instantiate(playerModels[2], playerModels[2].transform.position, Quaternion.identity);
					break;

				case 3:
					Destroy(currentPlayerModel);
					i = 0;
					break;
			}
		}
	}
}