using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System.Globalization;
using Bogus;

namespace Automation.DemoUI.Steps
{
    public class BaseTests 
    {

        //public static ThreadLocal<SoftAssertions> SoftAssertionsThread = new ThreadLocal<SoftAssertions>();

        
        public static string AccountingEntryId;        
        public static double OnsAgainstGram = 1 / 31.259768; // Adjusted value
        public static string StateMakerAdmin, TraderValue, StateMakerUser, StateMaker;

       
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
