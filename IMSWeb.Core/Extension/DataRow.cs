using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace System.Data
{
    public static class DataRowExtension
    {
        #region Public Static Methods

        public static bool GetBoolean(this DataRow source, string column)
        {
            if (source.IsNull(column))
            {
                return false;
            }

            return source.Field<Boolean>(column);
        }

        public static DateTime GetDateTime(this DataRow source, string column)
        {
            if (source.IsNull(column))
            {
                return DateTime.MinValue;
            }

            return source.Field<DateTime>(column);
        }

        public static Guid GetGuid(this DataRow source, string column)
        {
            if (source.IsNull(column))
            {
                return Guid.Empty;
            }

            return source.Field<Guid>(column);
        }

        public static int GetInt(this DataRow source, string column)
        {
            if (source.IsNull(column))
            {
                return 0;
            }

            return source.Field<int>(column);
        }

        public static string GetString(this DataRow source, string column)
        {
            if (source.IsNull(column))
            {
                return String.Empty;
            }

            return source.Field<String>(column);
        }

        #endregion  // Public Static Methods
    }
}
