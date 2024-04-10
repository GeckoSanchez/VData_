namespace VData02
{
	using System.Text;
	using Kinds;
	using Newtonsoft.Json;

	public class Def
	{
		public const string Name = "_DefaultName_";
		public const string Value = "";
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
		public static string CurrentHistoryDir => $"{CurrentDir}/History";

		public static BlockKind BlockKind => BlockKind.Constructor;
		public static DataKind DataKind => DataKind.None;
		public static DeviceKind DeviceKind => DeviceKind.None;
		public static LogKind LogKind => LogKind.Event;
		public static LinkKind LinkKind => LinkKind.None;
		public static ExceptKind ExceptKind => ExceptKind.Base;
		public static ObjectKind ObjectKind => ObjectKind.None;
		public static PageKind PageKind => PageKind.Home;
		public static PlatformKind PlatformKind => PlatformKind.PC;

		public static Encoding Encoding => Encoding.Default;

		public static string ExceptionMessage => $"{new Exception()}";

		public static string JSON => "{}";
		public static Formatting JSONFormatting => Formatting.Indented;
		public static Exception JSONException => new("This data could not be serialized into the JSON format");

		public static readonly int MinNameLength = 1;
		public static readonly int MaxNameLength = 80;
		public static readonly string GoodNameChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789_.-+=";

		public const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!\"#$%&'()*+,-./:;<=>?@[]^_`{|}~";
	}

	public static class Def<T> where T : notnull
	{
		public static readonly T Value = default!;
		public static readonly T? NValue = default;
	}
}
