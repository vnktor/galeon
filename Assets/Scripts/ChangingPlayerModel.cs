using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roll_a_Ball {
	public class ChangingPlayerModel : MonoBehaviour {

		public GameObject newMainModel;
		public GameObject cubeModel;
		public GameObject cylinderModel;
		public GameObject sphereModel;
		public int counter;

        void Start() {
	        this.sphereModel = Resources.Load("PlayerModels/Sphere") as GameObject;
            this.cubeModel = Resources.Load("PlayerModels/Cube") as GameObject;
            this.cylinderModel = Resources.Load("PlayerModels/Cylinder") as GameObject;
			Debug.Log("------ " + newMainModel);
		}

		void Update() {
			if (Input.GetMouseButtonDown(1))
			{
				counter++;
			}

			switch (counter)
			{
                case 1:
				var a = Instantiate(cubeModel);
				a.transform.SetParent(this.transform);
				a.transform.localPosition = new Vector3();
				
				GameObject.Destroy(this.newMainModel);
				
				this.newMainModel = a;
				break;

				case 2:
				var b = Instantiate(cylinderModel);
				b.transform.SetParent(this.transform);
				b.transform.localPosition = new Vector3();

				GameObject.Destroy(this.newMainModel);

				this.newMainModel = b;
				break;

                case 3:
	            var c = Instantiate(sphereModel);
	            c.transform.SetParent(this.transform);
	            c.transform.localPosition = new Vector3();

	            GameObject.Destroy(this.newMainModel);

	            this.newMainModel = c;
	            break;

                case 4:
				GameObject.Destroy(this.newMainModel);
				counter = 1;
				break;
            }
		}
	}
}