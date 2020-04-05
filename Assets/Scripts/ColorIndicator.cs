using UnityEngine;
using TMPro;
public class ColorIndicator : MonoBehaviour {

	HSBColor color;

	void Start() {
		color = HSBColor.FromColor(GetComponent<Renderer>().sharedMaterial.GetColor("_Color"));
		transform.parent.BroadcastMessage("SetColor", color);
	}

	void ApplyColor ()
	{
		GetComponent<Renderer>().sharedMaterial.SetColor ("_Color", color.ToColor());
		transform.parent.BroadcastMessage("OnColorChange", color, SendMessageOptions.DontRequireReceiver);
    // Set planet color to star
    GameObject.FindWithTag ("New Star").GetComponent<Renderer>().material.SetColor("_Color", color.ToColor());
    // Set planet color to text
    // GameObject.FindWithTag ("New Star Name").GetComponent<TextMeshPro>().color = new Color32(255, 128, 0, 255);

    GameObject.FindWithTag ("New Star Name").GetComponent<TextMeshPro>().color = Color.HSVToRGB(color.h, color.s, color.b);
    Debug.Log(color.ToColor());
    Debug.Log(color);
	}

	void SetHue(float hue)
	{
		color.h = hue;
		ApplyColor();
    }	

	void SetSaturationBrightness(Vector2 sb) {
		color.s = sb.x;
		color.b = sb.y;
		ApplyColor();
	}
}
