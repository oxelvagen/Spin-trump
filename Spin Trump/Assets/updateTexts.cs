using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updateTexts : MonoBehaviour
{
    public spinScript player;
    public Text textSpeed;
    public Text textSpins;
    public Text textHighestSpeed;
    void Start()
    {
        InvokeRepeating("uppdatera", 0.0f, 0.2f);
    }

    // Update is called once per frame
    void uppdatera()
    {
        textSpins.text = player.spins.ToString();

        textSpeed.fontSize = 100 + (((int)player.currentSpeed));
        textSpeed.color = GetBlendedColor((int)player.currentSpeed, (int)player.highestSpeed);
        textSpeed.text = player.currentSpeed.ToString("0.00");

        textHighestSpeed.text = player.highestSpeed.ToString("0.00");
    }



    public Color GetBlendedColor(int percentage, int mål)
    {
        double value = ((double)percentage / (double)mål) * 100;
        if (value < 80)
            return Interpolate(Color.red, Color.yellow, value / 80.0);
        if (value < 100)
            return Interpolate(Color.yellow, Color.green, (value - 80) / 20);
        return Color.green;
    }

    private Color Interpolate(Color color1, Color color2, double fraction)
    {
        float r = Interpolate(color1.r, color2.r, fraction);
        float g = Interpolate(color1.g, color2.g, fraction);
        float b = Interpolate(color1.b, color2.b, fraction);
        return new Color((int)Mathf.Round(r), (int)Mathf.Round(g), (int)Mathf.Round(b));
    }
    private float Interpolate(double d1, double d2, double fraction)
    {
        return (float)(d1 + (d2 - d1) * fraction);
    }
}
