using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundHighlighter : MonoBehaviour {

	public Material highlightMaterial;

	public void Highlight(Color color)
	{
		var mat = Instantiate(highlightMaterial);
		mat.SetColor("_FirstOutlineColor", color);
		mat.SetColor("_SecondOutlineColor", new Color(color.r, color.g, color.b, 50/255.0f));
		GetComponentInChildren<Image>().material = mat;
	}

	public void Highlight()
	{
		GetComponentInChildren<Image>().material = highlightMaterial;
	}

	public void Unhighlight()
	{
		GetComponentInChildren<Image>().material = null;
	}

}
