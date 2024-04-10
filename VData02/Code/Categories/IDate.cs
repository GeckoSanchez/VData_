namespace VData02.Categories
{
	using System;

	public interface IDate : ICategory
	{
		DateOnly Data { get; }
	}
}
