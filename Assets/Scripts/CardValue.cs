using UnityEngine;
using System.Collections;

public class CardValue
{

	private string value;
	private string type;

	public CardValue(string value)
	{
		string[] splitValue = value.Split(new char[]{'_'});
		this.value = splitValue[0];
		this.type = splitValue[2];
	}

	public string GetValue()
	{
		return value;
	}

	public string GetCardType()
	{
		return type;
	}
}
