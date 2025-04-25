using Aritiafel.Characters.Heroes;
using Aritiafel.Items;
using Aritiafel.Locations;
using Aritiafel.Organizations.RaeriharUniversity;
using Aritiafel.Organizations.ArinaOrganization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace JsonEditor
{
    internal class JFunc
    {
        public string Name { get; set; }
        public string[] Args { get; set; }
    }

    public static class JFunction
    {

        public static bool TryParseString(string s, out ArOutPartInfoList result)
        {
            DisassembleShop ds = new DisassembleShop();
            ArDisassembleInfo di = new ArDisassembleInfo();
            di.ReservedStringInfo = [[ new ArStringPartInfo("{{", "{", Aritiafel.Definitions.ArStringPartType.Escape1),
                new ArStringPartInfo("}}", "}", Aritiafel.Definitions.ArStringPartType.Escape1)],
                [new ArStringPartInfo("NOW"), new ArStringPartInfo("COUNT"), new ArStringPartInfo("GUID") ],
                [new ArStringPartInfo(","), new ArStringPartInfo(" ")],
                [new ArStringPartInfo("\\", "\\", Aritiafel.Definitions.ArStringPartType.Escape1)]
                ];
            di.ContainerPartInfo = [new ArContainerPartInfo("curly brackets", "{", "}", 1),
                new ArContainerPartInfo("brackets", "(", ")", 2),
                new ArContainerPartInfo("single quotation marks", "'", "'", 3)];

            ArOutPartInfoList opil;
            try
            {
                opil = ds.Disassemble(s, di);
                result = opil;
            }
            catch (Exception e)
            {
                result = default;
                return false;
            }
            return true;
        }

        //Now() =>回傳系統時間
        //NOW('D') => 回傳系統日期
        //NOW('T') => 回傳系統時間
        //List<JFunc>

        //internal static string 
        //改為可以傳入值
        public static string ParseFunction(string s, bool systemFormat, params object[] args)
        {
            TryParseString(s, out ArOutPartInfoList opil);
            StringBuilder sb2 = new StringBuilder();
            List<string> functionName = new List<string>();
            List<List<string>> argsList = new List<List<string>>();
            for (int i = 0; i < opil.Value.Count; i++)
            {
                int index = 0;
                if (opil.Value[i] is ArOutPartInfoList opil2 && opil2.StartString == "{" && opil2.EndString == "}") //{}
                {                    
                    for (int j = 0; j < opil2.Value.Count; j++)
                    {
                        if (opil2.Value[j] is ArOutStringPartInfo ospi)
                        {
                            functionName.Add(ospi.Value);
                            argsList.Add(new List<string>());
                            index = argsList.Count - 1;
                        }
                        else if (opil2.Value[j] is ArOutPartInfoList opil3) //()
                        {
                            int index2 = 0;
                            for (int k = 0; k < opil3.Value.Count; k++)
                            {
                                if (opil3.Value[k] is ArOutStringPartInfo ospi2)
                                {
                                    if (ospi2.Value == ",")
                                    {
                                        if (argsList[index].Count < index2)
                                            argsList[index].Add(null);
                                        index2++;
                                    }
                                    else
                                        argsList[index].Add(ospi2.Value);
                                }
                                else if (opil3.Value[k] is ArOutPartInfoList opil4)
                                {
                                    StringBuilder sb = new StringBuilder();
                                    for (int l = 0; l < opil4.Value.Count; l++)
                                        sb.Append(((ArOutStringPartInfo)opil4.Value[l]).Value);
                                    argsList[index].Add(sb.ToString());
                                }
                            }
                        }
                    }

                    //
                    
                    switch (functionName[index]) //大概
                    {
                        case "NOW":
                            if (argsList[index].Count == 0)
                                sb2.Append(NowF("", "", systemFormat));
                            else if (argsList[index].Count == 1)
                                sb2.Append(NowF(argsList[index][0], "", systemFormat));
                            else
                                sb2.Append(NowF(argsList[index][0], argsList[index][1], systemFormat));
                            break;
                        case "COUNT":
                            sb2.Append(CountF((int)args[0]));
                            break;
                        case "GUID":
                            sb2.Append(GuidF());
                            break;
                        default:
                            throw new KeyNotFoundException(functionName[index]);
                    }
                }
                else if (opil.Value[i] is ArOutStringPartInfo ospi3)
                {
                    //字串                
                    sb2.Append(ospi3.Value);
                }
            }
            Sophia.SeeThrough(sb2);
            return sb2.ToString();

            //NOW
            //if (systemFormat)
            //{
            //    s = s.Replace("{NOW()}", ArDateTime.Now.ToString("a"));
            //    s = s.Replace("{NOW('D')}", ArDateTime.Now.ToString("B"));
            //    s = s.Replace("{NOW('T')}", ArDateTime.Now.ToString("C"));
            //}
            //else
            //{
            //    s = s.Replace("{NOW()}", ArDateTime.Now.ToString());
            //    s = s.Replace("{NOW('D')}", ArDateTime.Now.ToString("D"));
            //    s = s.Replace("{NOW('T')}", ArDateTime.Now.ToString("T"));
            //}
        }

        internal static string NowF(string format = "", string cultureInfoName = "", bool systemFormat = false)
        {
            if (string.IsNullOrEmpty(format))
                format = "G";
            if(systemFormat)
            { 
                if(format == "G")
                    format = "a";
                else if (format == "D")
                    format = "B";
                else if (format == "T")
                    format = "C";
            }
            if (string.IsNullOrEmpty(cultureInfoName))
                cultureInfoName = Mylar.ArinaCulture.Name;
            return ArDateTime.Now.ToString(format, ArCultureInfo.GetCultureInfo(cultureInfoName));
        }

        internal static string CountF(int count)
        {
            return count.ToString();
        }

        internal static string GuidF()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
