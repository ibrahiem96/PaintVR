using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour {

	public static ColorChanger Instance;

	void Awake(){
		if (Instance == null) {
			Instance = this;
		}
	}

	void OnDestroy(){
		if (Instance == this) {
			Instance = null;
		}
	}

	private Color c;

	void OnColorChange(HSBColor color){
		this.c = color.ToColor();
	}

	public Color GetCurrentColor(){
		return this.c;
	}
}
