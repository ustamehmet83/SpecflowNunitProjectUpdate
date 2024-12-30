namespace Automation.Framework.Core.WebUI.Abstractions
{
    public interface IExtentReport
    {
        void CreateFeature(string featureName);
        void CreateScenario(string scenario);
        void Pass(string msg, string base64);
        void Fail(string msg, string base64);
        void Warning(string msg, string base64);
        void Error(string msg, string base64);
    }
}
