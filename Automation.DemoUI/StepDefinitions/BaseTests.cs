using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using Automation.Framework.Core.WebUI.Utilities;
using Automation.Framework.Core.WebUI.Abstractions;

namespace Automation.DemoUI.Steps
{
    public class BaseTests 
    {

        //public static ThreadLocal<SoftAssertions> SoftAssertionsThread = new ThreadLocal<SoftAssertions>();

        
        public static string AccountingEntryId;        
        public static double OnsAgainstGram = 1 / 31.259768; // Adjusted value
        public static string StateMakerAdmin, TraderValue, StateMakerUser, StateMaker;

        // Dates
        //public static LocalDateTime CurrentDate;
        //public static LocalDateTime StateDateDashboard;

        // DateTime Formatter
        //public DateTimeFormatter FormatterStateDate = new DateTimeFormatter("dd.MM.yyyy hh:mm a", CultureInfo.InvariantCulture);

        // Selenium Actions and JavaScript Executor
        public Actions Action;
        public IJavaScriptExecutor JsExecutor;

        // Faker
        public Faker Faker = new Faker();
      
        public NumberFormatInfo NumberFormatInfo = new CultureInfo("en-US", false).NumberFormat;
        public string DecimalFormat(double number) => number.ToString("#,##0.000000", NumberFormatInfo);
        public string DecimalFormatZeroDigit(double number) => number.ToString("#,##0", NumberFormatInfo);
        public string DecimalFormatOneDigit(double number) => number.ToString("#,##0.0", NumberFormatInfo);
        public string DecimalFormatTwoDigit(double number) => number.ToString("#,##0.00", NumberFormatInfo);
        public string DecimalFormatThreeDigit(double number) => number.ToString("#,##0.000", NumberFormatInfo);
        public string DecimalFormatFourDigit(double number) => number.ToString("#,##0.0000", NumberFormatInfo);
        public string DecimalFormatFiveDigit(double number) => number.ToString("#,##0.00000", NumberFormatInfo);
        public string DecimalFormatSixDigit(double number) => number.ToString("#,##0.000000", NumberFormatInfo);
        public string DecimalFormatEightDigit(double number) => number.ToString("#,##0.00000000", NumberFormatInfo);        
        public Random Random = new Random();

        
    }
}
