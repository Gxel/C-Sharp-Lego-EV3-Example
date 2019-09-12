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
using Lego.Ev3.Core;
using Lego.Ev3.Desktop;

namespace WpfApplicationLegoEV3Ansteuerung1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Brick brick;
        Action aAction;
        Task aTask;


        public void Hallo()
        {

        }



        /// <summary>
        /// 
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Dispatcher.UnhandledException += InitFehler.ExceptionCatcher;
            aAction = new Action(Hallo);
            aTask = new Task(aAction);

            ComboBoxItem aListItem = new ComboBoxItem();
            comboBoxComPort1.Items.Insert(0, "Com1");
            comboBoxComPort1.Items.Insert(1, "Com2");
            comboBoxComPort1.Items.Insert(2, "Com3");
            comboBoxComPort1.Items.Insert(3, "Com4");
            comboBoxComPort1.Items.Insert(4, "Com5");
            comboBoxComPort1.Items.Insert(5, "Com6");
            comboBoxComPort1.Items.Insert(6, "Com7");
            comboBoxComPort1.Items.Insert(7, "Com8");
            comboBoxComPort1.Items.Insert(8, "Com9");
            comboBoxComPort1.SelectedIndex = 0;
            gridBottom1.Visibility = Visibility.Hidden;
        }



        /// <summary>
        /// Verbindet mit dem Lego Brink, nach auswählen der Verbindung
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonVerbinden_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem aComboBoxItem = comboBoxCommunication1.SelectedItem as ComboBoxItem;
            if (aComboBoxItem.Content.ToString() == "USB")
            {
                UsbCommunication aUsbCommunication = new UsbCommunication();
                brick = new Brick(aUsbCommunication, true);
            }
            else
            {
                BluetoothCommunication aBluetoothCommunication1 = new BluetoothCommunication(comboBoxComPort1.SelectedValue.ToString());
                brick = new Brick(aBluetoothCommunication1, true);
            }
            // ---
            try
            {
                aTask = brick.ConnectAsync();
                lblStatusBarMessage1.Text = aTask.Status.ToString();      
                
                if (aTask.Status != TaskStatus.Faulted )
                {
                    gridBottom1.Visibility = Visibility.Visible;
                }                
            }
            catch ( Exception ex)
            {
                lblStatusBarMessage1.Text = "Exception: " + ex.Message ;
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void brick_BrickChanged(object sender, BrickChangedEventArgs e)
        {
            textBoxReturns.Text  = "-----------------------------------------------------------------------" + Environment.NewLine + textBoxReturns.Text;
            textBoxReturns.Text += "Sensorwert 1 (One)  :  " + brick.Ports[InputPort.One].SIValue.ToString() + Environment.NewLine + textBoxReturns.Text;
            textBoxReturns.Text += "Sensorwert 2 (Two)  :  " + brick.Ports[InputPort.Two].SIValue.ToString() + Environment.NewLine + textBoxReturns.Text;
            textBoxReturns.Text += "Sensorwert 3 (Three):  " + brick.Ports[InputPort.Three].SIValue.ToString() + Environment.NewLine + textBoxReturns.Text;
            textBoxReturns.Text += "Sensorwert 4 (Four) :  " + brick.Ports[InputPort.Four].SIValue.ToString() + Environment.NewLine + textBoxReturns.Text;
        }



        private void buttonGo_Click(object sender, RoutedEventArgs e)
        {

        }



        private void comboBoxCommunication1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxComPort1 != null)
            {
                ComboBoxItem aComboBoxItem = comboBoxCommunication1.SelectedItem as ComboBoxItem;
                if (aComboBoxItem.Content.ToString() == "USB")
                {
                    comboBoxComPort1.IsEnabled = false;
                }
                else
                {
                    comboBoxComPort1.IsEnabled = true;
                }
            }
        }



        private void buttonTrennen_Click(object sender, RoutedEventArgs e)
        {
            brick.Disconnect();
        }



        private void buttonStatus1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(aTask.Status.ToString());
        }



        private void buttonGoA_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                brick.DirectCommand.StepMotorAtSpeedAsync(OutputPort.A, Convert.ToInt32(sliderSpeedA.Value), Convert.ToUInt32(sliderSteppsA.Value), true);
            }            
            catch (Exception ex)
            {
                lblStatusBarMessage1.Text = "Exception: " + ex.Message ;
            }
        }



        private void buttonGoB_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
                brick.DirectCommand.StepMotorAtSpeedAsync(OutputPort.B, Convert.ToInt32(sliderSpeedB.Value), Convert.ToUInt32(sliderSteppsB.Value), true);
            }
            catch (Exception ex)
            {
                lblStatusBarMessage1.Text = "Exception: " + ex.Message;
            }
        }



        private void buttonGoC_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                brick.DirectCommand.StepMotorAtSpeedAsync(OutputPort.C, Convert.ToInt32(sliderSpeedC.Value), Convert.ToUInt32(sliderSteppsC.Value), true);
            }            
            catch (Exception ex)
            {
                lblStatusBarMessage1.Text = "Exception: " + ex.Message ;
            }
}



        private void buttonGoD_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                brick.DirectCommand.StepMotorAtSpeedAsync(OutputPort.D, Convert.ToInt32(sliderSpeedD.Value), Convert.ToUInt32(sliderSteppsD.Value), true);
            }
            catch (Exception ex)
            {
                lblStatusBarMessage1.Text = "Exception: " + ex.Message;
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStop_Click(object sender, RoutedEventArgs e)
        {
            brick.DirectCommand.StopMotorAsync(OutputPort.A, true);
            brick.DirectCommand.StopMotorAsync(OutputPort.B, true);
            brick.DirectCommand.StopMotorAsync(OutputPort.C, true);
            brick.DirectCommand.StopMotorAsync(OutputPort.D, true);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="aLabel"></param>
        /// <param name="aSlider"></param>
        private void handleSlider(Label aLabel, Slider aSlider)
        {
            if (aSlider != null & aLabel != null)
            {
                int i = Convert.ToInt32(aSlider.Value);
                aLabel.Content = i.ToString();
            }
        }




        private void sliderSpeedA_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            handleSlider(labelSpeedA, sliderSpeedA);
        }

        private void sliderSteppsA_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            handleSlider(labelSteppsA, sliderSteppsA);
        }

        private void sliderSpeedBy_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            handleSlider(labelSpeedB, sliderSpeedB);
        }

        private void sliderSteppsB_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            handleSlider(labelSteppsB, sliderSteppsB);
        }

        private void sliderSpeedC_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            handleSlider(labelSpeedC, sliderSpeedC);
        }

        private void sliderSteppsC_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            handleSlider(labelSteppsC, sliderSteppsC);
        }

        private void sliderSpeedD_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            handleSlider(labelSpeedD, sliderSpeedD);
        }

        private void sliderSteppsD_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            handleSlider(labelSteppsD, sliderSteppsD);
        }

        private void buttonSensor1_Click(object sender, RoutedEventArgs e)
        {
            BrickChangedEventArgs aBrickChangedEventArgs = new BrickChangedEventArgs();
            textBoxReturns.Text = "Sensorwert 1 (One):  " + brick.Ports[InputPort.One].SIValue.ToString() + Environment.NewLine + textBoxReturns.Text;
        }

        private void buttonSensor2_Click(object sender, RoutedEventArgs e)
        {
            BrickChangedEventArgs aBrickChangedEventArgs = new BrickChangedEventArgs();
            textBoxReturns.Text = "Sensorwert 2 (Two):  " + brick.Ports[InputPort.Two].SIValue.ToString() + Environment.NewLine + textBoxReturns.Text;
        }

        private void buttonSensor3_Click(object sender, RoutedEventArgs e)
        {
            BrickChangedEventArgs aBrickChangedEventArgs = new BrickChangedEventArgs();
            textBoxReturns.Text = "Sensorwert 3 (Three):  " + brick.Ports[InputPort.Three].SIValue.ToString() + Environment.NewLine + textBoxReturns.Text;
        }

        private void buttonSensor4_Click(object sender, RoutedEventArgs e)
        {
            BrickChangedEventArgs aBrickChangedEventArgs = new BrickChangedEventArgs();
            textBoxReturns.Text = "Sensorwert 4 (Four):  " + brick.Ports[InputPort.Four].SIValue.ToString() + Environment.NewLine + textBoxReturns.Text;
        }

        private void buttonSensorsAll_Click(object sender, RoutedEventArgs e)
        {
            brick.BrickChanged += brick_BrickChanged;
        }

        private void buttonIsCheckedGo_Click(object sender, RoutedEventArgs e)
        {
            if (checkBoxMotorA.IsChecked.Value)
            {
                buttonGoA_Click(sender,e);
            }


            if (checkBoxMotorB.IsChecked.Value)
            {
                buttonGoB_Click(sender, e);
            }


            if (checkBoxMotorC.IsChecked.Value)
            {
                buttonGoC_Click(sender, e);
            }


            if (checkBoxMotorD.IsChecked.Value)
            {
                buttonGoD_Click(sender, e);
            }
        }
    }
}
