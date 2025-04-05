using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JsonEditor;

namespace JsonEditorV2Tests
{
	/// <summary>
	/// UnitTest 的摘要說明
	/// </summary>
	[TestClass]
	public class UnitTest
	{
		public UnitTest()
		{
			//
			// TODO: 在此加入建構函式的程式碼
			//
		}

		private TestContext testContextInstance;

		/// <summary>
		///取得或設定提供目前測試回合
		///相關資訊與功能的測試內容。
		///</summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
		}



        #region 其他測試屬性
        //
        // 您可以使用下列其他屬性撰寫測試: 
        //
        // 執行該類別中第一項測試前，使用 ClassInitialize 執行程式碼
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在類別中的所有測試執行後，使用 ClassCleanup 執行程式碼
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 在執行每一項測試之前，先使用 TestInitialize 執行程式碼 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // 在執行每一項測試之後，使用 TestCleanup 執行程式碼
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void DateTimeTest()
        {
            DateTime dt = new DateTime();
            dt.AddTicks(2000);
            TestContext.WriteLine(dt.ToString("d"));
            TestContext.WriteLine(dt.ToString("%d"));
            TestContext.WriteLine(dt.ToString("dd"));
            TestContext.WriteLine(dt.ToString(""));
            TestContext.WriteLine(dt.ToString("G"));

        }

        [TestMethod]
		public void JDateTimeTest()
		{
			JDateTime JDT = new JDateTime();
			//JDT.
			//long tick = 0;
            List<long> testTicks = new List<long>{ -36000000000L, -600000000L, -10000000L, -1000, -1 };

            testTicks.Add(0);

            for (int i = testTicks.Count - 1; i >= 0; i--)
                testTicks.Add(-testTicks[i]);
            
            //JDateTime Minus1Tick = new JDateTime(-1);
            //         JDateTime Zero = new JDateTime(0);
            //         JDateTime OneTick = new JDateTime(1);
            //         JDateTime OneSecond = new JDateTime(1000000);
            //         JDateTime OneMinute = new JDateTime(60000000);
            //         JDateTime OneHour = new JDateTime(360000000);
            for(int i = 0;  i < testTicks.Count; i++)
            {
                GetTickString(testTicks[i]);
            }
            
            ////TestContext.WriteLine(GetTickString(-36000000000L));
            ////TestContext.WriteLine(GetTickString(-600000000L));
            ////TestContext.WriteLine(GetTickString(-10000000L));
            ////TestContext.WriteLine(GetTickString(-1000));
            ////TestContext.WriteLine(GetTickString(-1));
            //TestContext.WriteLine(GetTickString(0));
            //TestContext.WriteLine(GetTickString(1));
            //TestContext.WriteLine(GetTickString(1000));
            //TestContext.WriteLine(GetTickString(10000000L));
            //TestContext.WriteLine(GetTickString(600000000L));
            //TestContext.WriteLine(GetTickString(36000000000L));

            //TestContext.WriteLine(GetTickString(36000000000L, "d"));
            //TestContext.WriteLine(GetTickString(-36000000000L, "d"));



            //
            // TODO:  在此加入測試邏輯
            //
        }

		internal void GetTickString(long ticks, string format = "")
		{
            if (string.IsNullOrEmpty(format))
                format = "";
            //TestContext.WriteLine($"{ticks} Tick(s)[{format}]:{new JDateTime(ticks).ToString(format)}");
            //TestContext.WriteLine($"{ticks} Tick(s)[LongDate]:{new JDateTime(ticks).ToLongDateString()}");
            //TestContext.WriteLine($"{ticks} Tick(s)[ShortDate]:{new JDateTime(ticks).ToShortDateString()}");
            //TestContext.WriteLine($"{ticks} Tick(s)[LongTime]:{new JDateTime(ticks).ToLongTimeString()}");
            //TestContext.WriteLine($"{ticks} Tick(s)[ShortTime]:{new JDateTime(ticks).ToShortTimeString()}");
            TestContext.WriteLine($"{ticks} Tick(s)[Year]:{new JDateTime(ticks).Year}");

            //return $"{ticks} Tick(s)[{format}]:{new JDateTime(ticks).ToString(format)}";
        }
	}
}
