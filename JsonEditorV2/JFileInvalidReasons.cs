using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonEditor
{
    public enum JFileInvalidReasons
    {   
        None = 0,
        //Scan
        RootElementNotArray,
        ChildElementNotObject,
        ChildColumnTypeVary,
        //Strict
        ChildColumnCountVary,
        ChildColumnNameVary,
        ChildColumnOrderVary
    }
}
