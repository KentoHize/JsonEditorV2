using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using JsonEditor;
using Newtonsoft.Json.Linq;
using Aritiafel.Organizations.RaeriharUniversity;
using System.Globalization;

namespace JsonEditorV2
{
    public static class Methods
    {
        public class Product
        {
            public string Name { get; set; }
            public int Price { get; set; }
            public int Quantity { get; set; }
            public string Quantifier { get; set; }
            public string Note { get; set; }
        }

        public const string InvoiceConfirmed = "開立已確認";
        public const string InvoiceDateTimeFormat = "yyyy-MM-ddHH:mm:ss";

        public const string PizzaHutIgnoreString = "===以下為備註===";
        public const string ArinaLimitedCorp = "有奈有限公司";

        public static void ElectronicInvoicesToAccountBook(string fileName = "Result.json")
        {
            StreamWriter sw = new StreamWriter(Path.Combine(Var.JFI.DirectoryPath, fileName));
            JArray jArray = new JArray();

            bool use = false;
            string InvoiceNumber = ""; //發票號碼
            ArDateTime InvoiceDateTime = default; //發票日期時間
            string CustomerBusinessIDNumber = ""; //買方統一編號
            string CustomerName = ""; //買方名稱
            string SellerBusinessIDNumber = ""; //賣方統一編號
            string SellerName = ""; //賣方名稱
            int SellingPrice = default; //銷售額
            int Tax = default; //稅額
            string Note = ""; //備註
            ArDateTime InvoiceConfirmDateTime = default; //開立日期時間
            List<Product> products = null;//商品列表

            for (int i = 0; i < Var.Database.Tables.Count; i++)
            {
                if (!Var.Database.Tables[i].Loaded)
                    MainForm.LoadOrScanJsonFile(Var.Database.Tables[i]);
                if (Var.Database.Tables[i].Name == "Result")
                    continue;
                for(int j = 1; j < Var.Database.Tables[i].Count + 1; j++)
                {   
                    if (j == Var.Database.Tables[i].Count || Var.Database.Tables[i].Lines[j][0].ToString() == "M")
                    {
                        if(products != null || j == Var.Database.Tables[i].Count)
                        {
                            JObject jObject = new JObject
                            {
                                { "InvoiceNumber", InvoiceNumber },
                                { "InvoiceDateTime", InvoiceDateTime.ToStandardString(Aritiafel.Organizations.ArinaOrganization.ArStandardDateTimeType.ShortDateTime) },
                                { "CustomerBusinessIDNumber", CustomerBusinessIDNumber },
                                { "CustomerName", CustomerName },
                                { "SellerBusinessIDNumber", SellerBusinessIDNumber },
                                { "SellerName", SellerName },
                                { "SellingPrice", SellingPrice },
                                { "Tax", Tax },
                                { "InvoiceConfirmDateTime", InvoiceConfirmDateTime.ToStandardString(Aritiafel.Organizations.ArinaOrganization.ArStandardDateTimeType.ShortDateTime) },
                                { "Note", Note }
                            };
                            JArray jArrayProducts = new JArray();
                            foreach (var product in products)
                            {
                                JObject jProduct = new JObject
                                {
                                    { "Name", product.Name },
                                    { "Price", product.Price },
                                    { "Quantity", product.Quantity },
                                    { "Quantifier", product.Quantifier },
                                    { "Note", product.Note }
                                };
                                jArrayProducts.Add(jProduct);
                            }
                            jObject.Add("Products", jArrayProducts);
                            jArray.Add(jObject);

                            if(j == Var.Database.Tables[i].Count)
                                break;
                        }

                        if (Var.Database.Tables[i].Lines[j][4].ToString() == InvoiceConfirmed)
                        {   
                            InvoiceNumber = Var.Database.Tables[i].Lines[j][1].ToString();
                            ArDateTime.TryParseExact(Var.Database.Tables[i].Lines[j][5].ToString(), InvoiceDateTimeFormat, CultureInfo.CurrentCulture, out InvoiceDateTime);
                            CustomerBusinessIDNumber = Var.Database.Tables[i].Lines[j][6].ToString();
                            CustomerName = ArinaLimitedCorp;// Var.Database.Tables[i].Lines[j][7].ToString();
                            SellerBusinessIDNumber = Var.Database.Tables[i].Lines[j][8].ToString();
                            SellerName = Var.Database.Tables[i].Lines[j][9].ToString();
                            SellingPrice = int.Parse(Var.Database.Tables[i].Lines[j][12].ToString());
                            Tax = int.Parse(Var.Database.Tables[i].Lines[j][15].ToString());
                            ArDateTime.TryParseExact(Var.Database.Tables[i].Lines[j][23].ToString(), InvoiceDateTimeFormat, CultureInfo.CurrentCulture, out InvoiceConfirmDateTime);
                            Note = Var.Database.Tables[i].Lines[j][22].ToString();
                            products = new List<Product>();
                            use = true;
                        }
                        else
                            use = false;
                    }
                    else
                    {
                        if (Var.Database.Tables[i].Lines[j][4].ToString() == PizzaHutIgnoreString)
                            use = false;
                        if (!use)
                            continue;
                        Product p = new Product
                        {
                            Name = Var.Database.Tables[i].Lines[j][4].ToString(),
                            Quantity = (int)double.Parse(Var.Database.Tables[i].Lines[j][5].ToString()),
                            Quantifier = Var.Database.Tables[i].Lines[j][6].ToString(),
                            Price = (int)double.Parse(Var.Database.Tables[i].Lines[j][7].ToString()),
                            Note = Var.Database.Tables[i].Lines[j][9].ToString()
                        };
                        products.Add(p);
                    }
                }
            }
            sw.WriteLine(JsonConvert.SerializeObject(new JArray(jArray.OrderBy(m => m["InvoiceDateTime"])), Formatting.Indented));
            sw.Close();
        }
    }
}
