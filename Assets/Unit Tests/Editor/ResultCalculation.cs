using NUnit.Framework;

[TestFixture]
public class ResultCalculation
{
	private string[] cardTypes = new string[]{"diamonds", "spades", "hearts", "clubs"};
	private string[] cardValues = new string[]{"2", "3", "4", "5", "6", "7", "8", "9", "10", "jack", "queen", "king", "ace"};

    [Test]
    public void CalculateResult_ResultShouldBeHighestCard()
    {
        CardValue firstCard = new CardValue(cardValues[0] + "_of_" + cardTypes[0]);
        CardValue secondCard = new CardValue(cardValues[5] + "_of_" + cardTypes[2]);
        CardValue thirdCard = new CardValue(cardValues[3] + "_of_" + cardTypes[3]);
        CardValue fourthCard = new CardValue(cardValues[8] + "_of_" + cardTypes[1]);
        CardValue fifthCard = new CardValue(cardValues[10] + "_of_" + cardTypes[0]);
        CardValue sixthCard = new CardValue(cardValues[1] + "_of_" + cardTypes[2]);
        CardValue seventhCard = new CardValue(cardValues[9] + "_of_" + cardTypes[3]);

	    Result result = new Result(new CardValue[]{firstCard, secondCard}, new CardValue[]{thirdCard, fourthCard, fifthCard, sixthCard, seventhCard});
	    result.CalculateResult();

	    Assert.AreEqual(0, result.ResultIndex);
    }

	[Test]
	public void CalculateResult_ResultShouldBePair()
	{
		CardValue firstCard = new CardValue(cardValues[0] + "_of_" + cardTypes[0]);
		CardValue secondCard = new CardValue(cardValues[5] + "_of_" + cardTypes[2]);
		CardValue thirdCard = new CardValue(cardValues[3] + "_of_" + cardTypes[3]);
		CardValue fourthCard = new CardValue(cardValues[8] + "_of_" + cardTypes[1]);
		CardValue fifthCard = new CardValue(cardValues[5] + "_of_" + cardTypes[0]);
		CardValue sixthCard = new CardValue(cardValues[1] + "_of_" + cardTypes[2]);
		CardValue seventhCard = new CardValue(cardValues[9] + "_of_" + cardTypes[3]);

		Result result = new Result(new CardValue[]{firstCard, secondCard}, new CardValue[]{thirdCard, fourthCard, fifthCard, sixthCard, seventhCard});
		result.CalculateResult();

		Assert.AreEqual(1, result.ResultIndex);
	}

	[Test]
	public void CalculateResult_ResultShouldBeTwoPairs()
	{
		CardValue firstCard = new CardValue(cardValues[0] + "_of_" + cardTypes[0]);
		CardValue secondCard = new CardValue(cardValues[5] + "_of_" + cardTypes[2]);
		CardValue thirdCard = new CardValue(cardValues[3] + "_of_" + cardTypes[3]);
		CardValue fourthCard = new CardValue(cardValues[8] + "_of_" + cardTypes[1]);
		CardValue fifthCard = new CardValue(cardValues[5] + "_of_" + cardTypes[0]);
		CardValue sixthCard = new CardValue(cardValues[0] + "_of_" + cardTypes[2]);
		CardValue seventhCard = new CardValue(cardValues[9] + "_of_" + cardTypes[3]);

		Result result = new Result(new CardValue[]{firstCard, secondCard}, new CardValue[]{thirdCard, fourthCard, fifthCard, sixthCard, seventhCard});
		result.CalculateResult();

		Assert.AreEqual(2, result.ResultIndex);
	}

	[Test]
	public void CalculateResult_ResultShouldBeThreeOfAKind()
	{
		CardValue firstCard = new CardValue(cardValues[0] + "_of_" + cardTypes[0]);
		CardValue secondCard = new CardValue(cardValues[5] + "_of_" + cardTypes[1]);
		CardValue thirdCard = new CardValue(cardValues[3] + "_of_" + cardTypes[3]);
		CardValue fourthCard = new CardValue(cardValues[8] + "_of_" + cardTypes[1]);
		CardValue fifthCard = new CardValue(cardValues[5] + "_of_" + cardTypes[0]);
		CardValue sixthCard = new CardValue(cardValues[5] + "_of_" + cardTypes[2]);
		CardValue seventhCard = new CardValue(cardValues[9] + "_of_" + cardTypes[3]);

		Result result = new Result(new CardValue[]{firstCard, secondCard}, new CardValue[]{thirdCard, fourthCard, fifthCard, sixthCard, seventhCard});
		result.CalculateResult();

		Assert.AreEqual(3, result.ResultIndex);
	}
}
