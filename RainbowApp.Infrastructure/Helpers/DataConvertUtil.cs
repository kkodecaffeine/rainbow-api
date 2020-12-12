namespace RainbowApp.Core.Helpers
{
    public static class DataConvertUtil
    {
        public static string FixNull(this object oValue, string strDefValue)
        {
            return (oValue != null) ? FixNull(oValue.ToString(), strDefValue) : strDefValue;
        }

        public static string FixNull(this string strValue, string strDefValue)
        {
            return ((strValue == null) || (strValue != null && strValue.Trim().Length < 1)) ? strDefValue.Trim() : strValue.Trim();
        }
        public static string FixNull(this object oValue)
        {
            return FixNull(oValue, string.Empty);
        }
    }
}