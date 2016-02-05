[System.Serializable]
public class TestCard
{
	public Values value;
	public Types type;

	public enum Types {
		spades,
		clubs,
		hearts,
		diamonds
	}

	public enum Values {
		two,
		three,
		four,
		five,
		six,
		seven,
		eight,
		nine,
		ten,
		jack,
		queen,
		king,
		ace
	}
}
