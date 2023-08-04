using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Security;

namespace MelissaData {
	public class mdGeo : IDisposable {
		private IntPtr i;

		public enum ProgramStatus {
			ErrorNone = 0,
			ErrorOther = 1,
			ErrorOutOfMemory = 2,
			ErrorRequiredFileNotFound = 3,
			ErrorFoundOldFile = 4,
			ErrorDatabaseExpired = 5,
			ErrorLicenseExpired = 6
		}
		public enum AccessType {
			Local = 0,
			Remote = 1
		}
		public enum DiacriticsMode {
			Auto = 0,
			On = 1,
			Off = 2
		}
		public enum StandardizeMode {
			ShortFormat = 0,
			LongFormat = 1,
			AutoFormat = 2
		}
		public enum SuiteParseMode {
			ParseSuite = 0,
			CombineSuite = 1
		}
		public enum AliasPreserveMode {
			ConvertAlias = 0,
			PreserveAlias = 1
		}
		public enum AutoCompletionMode {
			AutoCompleteSingleSuite = 0,
			AutoCompleteRangedSuite = 1,
			AutoCompletePlaceHolderSuite = 2,
			AutoCompleteNoSuite = 3
		}
		public enum ResultCdDescOpt {
			ResultCodeDescriptionLong = 0,
			ResultCodeDescriptionShort = 1
		}
		public enum MailboxLookupMode {
			MailboxNone = 0,
			MailboxExpress = 1,
			MailboxPremium = 2
		}

		[SuppressUnmanagedCodeSecurity]
		private class mdGeoUnmanaged {
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoCreate", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGeoCreate();
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoDestroy", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdGeoDestroy(IntPtr i);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoSetPathToGeoCodeDataFiles", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdGeoSetPathToGeoCodeDataFiles(IntPtr i, string p1);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoSetPathToGeoPointDataFiles", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdGeoSetPathToGeoPointDataFiles(IntPtr i, string p1);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoSetPathToGeoCanadaDataFiles", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdGeoSetPathToGeoCanadaDataFiles(IntPtr i, string p1);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoSetLicenseString", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdGeoSetLicenseString(IntPtr i, string License);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoInitialize", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdGeoInitialize(IntPtr i, string DataPath, string IndexPath);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoInitializeDataFiles", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdGeoInitializeDataFiles(IntPtr i);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoGetInitializeErrorString", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGeoGetInitializeErrorString(IntPtr i);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoGetBuildNumber", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGeoGetBuildNumber(IntPtr i);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoGetDatabaseDate", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGeoGetDatabaseDate(IntPtr i);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoGetExpirationDate", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGeoGetExpirationDate(IntPtr i);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoGetLicenseExpirationDate", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGeoGetLicenseExpirationDate(IntPtr i);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoSetLatitude", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdGeoSetLatitude(IntPtr i, string latitude);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoSetLongitude", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdGeoSetLongitude(IntPtr i, string longitude);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoWriteToLogFile", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdGeoWriteToLogFile(IntPtr i, string logFile);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoGeoCode", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdGeoGeoCode(IntPtr i, string Zip, string Plus4);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoGeoPoint", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdGeoGeoPoint(IntPtr i, string Zip, string Plus4, string DeliveryPointCode);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoComputeDistance", CallingConvention = CallingConvention.Cdecl)]
			public static extern double mdGeoComputeDistance(IntPtr i, double Latitude1, double Longitude1, double Latitude2, double Longitude2);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoComputeBearing", CallingConvention = CallingConvention.Cdecl)]
			public static extern double mdGeoComputeBearing(IntPtr i, double Latitude1, double Longitude1, double Latitude2, double Longitude2);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoGetErrorCode", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGeoGetErrorCode(IntPtr i);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoGetStatusCode", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGeoGetStatusCode(IntPtr i);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoGetResults", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGeoGetResults(IntPtr i);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoGetResultCodeDescription", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGeoGetResultCodeDescription(IntPtr i, string resultCode, Int32 opt);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoGetLatitude", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGeoGetLatitude(IntPtr i);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoGetLongitude", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGeoGetLongitude(IntPtr i);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoGetCensusTract", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGeoGetCensusTract(IntPtr i);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoGetCensusBlock", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGeoGetCensusBlock(IntPtr i);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoGetCountyFips", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGeoGetCountyFips(IntPtr i);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoGetCountyName", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGeoGetCountyName(IntPtr i);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoGetPlaceCode", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGeoGetPlaceCode(IntPtr i);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoGetPlaceName", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGeoGetPlaceName(IntPtr i);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoGetTimeZoneCode", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGeoGetTimeZoneCode(IntPtr i);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoGetTimeZone", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGeoGetTimeZone(IntPtr i);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoGetCBSACode", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGeoGetCBSACode(IntPtr i);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoGetCBSATitle", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGeoGetCBSATitle(IntPtr i);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoGetCBSALevel", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGeoGetCBSALevel(IntPtr i);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoGetCBSADivisionCode", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGeoGetCBSADivisionCode(IntPtr i);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoGetCBSADivisionTitle", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGeoGetCBSADivisionTitle(IntPtr i);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoGetCBSADivisionLevel", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGeoGetCBSADivisionLevel(IntPtr i);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoGetLastUsageLogMessage", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGeoGetLastUsageLogMessage(IntPtr i);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoGetCensusKey", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGeoGetCensusKey(IntPtr i);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoGetCountySubdivisionCode", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGeoGetCountySubdivisionCode(IntPtr i);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoGetCountySubdivisionName", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGeoGetCountySubdivisionName(IntPtr i);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoGetElementarySchoolDistrictCode", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGeoGetElementarySchoolDistrictCode(IntPtr i);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoGetElementarySchoolDistrictName", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGeoGetElementarySchoolDistrictName(IntPtr i);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoGetSecondarySchoolDistrictCode", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGeoGetSecondarySchoolDistrictCode(IntPtr i);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoGetSecondarySchoolDistrictName", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGeoGetSecondarySchoolDistrictName(IntPtr i);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoGetStateDistrictLower", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGeoGetStateDistrictLower(IntPtr i);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoGetStateDistrictUpper", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGeoGetStateDistrictUpper(IntPtr i);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoGetUnifiedSchoolDistrictCode", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGeoGetUnifiedSchoolDistrictCode(IntPtr i);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoGetUnifiedSchoolDistrictName", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGeoGetUnifiedSchoolDistrictName(IntPtr i);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoGetBlockSuffix", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGeoGetBlockSuffix(IntPtr i);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoSetInputParameter", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdGeoSetInputParameter(IntPtr i, string key, string val);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoFindGeo", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdGeoFindGeo(IntPtr i);
			[DllImport("mdGeo.dll", EntryPoint = "mdGeoGetOutputParameter", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGeoGetOutputParameter(IntPtr i, string key);
		}

		public mdGeo() {
			i = mdGeoUnmanaged.mdGeoCreate();
		}

		~mdGeo() {
			Dispose();
		}

		public virtual void Dispose() {
			lock (this) {
				mdGeoUnmanaged.mdGeoDestroy(i);
				GC.SuppressFinalize(this);
			}
		}

		public void SetPathToGeoCodeDataFiles(string p1) {
			mdGeoUnmanaged.mdGeoSetPathToGeoCodeDataFiles(i, p1);
		}

		public void SetPathToGeoPointDataFiles(string p1) {
			mdGeoUnmanaged.mdGeoSetPathToGeoPointDataFiles(i, p1);
		}

		public void SetPathToGeoCanadaDataFiles(string p1) {
			mdGeoUnmanaged.mdGeoSetPathToGeoCanadaDataFiles(i, p1);
		}

		public bool SetLicenseString(string License) {
			return (mdGeoUnmanaged.mdGeoSetLicenseString(i, License) != 0);
		}

		public ProgramStatus Initialize(string DataPath, string IndexPath) {
			return (ProgramStatus)mdGeoUnmanaged.mdGeoInitialize(i, DataPath, IndexPath);
		}

		public ProgramStatus InitializeDataFiles() {
			return (ProgramStatus)mdGeoUnmanaged.mdGeoInitializeDataFiles(i);
		}

		public string GetInitializeErrorString() {
			return Marshal.PtrToStringAnsi(mdGeoUnmanaged.mdGeoGetInitializeErrorString(i));
		}

		public string GetBuildNumber() {
			return Marshal.PtrToStringAnsi(mdGeoUnmanaged.mdGeoGetBuildNumber(i));
		}

		public string GetDatabaseDate() {
			return Marshal.PtrToStringAnsi(mdGeoUnmanaged.mdGeoGetDatabaseDate(i));
		}

		public string GetExpirationDate() {
			return Marshal.PtrToStringAnsi(mdGeoUnmanaged.mdGeoGetExpirationDate(i));
		}

		public string GetLicenseExpirationDate() {
			return Marshal.PtrToStringAnsi(mdGeoUnmanaged.mdGeoGetLicenseExpirationDate(i));
		}

		public void SetLatitude(string latitude) {
			mdGeoUnmanaged.mdGeoSetLatitude(i, latitude);
		}

		public void SetLongitude(string longitude) {
			mdGeoUnmanaged.mdGeoSetLongitude(i, longitude);
		}

		public bool WriteToLogFile(string logFile) {
			return (mdGeoUnmanaged.mdGeoWriteToLogFile(i, logFile) != 0);
		}

		public int GeoCode(string Zip, string Plus4) {
			return mdGeoUnmanaged.mdGeoGeoCode(i, Zip, Plus4);
		}

		public int GeoCode(string Zip) {
			return mdGeoUnmanaged.mdGeoGeoCode(i, Zip, "");
		}

		public int GeoPoint(string Zip, string Plus4, string DeliveryPointCode) {
			return mdGeoUnmanaged.mdGeoGeoPoint(i, Zip, Plus4, DeliveryPointCode);
		}

		public double ComputeDistance(double Latitude1, double Longitude1, double Latitude2, double Longitude2) {
			return mdGeoUnmanaged.mdGeoComputeDistance(i, Latitude1, Longitude1, Latitude2, Longitude2);
		}

		public double ComputeBearing(double Latitude1, double Longitude1, double Latitude2, double Longitude2) {
			return mdGeoUnmanaged.mdGeoComputeBearing(i, Latitude1, Longitude1, Latitude2, Longitude2);
		}

		public string GetErrorCode() {
			return Marshal.PtrToStringAnsi(mdGeoUnmanaged.mdGeoGetErrorCode(i));
		}

		public string GetStatusCode() {
			return Marshal.PtrToStringAnsi(mdGeoUnmanaged.mdGeoGetStatusCode(i));
		}

		public string GetResults() {
			return Marshal.PtrToStringAnsi(mdGeoUnmanaged.mdGeoGetResults(i));
		}

		public string GetResultCodeDescription(string resultCode, ResultCdDescOpt opt) {
			return Marshal.PtrToStringAnsi(mdGeoUnmanaged.mdGeoGetResultCodeDescription(i, resultCode, (int)opt));
		}

		public string GetResultCodeDescription(string resultCode) {
			return Marshal.PtrToStringAnsi(mdGeoUnmanaged.mdGeoGetResultCodeDescription(i, resultCode, (int)ResultCdDescOpt.ResultCodeDescriptionLong));
		}

		public string GetLatitude() {
			return Marshal.PtrToStringAnsi(mdGeoUnmanaged.mdGeoGetLatitude(i));
		}

		public string GetLongitude() {
			return Marshal.PtrToStringAnsi(mdGeoUnmanaged.mdGeoGetLongitude(i));
		}

		public string GetCensusTract() {
			return Marshal.PtrToStringAnsi(mdGeoUnmanaged.mdGeoGetCensusTract(i));
		}

		public string GetCensusBlock() {
			return Marshal.PtrToStringAnsi(mdGeoUnmanaged.mdGeoGetCensusBlock(i));
		}

		public string GetCountyFips() {
			return Marshal.PtrToStringAnsi(mdGeoUnmanaged.mdGeoGetCountyFips(i));
		}

		public string GetCountyName() {
			return Marshal.PtrToStringAnsi(mdGeoUnmanaged.mdGeoGetCountyName(i));
		}

		public string GetPlaceCode() {
			return Marshal.PtrToStringAnsi(mdGeoUnmanaged.mdGeoGetPlaceCode(i));
		}

		public string GetPlaceName() {
			return Marshal.PtrToStringAnsi(mdGeoUnmanaged.mdGeoGetPlaceName(i));
		}

		public string GetTimeZoneCode() {
			return Marshal.PtrToStringAnsi(mdGeoUnmanaged.mdGeoGetTimeZoneCode(i));
		}

		public string GetTimeZone() {
			return Marshal.PtrToStringAnsi(mdGeoUnmanaged.mdGeoGetTimeZone(i));
		}

		public string GetCBSACode() {
			return Marshal.PtrToStringAnsi(mdGeoUnmanaged.mdGeoGetCBSACode(i));
		}

		public string GetCBSATitle() {
			return Marshal.PtrToStringAnsi(mdGeoUnmanaged.mdGeoGetCBSATitle(i));
		}

		public string GetCBSALevel() {
			return Marshal.PtrToStringAnsi(mdGeoUnmanaged.mdGeoGetCBSALevel(i));
		}

		public string GetCBSADivisionCode() {
			return Marshal.PtrToStringAnsi(mdGeoUnmanaged.mdGeoGetCBSADivisionCode(i));
		}

		public string GetCBSADivisionTitle() {
			return Marshal.PtrToStringAnsi(mdGeoUnmanaged.mdGeoGetCBSADivisionTitle(i));
		}

		public string GetCBSADivisionLevel() {
			return Marshal.PtrToStringAnsi(mdGeoUnmanaged.mdGeoGetCBSADivisionLevel(i));
		}

		public string GetLastUsageLogMessage() {
			return Marshal.PtrToStringAnsi(mdGeoUnmanaged.mdGeoGetLastUsageLogMessage(i));
		}

		public string GetCensusKey() {
			return Marshal.PtrToStringAnsi(mdGeoUnmanaged.mdGeoGetCensusKey(i));
		}

		public string GetCountySubdivisionCode() {
			return Marshal.PtrToStringAnsi(mdGeoUnmanaged.mdGeoGetCountySubdivisionCode(i));
		}

		public string GetCountySubdivisionName() {
			return Marshal.PtrToStringAnsi(mdGeoUnmanaged.mdGeoGetCountySubdivisionName(i));
		}

		public string GetElementarySchoolDistrictCode() {
			return Marshal.PtrToStringAnsi(mdGeoUnmanaged.mdGeoGetElementarySchoolDistrictCode(i));
		}

		public string GetElementarySchoolDistrictName() {
			return Marshal.PtrToStringAnsi(mdGeoUnmanaged.mdGeoGetElementarySchoolDistrictName(i));
		}

		public string GetSecondarySchoolDistrictCode() {
			return Marshal.PtrToStringAnsi(mdGeoUnmanaged.mdGeoGetSecondarySchoolDistrictCode(i));
		}

		public string GetSecondarySchoolDistrictName() {
			return Marshal.PtrToStringAnsi(mdGeoUnmanaged.mdGeoGetSecondarySchoolDistrictName(i));
		}

		public string GetStateDistrictLower() {
			return Marshal.PtrToStringAnsi(mdGeoUnmanaged.mdGeoGetStateDistrictLower(i));
		}

		public string GetStateDistrictUpper() {
			return Marshal.PtrToStringAnsi(mdGeoUnmanaged.mdGeoGetStateDistrictUpper(i));
		}

		public string GetUnifiedSchoolDistrictCode() {
			return Marshal.PtrToStringAnsi(mdGeoUnmanaged.mdGeoGetUnifiedSchoolDistrictCode(i));
		}

		public string GetUnifiedSchoolDistrictName() {
			return Marshal.PtrToStringAnsi(mdGeoUnmanaged.mdGeoGetUnifiedSchoolDistrictName(i));
		}

		public string GetBlockSuffix() {
			return Marshal.PtrToStringAnsi(mdGeoUnmanaged.mdGeoGetBlockSuffix(i));
		}

		public bool SetInputParameter(string key, string val) {
			return (mdGeoUnmanaged.mdGeoSetInputParameter(i, key, val) != 0);
		}

		public void FindGeo() {
			mdGeoUnmanaged.mdGeoFindGeo(i);
		}

		public string GetOutputParameter(string key) {
			return Marshal.PtrToStringAnsi(mdGeoUnmanaged.mdGeoGetOutputParameter(i, key));
		}

		private class Utf8String : IDisposable {
			private IntPtr utf8String = IntPtr.Zero;

			public Utf8String(string str) {
				if (str == null)
					str = "";
				byte[] buffer = Encoding.UTF8.GetBytes(str);
				Array.Resize(ref buffer, buffer.Length + 1);
				buffer[buffer.Length - 1] = 0;
				utf8String = Marshal.AllocHGlobal(buffer.Length);
				Marshal.Copy(buffer, 0, utf8String, buffer.Length);
			}

			~Utf8String() {
				Dispose();
			}

			public virtual void Dispose() {
				lock (this) {
					Marshal.FreeHGlobal(utf8String);
					GC.SuppressFinalize(this);
				}
			}

			public IntPtr GetUtf8Ptr() {
				return utf8String;
			}

			public static string GetUnicodeString(IntPtr ptr) {
				if (ptr == IntPtr.Zero)
					return "";
				int len = 0;
				while (Marshal.ReadByte(ptr, len) != 0)
					len++;
				if (len == 0)
					return "";
				byte[] buffer = new byte[len];
				Marshal.Copy(ptr, buffer, 0, len);
				return Encoding.UTF8.GetString(buffer);
			}
		}
	}
}
