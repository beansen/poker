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

	    Assert.AreEqual((int) PlayerResult.HighestCard, result.ResultIndex);
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

		Assert.AreEqual((int) PlayerResult.Pair, result.ResultIndex);
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

		Assert.AreEqual((int) PlayerResult.TwoPairs, result.ResultIndex);
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

		Assert.AreEqual((int) PlayerResult.ThreeOfAKind, result.ResultIndex);
	}

	[Test]
	public void CalculateResult_ResultShouldBeStraight()
	{
		CardValue firstCard = new CardValue(cardValues[0] + "_of_" + cardTypes[0]);
		CardValue secondCard = new CardValue(cardValues[5] + "_of_" + cardTypes[1]);
		CardValue thirdCard = new CardValue(cardValues[3] + "_of_" + cardTypes[3]);
		CardValue fourthCard = new CardValue(cardValues[1] + "_of_" + cardTypes[1]);
		CardValue fifthCard = new CardValue(cardValues[2] + "_of_" + cardTypes[0]);
		CardValue sixthCard = new CardValue(cardValues[12] + "_of_" + cardTypes[2]);
		CardValue seventhCard = new CardValue(cardValues[9] + "_of_" + cardTypes[3]);

		Result result = new Result(new CardValue[]{firstCard, secondCard}, new CardValue[]{thirdCard, fourthCard, fifthCard, sixthCard, seventhCard});
		result.CalculateResult();

		Assert.AreEqual((int) PlayerResult.Straight, result.ResultIndex);
	}

	[Test]
	public void CalculateResult_ResultShouldBeStraightWithHighestValueFive()
	{
		CardValue firstCard = new CardValue(cardValues[0] + "_of_" + cardTypes[0]);
		CardValue secondCard = new CardValue(cardValues[5] + "_of_" + cardTypes[1]);
		CardValue thirdCard = new CardValue(cardValues[3] + "_of_" + cardTypes[3]);
		CardValue fourthCard = new CardValue(cardValues[1] + "_of_" + cardTypes[1]);
		CardValue fifthCard = new CardValue(cardValues[2] + "_of_" + cardTypes[0]);
		CardValue sixthCard = new CardValue(cardValues[12] + "_of_" + cardTypes[2]);
		CardValue seventhCard = new CardValue(cardValues[9] + "_of_" + cardTypes[3]);

		Result result = new Result(new CardValue[]{firstCard, secondCard}, new CardValue[]{thirdCard, fourthCard, fifthCard, sixthCard, seventhCard});
		result.CalculateResult();

		Assert.AreEqual(thirdCard, result.PlayerHand[0]);
	}

	[Test]
	public void CalculateResult_ResultShouldBeStraightWithHighestValueAce()
	{
		CardValue firstCard = new CardValue(cardValues[10] + "_of_" + cardTypes[0]);
		CardValue secondCard = new CardValue(cardValues[5] + "_of_" + cardTypes[1]);
		CardValue thirdCard = new CardValue(cardValues[11] + "_of_" + cardTypes[3]);
		CardValue fourthCard = new CardValue(cardValues[8] + "_of_" + cardTypes[1]);
		CardValue fifthCard = new CardValue(cardValues[2] + "_of_" + cardTypes[0]);
		CardValue sixthCard = new CardValue(cardValues[12] + "_of_" + cardTypes[2]);
		CardValue seventhCard = new CardValue(cardValues[9] + "_of_" + cardTypes[3]);

		Result result = new Result(new CardValue[]{firstCard, secondCard}, new CardValue[]{thirdCard, fourthCard, fifthCard, sixthCard, seventhCard});
		result.CalculateResult();

		Assert.AreEqual(sixthCard, result.PlayerHand[0]);
	}

	[Test]
	public void CalculateResult_ResultShouldBeFlush()
	{
		CardValue firstCard = new CardValue(cardValues[10] + "_of_" + cardTypes[0]);
		CardValue secondCard = new CardValue(cardValues[5] + "_of_" + cardTypes[0]);
		CardValue thirdCard = new CardValue(cardValues[2] + "_of_" + cardTypes[3]);
		CardValue fourthCard = new CardValue(cardValues[8] + "_of_" + cardTypes[0]);
		CardValue fifthCard = new CardValue(cardValues[2] + "_of_" + cardTypes[0]);
		CardValue sixthCard = new CardValue(cardValues[12] + "_of_" + cardTypes[2]);
		CardValue seventhCard = new CardValue(cardValues[9] + "_of_" + cardTypes[0]);

		Result result = new Result(new CardValue[]{firstCard, secondCard}, new CardValue[]{thirdCard, fourthCard, fifthCard, sixthCard, seventhCard});
		result.CalculateResult();

		Assert.AreEqual((int) PlayerResult.Flush, result.ResultIndex);
	}

	[Test]
	public void CalculateResult_ResultShouldBeFlushWithHighestValueQueen()
	{
		CardValue firstCard = new CardValue(cardValues[10] + "_of_" + cardTypes[0]);
		CardValue secondCard = new CardValue(cardValues[5] + "_of_" + cardTypes[0]);
		CardValue thirdCard = new CardValue(cardValues[2] + "_of_" + cardTypes[3]);
		CardValue fourthCard = new CardValue(cardValues[8] + "_of_" + cardTypes[0]);
		CardValue fifthCard = new CardValue(cardValues[2] + "_of_" + cardTypes[0]);
		CardValue sixthCard = new CardValue(cardValues[12] + "_of_" + cardTypes[2]);
		CardValue seventhCard = new CardValue(cardValues[9] + "_of_" + cardTypes[0]);

		Result result = new Result(new CardValue[]{firstCard, secondCard}, new CardValue[]{thirdCard, fourthCard, fifthCard, sixthCard, seventhCard});
		result.CalculateResult();

		Assert.AreEqual(firstCard, result.PlayerHand[0]);
	}

	[Test]
	public void CalculateResult_ResultShouldBeFullHouse()
	{
		CardValue firstCard = new CardValue(cardValues[10] + "_of_" + cardTypes[0]);
		CardValue secondCard = new CardValue(cardValues[10] + "_of_" + cardTypes[1]);
		CardValue thirdCard = new CardValue(cardValues[2] + "_of_" + cardTypes[3]);
		CardValue fourthCard = new CardValue(cardValues[10] + "_of_" + cardTypes[2]);
		CardValue fifthCard = new CardValue(cardValues[2] + "_of_" + cardTypes[0]);
		CardValue sixthCard = new CardValue(cardValues[12] + "_of_" + cardTypes[2]);
		CardValue seventhCard = new CardValue(cardValues[9] + "_of_" + cardTypes[0]);

		Result result = new Result(new CardValue[]{firstCard, secondCard}, new CardValue[]{thirdCard, fourthCard, fifthCard, sixthCard, seventhCard});
		result.CalculateResult();

		Assert.AreEqual((int) PlayerResult.FullHouse, result.ResultIndex);
	}

	[Test]
	public void CalculateResult_ResultShouldBeFourOfAKind()
	{
		CardValue firstCard = new CardValue(cardValues[10] + "_of_" + cardTypes[0]);
		CardValue secondCard = new CardValue(cardValues[10] + "_of_" + cardTypes[1]);
		CardValue thirdCard = new CardValue(cardValues[2] + "_of_" + cardTypes[3]);
		CardValue fourthCard = new CardValue(cardValues[10] + "_of_" + cardTypes[2]);
		CardValue fifthCard = new CardValue(cardValues[2] + "_of_" + cardTypes[0]);
		CardValue sixthCard = new CardValue(cardValues[12] + "_of_" + cardTypes[2]);
		CardValue seventhCard = new CardValue(cardValues[10] + "_of_" + cardTypes[3]);

		Result result = new Result(new CardValue[]{firstCard, secondCard}, new CardValue[]{thirdCard, fourthCard, fifthCard, sixthCard, seventhCard});
		result.CalculateResult();

		Assert.AreEqual((int) PlayerResult.FourOfAKind, result.ResultIndex);
	}

	[Test]
	public void CalculateResult_ResultShouldBeStraightFlush()
	{
		CardValue firstCard = new CardValue(cardValues[10] + "_of_" + cardTypes[0]);
		CardValue secondCard = new CardValue(cardValues[11] + "_of_" + cardTypes[0]);
		CardValue thirdCard = new CardValue(cardValues[2] + "_of_" + cardTypes[3]);
		CardValue fourthCard = new CardValue(cardValues[10] + "_of_" + cardTypes[2]);
		CardValue fifthCard = new CardValue(cardValues[7] + "_of_" + cardTypes[0]);
		CardValue sixthCard = new CardValue(cardValues[9] + "_of_" + cardTypes[0]);
		CardValue seventhCard = new CardValue(cardValues[8] + "_of_" + cardTypes[0]);

		Result result = new Result(new CardValue[]{firstCard, secondCard}, new CardValue[]{thirdCard, fourthCard, fifthCard, sixthCard, seventhCard});
		result.CalculateResult();

		Assert.AreEqual((int) PlayerResult.StraightFlush, result.ResultIndex);
	}

	[Test]
	public void CalculateResult_ResultShouldBeRoyalFlush()
	{
		CardValue firstCard = new CardValue(cardValues[10] + "_of_" + cardTypes[0]);
		CardValue secondCard = new CardValue(cardValues[11] + "_of_" + cardTypes[0]);
		CardValue thirdCard = new CardValue(cardValues[2] + "_of_" + cardTypes[3]);
		CardValue fourthCard = new CardValue(cardValues[10] + "_of_" + cardTypes[2]);
		CardValue fifthCard = new CardValue(cardValues[8] + "_of_" + cardTypes[0]);
		CardValue sixthCard = new CardValue(cardValues[9] + "_of_" + cardTypes[0]);
		CardValue seventhCard = new CardValue(cardValues[12] + "_of_" + cardTypes[0]);

		Result result = new Result(new CardValue[]{firstCard, secondCard}, new CardValue[]{thirdCard, fourthCard, fifthCard, sixthCard, seventhCard});
		result.CalculateResult();

		Assert.AreEqual((int) PlayerResult.RoyalFlush, result.ResultIndex);
	}
}
