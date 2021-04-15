using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BatterUp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var level = Battery.ChargeLevel; // returns 0.0 to 1.0 or 1.0 when on AC or no battery.

            var state = Battery.State;
            batteryState.Text = state.ToString();
            
            var source = Battery.PowerSource;
            powerSource.Text = source.ToString();

            var chargeLevel = Battery.ChargeLevel * 100;
            this.chargeLevel.Text = chargeLevel.ToString() + "%";
            
            var status = Battery.EnergySaverStatus;
            enSavStatus.Text=status.ToString();
            
            Battery.BatteryInfoChanged += Battery_BatteryInfoChanged;
            Battery.EnergySaverStatusChanged += OnEnergySaverStatusChanged;

        }
        
        void Battery_BatteryInfoChanged(object sender, BatteryInfoChangedEventArgs   e)
            {
                var level = e.ChargeLevel;
                chargeLevel.Text=level*100 + "%";
                var state = e.State;
                batteryState.Text=state.ToString();
                var source = e.PowerSource;
                powerSource.Text=source.ToString();
            }
            
            private void OnEnergySaverStatusChanged(object sender, EnergySaverStatusChangedEventArgs e)
                {
                    // Process change
                    var status = e.EnergySaverStatus;
                    enSavStatus.Text=status.ToString();
                }
    }
}
