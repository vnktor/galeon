using UnityEngine;
using System.Security.Cryptography;
using System;

public class PrefsObject {
	private const string encryptingKey = "TyJk2Rw14vCs";
	private bool isEncryptionAvailable;
	private bool isEncryptHaveBeenUsed = false;
	
	private static PrefsObject instance = null;
	
	public static PrefsObject GetInstance() {
		return instance ?? (instance = new PrefsObject());
	}
	
	private PrefsObject() {
		#if UNITY_IPHONE && !UNITY_EDITOR
			this.isEncryptionAvailable = false;
		#else
			this.isEncryptionAvailable = true;
		#endif
	}
	
	private T Execute<T>(string key, T defaultValue) {
		key = this.EncryptString(encryptingKey, key);
		if (!PlayerPrefs.HasKey(key)) {
			return defaultValue;
		}
		
		string encodedValue = PlayerPrefs.GetString(key, "");
		string value = this.DecryptString(encryptingKey, encodedValue);
		
		if (typeof(int) == typeof(T)) {
			int _int;
			if (Int32.TryParse(value, out _int)) {
				return (T) (object) _int;
			}
			
			return defaultValue;
		}
		
		if (typeof(float) == typeof(T)) {
			float _float;
			if (float.TryParse(value, out _float)) {
				return (T) (object) _float;
			}
			
			return defaultValue;
		}
		
		if (typeof(double) == typeof(T)) {
			double _double;
			if (double.TryParse(value, out _double)) {
				return (T) (object) _double;
			}
			
			return defaultValue;
		}
		
		if (typeof(string) == typeof(T)) {
			return (T) (object) value;
		}
		
		return defaultValue;
	}
	
	private void AddPref<T>(string key, T value) {
		key = EncryptString(encryptingKey, key);
		string stringValue = "";
		
		if (value is int) {
			stringValue = ((int) (object) value).ToString();
		} else if (value is float) {
			stringValue = ((float) (object) value).ToString();
		} else if (value is double) {
			stringValue = ((double) (object) value).ToString();
		} else if (value is string) {
			stringValue = (string) (object) value;
		}
		
		string encodedValue = EncryptString(encryptingKey, stringValue);
		PlayerPrefs.SetString(key, encodedValue);
	}
	
	private string EncryptString(string _encryptionKey, string clearText) {
		if (!this.isEncryptHaveBeenUsed || !this.isEncryptionAvailable) {
			return clearText;
		}
		
		return EncDec.Encrypt(clearText, _encryptionKey);
	}
	
	private string DecryptString(string _encryptionKey, string cipherText) {
		if (cipherText == "") {
			return "";
		}
		
		if (!this.isEncryptHaveBeenUsed || !this.isEncryptionAvailable) {
			return cipherText;
		}
		
		try {
			return EncDec.Decrypt(cipherText, _encryptionKey);
		} catch (CryptographicException e) {
			e.ToString();
			return "";
		}
	}
	
	public T GetPref<T>(string key, bool useEncrypt = false) {
		this.isEncryptHaveBeenUsed = useEncrypt;
		
		if (typeof(int) == typeof(T)) {
			return Execute(key, (T) (object) 0);
		}
		
		if (typeof(float) == typeof(T)) {
			return Execute(key, (T) (object) 0f);
		}
		
		if (typeof(double) == typeof(T)) {
			return Execute(key, (T) (object) 0d);
		}
		
		return Execute(key, (T) (object) "");
	}
	
	public T GetPref<T>(string key, T defaultValue, bool useEncrypt = false) {
		this.isEncryptHaveBeenUsed = useEncrypt;
		
		return Execute(key, defaultValue);
	}
	
	public void SetPref(string key, string value, bool useEncrypt = false) {
		this.isEncryptHaveBeenUsed = useEncrypt;
		
		AddPref(key, value);
	}
	
	public void SetPref(string key, double value, bool useEncrypt = false) {
		this.isEncryptHaveBeenUsed = useEncrypt;
		
		AddPref(key, value);
	}
	
	public void SetPref(string key, float value, bool useEncrypt = false) {
		this.isEncryptHaveBeenUsed = useEncrypt;
		
		AddPref(key, value);
	}
	
	public void SetPref(string key, int value, bool useEncrypt = false) {
		this.isEncryptHaveBeenUsed = useEncrypt;
		
		AddPref(key, value);
	}
	
	
	public void Delete(string key, bool useEncrypt = false) {
		this.isEncryptHaveBeenUsed = useEncrypt;
		
		key = this.EncryptString(encryptingKey, key);
		PlayerPrefs.DeleteKey(key);
	}
	
	public bool IfHas(string key, bool useEncrypt = false) {
		this.isEncryptHaveBeenUsed = useEncrypt;
		
		key = this.EncryptString(encryptingKey, key);
		return PlayerPrefs.HasKey(key);
	}
}