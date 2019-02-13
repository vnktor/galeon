using System.Collections.Generic;
using COMIRON.GameFramework.Core;
using UnityEngine;

namespace COMIRON.GameFramework.Soc {
	public abstract class SocBase : MonoBehaviour {
		private GameEngineBase gameEngine;

		private List<SocBase> socList;

		public void Initialize(GameEngineBase gameEngine) {
			this.gameEngine = gameEngine;
		
			this.InitializeInherit();
		}

		protected abstract void InitializeInherit();
	}
}
