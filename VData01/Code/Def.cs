namespace VData01
{
	using System.Text;
	using Kinds;
	using Newtonsoft.Json;

	public static class Def
	{
		public const string Name = "[DefaultName]";
		public static readonly string Value = "";
		public const string AppName = "APPLICATION_NAME";

		public static string MainDir => $"Storage/{AppName}";
		public static string DevicesDir => $"{MainDir}/Devices";
		public static string ObjectsDir => $"{MainDir}/Objects";
		public static string LogsDir => $"{MainDir}/Logs";
		public static string HistoryDir => $"{MainDir}/History";

		public static string BackupsDir => $"{MainDir}/Backups";
		public static string BackupDevicesDir => $"{BackupsDir}/Devices";
		public static string BackupObjectsDir => $"{BackupsDir}/Objects";
		public static string BackupLogsDir => $"{BackupsDir}/Logs";
		public static string BackupHistoryDir => $"{BackupsDir}/History";

		public static string CurrentDir => $"{MainDir}/Current";
		public static string CurrentDevicesDir => $"{CurrentDir}/Devices";
		public static string CurrentObjectsDir => $"{CurrentDir}/Objects";
		public static string CurrentLogsDir => $"{CurrentDir}/Logs";

		public static BlockKind BlockKind => BlockKind.Constructor;
		public static DataKind DataKind => DataKind.None;
		public static DeviceKind DeviceKind => DeviceKind.None;
		public static LogKind LogKind => LogKind.Event;
		public static LinkKind LinkKind => LinkKind.None;
		public static ExceptKind ExceptKind => ExceptKind.Base;
		public static ObjectKind ObjectKind => ObjectKind.None;
		public static PageKind PageKind => PageKind.Home;
		public static PlatformKind PlatformKind => PlatformKind.PC;

		public static readonly Encoding Encoding = Encoding.Default;

		public static readonly string ExceptionMessage = new Exception().Message;

		public const string JSON = "{}";
		public static Formatting JSONFormatting => Formatting.Indented;

		public static Exception JSONException => new("This data could not be serialized into the JSON format");

		public static Dictionary<Type, byte> KindIDs => new()
		{
			{ typeof(BlockKind), 1 },
			{ typeof(DeviceKind), 2 },
			{ typeof(ExceptKind), 3 },
			{ typeof(LinkKind), 4 },
			{ typeof(LogKind), 5 },
			{ typeof(Months), 6 },
			{ typeof(ObjectKind), 7 },
			{ typeof(PageKind), 8 },
			{ typeof(PlatformKind), 9 },
			{ typeof(RegexCategory), 10 },
			{ typeof(UserKind), 11 },
		};

		public static byte[] MACAdress => [0, 0, 0, 0, 0, 0];
		public static byte[] IPArray => System.Net.IPAddress.IPv6Any.GetAddressBytes();

		public const int MinNameLength = 1;
		public const int MaxNameLength = 100;
	}

	public static class Def<T> where T : notnull
	{
		public static readonly T Value = default!;
		public static readonly T? NValue = default;
	}
}
