namespace VData01.Actions
{
	using System.Diagnostics;
	using Bases;
	using Exceptions;
	using Kinds;

	public static class Check
	{
		internal static bool Kind(Enum kind)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out = false;

			try
			{
				Out = kind.GetType() != typeof(DataKind) && kind.GetType() != typeof(DeviceKind) &&
							kind.GetType() != typeof(LinkKind) && kind.GetType() != typeof(ObjectKind) &&
							kind.GetType() != typeof(PageKind) && kind.GetType() != typeof(PlatformKind);
			}
			catch (Exception ex)
			{
				Log.Exception(new ActionException(ex, sf));
			}

			return Out;
		}

		internal static bool Kind(BaseType kind)
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out = false;

			try
			{
				Out = kind.Data.GetType() != typeof(DataKind) && kind.Data.GetType() != typeof(DeviceKind) &&
							kind.Data.GetType() != typeof(LinkKind) && kind.Data.GetType() != typeof(ObjectKind) &&
							kind.Data.GetType() != typeof(PageKind) && kind.Data.GetType() != typeof(PlatformKind);
			}
			catch (Exception ex)
			{
				Log.Exception(new ActionException(ex, sf));
			}

			return Out;
		}

		internal static bool Kind<TKind>(BaseType<TKind> kind) where TKind : struct, Enum
		{
			var sf = new StackFrame(true);
			Log.Event(sf);

			bool Out = false;

			try
			{
				Out = kind.Data.GetType() != typeof(DataKind) && kind.Data.GetType() != typeof(DeviceKind) &&
							kind.Data.GetType() != typeof(LinkKind) && kind.Data.GetType() != typeof(ObjectKind) &&
							kind.Data.GetType() != typeof(PageKind) && kind.Data.GetType() != typeof(PlatformKind);
			}
			catch (Exception ex)
			{
				Log.Exception(new ActionException(ex, sf));
			}

			return Out;
		}
	}
}
