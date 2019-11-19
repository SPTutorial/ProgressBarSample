using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProgressBarSample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProgressBarPopup : PopupPage
    {
        float maxValue = 1;
        float progressmax = 10;
        bool istimerRunning = true;
        float progress = 0;
        int counter = 1;
        public ProgressBarPopup()
        {
            InitializeComponent();

            Device.StartTimer(TimeSpan.FromSeconds(2), () =>
             {
                 if (progress >= 1)
                 {
                     istimerRunning = false;
                     Navigation.PopPopupAsync();
                 }
                 else
                 {
                     progress += maxValue / progressmax;
                     progressbar.ProgressTo(progress, 500, Easing.Linear);
                     progressLabel.Text = $"{counter}/{progressmax}";
                     counter += 1;
                 }

                 return istimerRunning;
             });
        }
    }
}