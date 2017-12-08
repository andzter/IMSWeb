using System.Text;

namespace System
{
    public static class StringExtension
    {
        #region Public Static Methods

        public static string DefaultValue(this String source, string @default)
        {
            if (String.IsNullOrEmpty(source))
            {
                return @default;
            }

            return source;
        }

        public static byte[] ToByteArray(this String source)
        {
            var encoding = new UTF8Encoding();

            return encoding.GetBytes(source);
        }

        public static double GetSafeDbl(this String source)
        {
            double d;
            if (source == null)
                return 0;
            Double.TryParse(source, out d);
            return d;
        }

        public static Boolean IsNumeric(this String source)
        {
            try
            {
                Double d = Double.Parse(source);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string NumericStringVal(this String source)
        {
            if (IsNumeric(source)) return source;
            return "0";
        }


        public static int GetSafeInt(this String source)
        {
            int d;
            if ((String.IsNullOrEmpty(source)))
                return 0;
            int.TryParse(source, out d);
            return d;
        }

        public static DateTime? GetSafeDate(this String source)
        {
            try
            {
                DateTime d = DateTime.Now;
                if ((String.IsNullOrEmpty(source)))
                    return null;
                DateTime.TryParse(source, out d);
                return d;
            }
            catch
            {
                return null;
            }
        }


        public static string GetSafeString(this String source)
        {
            if ((String.IsNullOrEmpty(source)))
                return string.Empty;
            return source;
        }


        #endregion  // Public Static Methods
    }
}
