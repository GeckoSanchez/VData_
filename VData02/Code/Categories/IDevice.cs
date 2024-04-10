namespace VData02.Categories
{
	public interface IDevice : ICategory
	{
		/// <summary>
		/// The <see cref="DeviceIdentity"/> Identity of this <see cref="IDevice"/>
		/// </summary>
		//DeviceIdentity Identity { get; }
	}

	public interface IDevice<TLinked> : IDevice
	{
		/// <summary>
		/// The <see cref="DeviceIdentity"/> Identity of this
		/// <see cref="IDevice"/><![CDATA[<]]><typeparamref name="TLinked"/><![CDATA[>]]>
		/// </summary>
		//new DeviceIdentity Identity { get; }
	}
}
