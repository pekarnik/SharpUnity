using UnityEngine;
using UnityEngine.UI;

public sealed class DisplayBonuses
{
    private Text _text;
    public DisplayBonuses()
	{

	}

	public void Display(int value)
	{
		_text.text = $"Вы набрали {value}";
	}
}
