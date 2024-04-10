namespace VData02.Categories
{
	using System.Numerics;

	public interface INumber : ICategory
	{
		decimal Data { get; }
		decimal Minimum { get; }
		decimal Maximum { get; }
	}

	public interface INumber<TNum> : INumber where TNum : notnull, System.Numerics.INumber<TNum>, IMinMaxValue<TNum>
	{
		new TNum Data { get; }
		new TNum Minimum { get; }
		new TNum Maximum { get; }
	}
}
