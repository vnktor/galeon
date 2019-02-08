using UnityEngine;
using UnityEngine.EventSystems;

namespace COMIRON.GameFramework.Ui {
	public class ButtonScalable : ButtonBase {
		private bool activateButton;
		private bool deactivateButton;
		
		private bool attractAttention;
		private bool normalize;
		
		
		private Vector3 defaultScale;
		
		private Vector3 scaleMax;
		
		private Vector3 scaleChangeSpeed;
		
		private bool isClickAnimationActivated;
		
		protected override void Awake() {
			base.Awake();
			
			this.DefaultScaleUpdate();
		}
		
		protected override void Start() {
			base.Start();
			
			this.ActivateClickAnimation();
		}
		
		protected void Update() {
			if (this.deactivateButton) {
				this.transform.localScale += this.scaleChangeSpeed * Time.deltaTime;
				if (this.transform.localScale.x >= this.scaleMax.x) {
					this.transform.localScale = this.scaleMax;
					this.deactivateButton = false;
				}
			} else if (this.activateButton) {
				this.transform.localScale -= this.scaleChangeSpeed * Time.deltaTime;
				if (this.transform.localScale.x <= this.defaultScale.x) {
					this.transform.localScale = this.defaultScale;
					this.activateButton = false;
				}
			} else if (this.attractAttention) {
				this.transform.localScale += this.scaleChangeSpeed * Time.deltaTime;
				if (this.transform.localScale.x >= this.scaleMax.x) {
					this.transform.localScale = this.scaleMax;
					this.attractAttention = false;
					this.normalize = true;
				}
			} else if (this.normalize) {
				this.transform.localScale -= this.scaleChangeSpeed * Time.deltaTime;
				if (this.transform.localScale.x <= this.defaultScale.x) {
					this.transform.localScale = this.defaultScale;
					this.normalize = false;
				}
			}
		}
		
		public override void OnPointerDown(PointerEventData eventData) {
			base.OnPointerDown(eventData);
			
			if (this.IfClickAnimationActivated()) {
				this.attractAttention = false;
				this.deactivateButton = true;
			}
		}
		
		public override void OnPointerUp(PointerEventData eventData) {
			base.OnPointerUp(eventData);
			
			if (this.IfClickAnimationActivated()) {
				this.attractAttention = false;
				this.activateButton = true;
			}
		}
		
		public void ActivateClickAnimation() {
			this.isClickAnimationActivated = true;
		}
		
		public void DeactivateClickAnimation() {
			this.isClickAnimationActivated = false;
		}
		
		public bool IfClickAnimationActivated() {
			return this.isClickAnimationActivated;
		}
		
		
		public void DefaultScaleUpdate() {
			this.defaultScale = this.transform.localScale;
			this.scaleMax = this.defaultScale * this.GetMaxScale();
			
			this.scaleChangeSpeed = this.defaultScale * 0.5f;
		}
		
		protected virtual float GetMaxScale() {
			return 1.25f;
		}
	}
}