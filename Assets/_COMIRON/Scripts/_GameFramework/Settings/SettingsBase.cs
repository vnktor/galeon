using System;
using System.Linq;
using UnityEngine;

namespace COMIRON.GameFramework.Core {
	public abstract class SettingsBase : ScriptableObject {
		private string uniqueRepositoryIdentifier;
		
		public void Awake() {
			this.AwakeInherit();
			
			this.uniqueRepositoryIdentifier = this.GetType().FullName;
		}
		
		protected abstract void AwakeInherit();
		
		private string GetKeyForPref(Enum keys, params string[] slots) {
			return this.GetKeyForPref(new [] {keys}, slots);
		}
		
		private string GetKeyForPref(Enum[] keys, params string[] slots) {
			string slot = "";
			string key = "";
			
			if (slots != null) {
				slot = slots.Aggregate(slot, (current, s) => current + s);
			}
			
			if (keys != null) {
				key = keys.Aggregate(key, (current, k) => current + k);
			}
			return this.uniqueRepositoryIdentifier + key + slot;
		}
		
		
		#region SetPref
		protected void SetPref(Enum key, Enum value, params string[] slots) {
			this._SetPref(value.ToString(), this.GetKeyForPref(key, slots));
		}
		
		protected void SetPref(Enum key, string value, params string[] slots) {
			this._SetPref(value, this.GetKeyForPref(key, slots));
		}
		
		private void _SetPref(string value, string prefKey) {
			PrefsObject.GetInstance().SetPref(prefKey, value, true);
		}
		
		protected void SetPref(Enum key, double value, params string[] slots) {
			this._SetPref(value, this.GetKeyForPref(key, slots));
		}
		
		protected void SetPref(Enum[] key, double value, params string[] slots) {
			this._SetPref(value, this.GetKeyForPref(key, slots));
		}
		
		private void _SetPref(double value, string prefKey) {
			PrefsObject.GetInstance().SetPref(prefKey, value, true);
		}
		
		protected void SetPref(Enum key, float value, params string[] slots) {
			this._SetPref(value, this.GetKeyForPref(key, slots));
		}
		
		protected void SetPref(Enum[] key, float value, params string[] slots) {
			this._SetPref(value, this.GetKeyForPref(key, slots));
		}
		
		private void _SetPref(float value, string prefKey) {
			PrefsObject.GetInstance().SetPref(prefKey, value, true);
		}
		
		protected void SetPref(Enum key, int value, params string[] slots) {
			this._SetPref(value, this.GetKeyForPref(key, slots));
		}
		
		protected void SetPref(Enum[] key, int value, params string[] slots) {
			this._SetPref(value, this.GetKeyForPref(key, slots));
		}
		
		private void _SetPref(int value, string prefKey) {
			PrefsObject.GetInstance().SetPref(prefKey, value, true);
		}
		
		protected void SetPref(Enum key, bool value, params string[] slots) {
			this._SetPref(value, this.GetKeyForPref(key, slots));
		}
		
		protected void SetPref(Enum[] key, bool value, params string[] slots) {
			this._SetPref(value, this.GetKeyForPref(key, slots));
		}
		
		private void _SetPref(bool value, string prefKey) {
			this._SetPref(value ? 1 : 0, prefKey);
		}
		#endregion SetPref
		
		
		#region GetPref
		protected T GetPref<T>(Enum key) {
			return this._GetPref(default(T), this.GetKeyForPref(key));
		}
		
		protected T GetPref<T>(Enum[] key) {
			return this._GetPref(default(T), this.GetKeyForPref(key));
		}
		
		protected T GetPref<T>(Enum key, T defaultValue, params string[] slots) {
			return this._GetPref(defaultValue, this.GetKeyForPref(key, slots));
		}
		
		protected T GetPref<T>(Enum[] key, T defaultValue, params string[] slots) {
			return this._GetPref(defaultValue, this.GetKeyForPref(key, slots));
		}
		
		private T _GetPref<T>(T defaultValue, string prefKey) {
			if (typeof(int) == typeof(T)) {
				var value = (int) (object) PrefsObject.GetInstance().GetPref(prefKey, defaultValue, true);
				
				return (T) (object) value;
			}
			
			if (typeof(bool) == typeof(T)) {
				bool defaultValueBool = (bool) (object) defaultValue;
				var value = (int) (object) PrefsObject.GetInstance().GetPref(prefKey, defaultValueBool ? 1 : 0, true);
				
				return (T) (object) (value == 1 ? true : false);
			}
			
			if (typeof(float) == typeof(T)) {
				var value = (float) (object) PrefsObject.GetInstance().GetPref(prefKey, defaultValue, true);
				
				return (T) (object) value;
			}
			
			if (typeof(double) == typeof(T)) {
				var value = (double) (object) PrefsObject.GetInstance().GetPref(prefKey, defaultValue, true);
				
				return (T) (object) value;
			} else {
				var value = (string) (object) PrefsObject.GetInstance().GetPref(prefKey, defaultValue != null ? defaultValue.ToString() : null, true);
				
				if (defaultValue is Enum) {
					try {
						return this.ParseEnum<T>(value);
					} catch {
						return defaultValue;
					}
				}
				
				return (T) (object) value;
			}
		}
		#endregion GetPref
		
		
		#region Enum
		/// <summary>
		/// Использовать в тех ситуациях, когда не получается использовать <!--EnumExtensions<EnumType>.Parse()-->.
		/// К примеру в случаях с 'generics'.
		/// </summary>
		/// <typeparam name="T">Тиип Enum.</typeparam>
		/// <param name="value">Строковое значение.</param>
		/// <returns></returns>
		public T ParseEnum<T>(string value) {
			return (T) Enum.Parse(typeof(T), value, true);
		}
		
		/// <summary>
		/// Использовать в тех ситуациях, когда не получается использовать <!--EnumExtensions<EnumType>.Parse()-->.
		/// К примеру в случаях с 'generics'.
		/// </summary>
		/// <typeparam name="T">Тиип Enum.</typeparam>
		/// <param name="value">Строковое значение.</param>
		/// <param name="defaultValue">Значение возвращаемое в случае неудачной попытки преобразовать.</param>
		/// <returns></returns>
		public T ParseEnum<T>(string value, T defaultValue) {
			try {
				return (T) Enum.Parse(typeof(T), value, true);
			} catch {
				return defaultValue;
			}
		}
		#endregion Enum
	}
}