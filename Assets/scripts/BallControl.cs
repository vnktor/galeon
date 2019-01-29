using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallControl : MonoBehaviour {
	public Text textCont;
	public Text winText;
	private Rigidbody rb;
	private int count;
	private Ray ray;
	private RaycastHit[] hits;
	private bool FlagClickMouse;				// флаг состояния объекта true- полный размер \false -исчез
	private Vector3 StartScale;					// начальный маштаб объекта
	private Vector3 CurrentScale;
	private Vector3 CurrentPointRescale;
	private bool isReScale;						// флаг выполнения плавной трансформации
	private float SpeedReScale;
	private int WayRescale;

	private void Start() {
		this.rb = GetComponent<Rigidbody>();
		this.count = 0;
		this.SetTextCount(this.count);
		this.winText.text = "";
		this.FlagClickMouse = true;
		this.StartScale= transform.localScale;
		this.isReScale = false;
		this.SpeedReScale = 2f;
		
	}

	private void Update() {
		// Обрабатываем нажатие кнопки
		if (Input.GetMouseButtonDown(0) && !this.isReScale) {
			// создаем луч из позиции камеры в сторону клика мыши
			this.ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
			//получаем пересечение со всеми объектами
			this.hits = UnityEngine.Physics.RaycastAll(this.ray);
			for (int i=0;i<this.hits.Length;i++) {
				if (this.hits[i].collider.gameObject.CompareTag("MainPlane")) {
					if (this.FlagClickMouse) {	// скрытие объекта
						this.FlagClickMouse = false;
						this.SetMakeReScale(-1, new Vector3(this.transform.position.x, 0, this.transform.position.z));
					}
					else {						// перемещение и восстановление размера
						this.FlagClickMouse = true;
						this.SetMakeReScale(1, new Vector3(this.hits[i].point.x, this.StartScale.y / 2.0f, this.hits[i].point.z));
					}
				}
			}
		}
		if(this.isReScale) {
			this.MakeReScale();
		}
	}

	// запуск плавного изменения Scale
	private void SetMakeReScale(int aWayReScale,Vector3 PointReScale) {
		this.isReScale = true;
		this.WayRescale = aWayReScale;
		this.CurrentScale=this.transform.localScale;
		this.CurrentPointRescale = PointReScale;
	}

	private void MakeReScale() {
		this.CurrentScale += this.StartScale * this.SpeedReScale * Time.deltaTime * this.WayRescale;
		if (this.CurrentScale.x <= 0) {
			this.CurrentScale = new Vector3(0, 0, 0);
			this.isReScale = false;
		}
		if (this.CurrentScale.x >= this.StartScale.x) {
			this.CurrentScale = this.StartScale;
			this.isReScale = false;
		}
		this.transform.position = (new Vector3(this.CurrentPointRescale.x, this.CurrentScale.y / 2.0f, this.CurrentPointRescale.z));
		this.transform.localScale = (Vector3)this.CurrentScale;
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