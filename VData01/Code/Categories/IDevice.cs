namespace VData01.Categories
{
	using Identities;
	using Properties;

	public interface IDevice : ICategory, IActivatable, ICreatable, IDeletable, IInitializable, ILinkable
	{
		/// <summary>
		/// The <see cref="DeviceIdentity"/> Identity of this <see cref="IDevice"/>
		/// </summary>
		DeviceIdentity Identity { get; }
	}

	public interface IDevice<TLinked> : IDevice, ILinkable<TLinked> where TLinked : IDevice
	{
		/// <summary>
		/// The <see cref="DeviceIdentity"/> Identity of this
		/// <see cref="IDevice"/><![CDATA[<]]><typeparamref name="TLinked"/><![CDATA[>]]>
		/// </summary>
		new DeviceIdentity Identity { get; }
	}
}
