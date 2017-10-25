using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for StorageIndicator.xaml
    /// </summary>
    public partial class StorageIndicator : UserControl
    {
        public StorageIndicator()
        {
            InitializeComponent();

            DataContext = this;
        }

        public int ProductsCount
        {
            get { return (int)GetValue(ProductsCountProperty); }
            set { SetValue(ProductsCountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProductsCount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProductsCountProperty =
            DependencyProperty.Register("ProductsCount", typeof(int), typeof(StorageIndicator), new PropertyMetadata(0));

        public SensorState Sensor1State 
        {
            get { return (SensorState)GetValue(Sensor1StateProperty); }
            set { SetValue(Sensor1StateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Sensor1StateProperty =
            DependencyProperty.Register("Sensor1State", typeof(SensorState), typeof(StorageIndicator), new PropertyMetadata(SensorState.Deactivated));

        public SensorState Sensor2State
        {
            get { return (SensorState)GetValue(Sensor2StateProperty); }
            set { SetValue(Sensor2StateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Sensor2StateProperty =
            DependencyProperty.Register("Sensor2State", typeof(SensorState), typeof(StorageIndicator), new PropertyMetadata(SensorState.Deactivated));

        public String Sensor1Name
        {
            get { return (String)GetValue(Sensor1NameProperty); }
            set { SetValue(Sensor1NameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Sensor1Name.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Sensor1NameProperty =
            DependencyProperty.Register("Sensor1Name", typeof(String), typeof(StorageIndicator), new PropertyMetadata("Sensor Name"));
        public String Sensor2Name
        {
            get { return (String)GetValue(Sensor2NameProperty); }
            set { SetValue(Sensor2NameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Sensor1Name.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Sensor2NameProperty =
            DependencyProperty.Register("Sensor2Name", typeof(String), typeof(StorageIndicator), new PropertyMetadata("Sensor Name"));
    }
}
