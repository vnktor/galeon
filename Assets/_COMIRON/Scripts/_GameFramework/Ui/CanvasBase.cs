using System.Collections.Generic;
using System.Linq;
using COMIRON.GameFramework.Core;
using UnityEngine;

namespace COMIRON.GameFramework.Ui {
	public abstract class CanvasBase : MonoBehaviour {
		private GameEngineBase gameEngine;
		
		private List<PanelBase> panels;
		
		public void Initialize(GameEngineBase gameEngine) {
			this.gameEngine = gameEngine;
			
			this.panels = this.GetComponentsInChildren<PanelBase>(true).ToList();
			int panelsCount = this.panels.Count;
			for (int i = 0; i < panelsCount; i++) {
				var panel = this.panels[i];
				
				panel.Initialize(this.gameEngine);
			}
			
			this.InitializeInherit();
		}
		
		protected abstract void InitializeInherit();
		
		protected T GetSettings<T>() where T : SettingsBase {
			return this.gameEngine.GetSettings<T>();
		}
		
		public T AddPanel<T>(Vector3 position = default(Vector3)) where T : PanelBase {
			return this.AddPanel<T>((T) this.gameEngine.GetLinkPanel<T>().GetPanel(), position);
		}
		
		public T AddPanel<T>(T panelPrefab, Vector3 position = default(Vector3)) where T : PanelBase {
			RectTransform prefabRt = panelPrefab.GetComponent<RectTransform>();
			if (position == default(Vector3)) {
				position = new Vector3();
			}
			
			var clone = Object.Instantiate(prefabRt, new Vector3(), Quaternion.identity, this.transform);
			
			T newPanel = clone.GetComponent<T>();
			RectTransform rT = newPanel.GetComponent<RectTransform>();
			// Сначала производим Deactivate И только затем вызываем Initialize. Т.к. в initialize устанавливается состояние панели взависимости от активности gameObject.
			newPanel.gameObject.SetActive(false);
			rT.sizeDelta = prefabRt.sizeDelta;
			rT.anchoredPosition3D = position;
			newPanel.Initialize(this.gameEngine);
			this.panels.Add(newPanel);
			
			return newPanel;
		}
	}
}