using UnityEngine;
using System.Collections;

public class ColorChanger : MonoBehaviour
{
	//Creates a variable that can be changed in the Unity Editor
	public Color tintColor;

	// Use this for initialization
	void Start ()
	{
		//Changes the color of the material we are going to render
		this.renderer.material.color = tintColor;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
