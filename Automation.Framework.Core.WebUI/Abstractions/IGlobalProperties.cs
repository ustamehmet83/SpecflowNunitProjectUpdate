namespace Automation.Framework.Core.WebUI.Abstractions
{
    public interface IGlobalProperties
    {
        void Configuration();
        public string datasetlocation { get; set; }
        public string downloadedlocation { get; set; }
        public string browsertype { get; }

        bool stepscreenshot { get; }
    }
}
