using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonEditorV2
{
    public enum JFileInvalidReasons
    {   
        None = 0,
        //Scan
        RootElementNotArray,
        FirstChildElementNotObject,
        //Load
        ChildColumnCountVary,
        ChildColumnNameVary
    }
}
