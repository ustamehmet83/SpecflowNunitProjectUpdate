using Bogus;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Automation.WebUI.StepDefinitions
{
    public class BaseTests
    {

        // Selenium Actions and JavaScript Executor
        public Actions Action;
        public IJavaScriptExecutor JsExecutor;
        // Faker
        public Faker Faker = new Faker();
        public Random Random = new Random();


    }
}
