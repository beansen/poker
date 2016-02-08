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

	public string GetStringValue()
	{
		return value;
	}

    public int GetIntegerValue()
    {
        int intValue = 0;

        switch(value)
        {
            case "2":
                intValue = 2;
                break;

            case "3":
                intValue = 3;
                break;

            case "4":
                intValue = 4;
                break;

            case "5":
                intValue = 5;
                break;

            case "6":
                intValue = 6;
                break;

            case "7":
                intValue = 7;
                break;

            case "8":
                intValue = 8;
                break;

            case "9":
                intValue = 9;
                break;

            case "10":
                intValue = 10;
                break;

            case "jack":
                intValue = 11;
                break;

            case "queen":
                intValue = 12;
                break;

            case "king":
                intValue = 13;
                break;

            case "ace":
                intValue = 14;
                break;
        }

        return intValue;
    }

    public string GetCardType()
	{
		return type;
	}
}
