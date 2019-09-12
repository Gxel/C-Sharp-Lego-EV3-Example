/*
 * BEISPIEL FÜR DIE EINBINDUNG
 * 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Dispatcher.UnhandledException += InitFehler.ExceptionCatcher;
        }
    }
 */


using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Diagnostics;
using Microsoft.Win32;
using System.Drawing;
using System.Net.Mail;

namespace WpfApplicationLegoEV3Ansteuerung1
{
    static class InitFehler
    {
        public static void ExceptionCatcher(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            FailDialog aFehlerDialog = new FailDialog(e.Exception);
            aFehlerDialog.ShowDialog();
        }
    }




    /// <summary>
    /// Interaktionslogik für FehlerDialog.xaml
    /// </summary>
    public partial class FailDialog : Window
    {
        private Exception FException;
        private string FErrorFilename;

        public FailDialog()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Dialog der bei Fehlern aufpopt
        /// </summary>
        /// <param name="paramException"></param>
        public FailDialog( Exception paramException)
        {
            InitializeComponent();
            this.FException = paramException;
            FErrorFilename = this.MakeScreenShot();
            BitmapImage aBitmapImage = new BitmapImage();
            aBitmapImage.BeginInit();
            aBitmapImage.UriSource = new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, FErrorFilename));
            aBitmapImage.EndInit();
            imageScreenShot1.Source = aBitmapImage;
            txtboxErrorMsg.Text = paramException.ToString();
            File.AppendAllText("error.log", DateTime.Now + Environment.NewLine + paramException + Environment.NewLine + Environment.NewLine + Environment.NewLine);
        }


        /// <summary>
        /// Die Option ein Screenshot vom Fehler zu erstellen
        /// </summary>
        /// <returns></returns>
        public string MakeScreenShot()
        {
            string filename = String.Empty;
            double screenLeft = SystemParameters.VirtualScreenLeft;
            double screenTop = SystemParameters.VirtualScreenTop;
            double screenWidth = SystemParameters.VirtualScreenWidth;
            double screenHeight = SystemParameters.VirtualScreenHeight;
            using (Bitmap aBitmap1 = new Bitmap( (int)screenWidth, ((int)screenHeight)*2 ) )
            {
                using (Graphics aSingleGraphics1 = Graphics.FromImage(aBitmap1))
                {
                    filename = "error_" + DateTime.Now.ToString("yyMMdd_Hmmss") + ".png";
                    aSingleGraphics1.CopyFromScreen( ((int)screenLeft), ((int)screenTop) * 2, 0, 0, aBitmap1.Size);
                    System.Drawing.Point aPoint1 = new System.Drawing.Point(0, ((int)screenHeight)+30);
                    aSingleGraphics1.DrawString("Fehlermeldung : " + FException.Message, new Font("Arial", 24), System.Drawing.Brushes.Red, aPoint1);
                    aPoint1.Y += 100;
                    aSingleGraphics1.DrawString("Benutzername : " + Environment.UserName, new Font("Arial", 24), System.Drawing.Brushes.Red, aPoint1);
                    aPoint1.Y += 40;
                    aSingleGraphics1.DrawString("Betriebssystem : " + Environment.OSVersion, new Font("Arial", 24), System.Drawing.Brushes.Red, aPoint1);
                    aPoint1.Y += 40;
                    aSingleGraphics1.DrawString("Computer : " + Environment.MachineName, new Font("Arial", 24), System.Drawing.Brushes.Red, aPoint1);
                    aPoint1.Y += 40;
                    aSingleGraphics1.DrawString("Version der Applikation : " + Environment.Version, new Font("Arial", 24), System.Drawing.Brushes.Red, aPoint1);
                    aPoint1.Y += 40;
                    aSingleGraphics1.DrawString("StackTrace : " + Environment.NewLine + FException.ToString(), new Font("Arial", 14), System.Drawing.Brushes.Red, aPoint1);
                    aBitmap1.Save(filename);
                }
            }
            return filename;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }




        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "png";
            saveFileDialog.Filter = "Bild (*.png)| *.png";
            saveFileDialog.FileName = FErrorFilename;
            if (saveFileDialog.ShowDialog() == true)
            {
                File.Copy(System.IO.Path.Combine(Environment.CurrentDirectory, FErrorFilename), saveFileDialog.FileName, true);
            }            
            buttonSave1.IsEnabled = false;
        }





        private void buttonSend1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MailMessage aMailMessage = new MailMessage();
                aMailMessage.From = new MailAddress("absender@domain.de"); //Absender 
                aMailMessage.To.Add("emfang@domain.de"); //Empfänger 
                aMailMessage.Subject = "Das ist der Betreff";
                aMailMessage.Body = "Der Inhalt";
                if (chkBoxSendScreenShot.IsChecked == true)
                {
                    aMailMessage.Attachments.Add(new System.Net.Mail.Attachment(System.IO.Path.Combine(Environment.CurrentDirectory, FErrorFilename)));
                }
                //mail.IsBodyHtml = true; //Nur wenn Body HTML Quellcode ist  
                SmtpClient client = new SmtpClient("smtp.live.com", 25); //SMTP Server von Hotmail und Outlook. 
                try
                {
                    client.Credentials = new System.Net.NetworkCredential("absender@domain.de", "Passwort");//Anmeldedaten für den SMTP Server 
                    client.EnableSsl = true; //Die meisten Anbieter verlangen eine SSL-Verschlüsselung 
                    client.Send(aMailMessage); //Senden 
                    buttonSend1.IsEnabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "E-Mail senden fehlgeschlagen.");
                }

            }
            catch(Exception ex)
            {
                string s = string.Empty;
                s += "Fehler E-Mail kann nicht gesendet werden." + Environment.NewLine;
                s += ex.Message;
                MessageBox.Show(s);
            }
        }





        private void buttonProgrammAbbruch1_Click(object sender, RoutedEventArgs e)
        {
            string str = Process.GetCurrentProcess().ProcessName;
            Process[] pp = Process.GetProcessesByName(str);
            foreach (Process p in pp)
            {
                //p.CloseMainWindow();
                p.Kill();
            }
        }




        private void buttonTrotzdemWeiter1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
