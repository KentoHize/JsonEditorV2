using System;

namespace JsonEditor
{
    public class JFileInvalidException : Exception
    {
        public JFileInvalidReasons Reason { get; set; }
        public int LineIndex { get; set; }
        public string ColumnName { get; set; }

        public JFileInvalidException(JFileInvalidReasons reason, int lineIndex = -1, string columnName = "")
        {
            Reason = reason;
            LineIndex = lineIndex;
            ColumnName = columnName;
        }
    }
}
