using COMIRON.GameFramework.Core;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace COMIRON.GameFramework.Ui {
	public class ButtonBase : ControllerBase, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler {
		public event System.Action<ButtonBase> OnActionClick;
		public event System.Action<ButtonBase> OnActionDown;
		public event System.Action<ButtonBase> OnActionUp;
		
		
		
		[Header("Not required")]
		[SerializeField]
		protected Image background;
		[SerializeField]
		protected Sprite backgroundOnDownSprite;
		
		
		
		private bool isActive;
		
		private bool isBackgroundChangeOnClickActivated;
		private Sprite backgroundSpriteDefault;
		
		protected virtual void Awake() {
			if (this.backgroundOnDownSprite != null) {
				this.backgroundSpriteDefault = this.background.sprite;
			}
		}
		
		protected virtual void Start() {
			this.isActive = true;
			
			this.ActivateBackgroundOnClickChange();
		}
		
		public void OnPointerClick(PointerEventData eventData) {
			if (this.IfActive() && this.OnActionClick != null) {
				this.OnActionClick(this);
			}
		}
		
		public virtual void OnPointerDown(PointerEventData eventData) {
			if (this.IfActive() && this.OnActionDown != null) {
				this.OnActionDown(this);
			}
			
			if (this.backgroundOnDownSprite != null && this.IfBackgroundOnClickChangeActivated()) {
				this.background.sprite = this.backgroundOnDownSprite;
			}
		}
		
		public virtual void OnPointerUp(PointerEventData eventData) {
			if (this.IfActive() && this.OnActionUp != null) {
				this.OnActionUp(this);
			}
			
			if (this.backgroundSpriteDefault != null && this.IfBackgroundOnClickChangeActivated()) {
				this.background.sprite = this.backgroundSpriteDefault;
			}
		}
		
		
		public void SimulateActionClick() {
			if (this.OnActionClick != null) {
				this.OnActionClick(this);
			}
		}
		
		public void SimulateActionDown() {
			if (this.OnActionDown != null) {
				this.OnActionDown(this);
			}
		}
		
		public virtual void SetActiveState(bool value) {
			this.isActive = value;
		}
		
		public virtual void DisableClicks() {
			this.SetActiveState(false);
		}
		
		public virtual void EnableClicks() {
			this.SetActiveState(true);
		}
		
		
		public bool IfActive() {
			return this.isActive;
		}
		
		
		public void ActivateBackgroundOnClickChange() {
			this.isBackgroundChangeOnClickActivated = true;
		}
		
		public void DeactivateBackgroundOnClickChange() {
			this.isBackgroundChangeOnClickActivated = false;
		}
		
		public bool IfBackgroundOnClickChangeActivated() {
			return this.isBackgroundChangeOnClickActivated;
		}
	}
}