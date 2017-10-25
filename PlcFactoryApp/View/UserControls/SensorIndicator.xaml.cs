using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PlcFactoryApp.ViewModel.UserControls;

namespace PlcFactoryApp.View.UserControls
{
    /// <summary>
    /// Interaction logic for SensorIndicator.xaml
    /// </summary>
    public partial class SensorIndicator : UserControl
    {
        public SensorIndicator()
        {
            InitializeComponent();
        }

        public SensorState SensorState
        {
            get { return (SensorState)GetValue(SensorStateProperty); }
            set { SetValue(SensorStateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SensorStateProperty =
            DependencyProperty.Register("SensorState", typeof(SensorState), typeof(SensorIndicator), new PropertyMetadata(SensorState.Deactivated));



        public String SensorName
        {
            get { return (String)GetValue(SensorNameProperty); }
            set { SetValue(SensorNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SensorName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SensorNameProperty =
            DependencyProperty.Register("SensorName", typeof(String), typeof(SensorIndicator), new PropertyMetadata("Sensor Name"));


    }
}
