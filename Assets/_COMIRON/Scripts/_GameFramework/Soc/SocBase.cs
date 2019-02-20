using System.Collections.Generic;
using COMIRON.GameFramework.Core;
using UnityEngine;

namespace COMIRON.GameFramework.Soc {
	public abstract class SocBase : MonoBehaviour {
		private List<SocBase> socList;

		public void Initialize(GameEngineBase gameEngine) {
			this.InitializeInherit();
		}

		protected abstract void InitializeInherit();
	}
}
