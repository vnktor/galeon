using System.Collections.Generic;
using System.Linq;
using COMIRON.GameFramework.Core;
using UnityEngine;

namespace COMIRON.GameFramework.Ui {
	public abstract class SocBase : MonoBehaviour {
		private GameEngineBase gameEngine;

		private List<SocBase> socList;

		public void Initialize(GameEngineBase gameEngine) {
			this.gameEngine = gameEngine;
		
			this.socList = this.GetComponentsInChildren<SocBase>(true).ToList();
			int socCount = this.socList.Count;
			for (int i = 0; i < socCount; i++) {
				var soc = this.socList[i];

				soc.Initialize(this.gameEngine);
			}

			this.InitializeInherit();
		}

		protected abstract void InitializeInherit();

		protected T GetSettings<T>() where T : SettingsBase {
			return this.gameEngine.GetSettings<T>();
		}
	}
}
