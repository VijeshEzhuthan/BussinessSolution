using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using System.ComponentModel;

namespace BussinessSolution
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            userNameText.Focus();
           
        }
        public string Password { get; set; }
        public string UserName { get; set; }
        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
  //              Application.Current.Dispatcher.BeginInvoke(
  //DispatcherPriority.Background,
  //new Action(() =>
  //{
  //    drawCanvas();
  //    this.canvas2.Visibility = Visibility.Visible;
  //    DoubleAnimation a = new DoubleAnimation();
  //    a.From = 0;
  //    a.To = 360;
  //    a.RepeatBehavior = RepeatBehavior.Forever;
  //    a.SpeedRatio = 1;

  //    this.spin.BeginAnimation(RotateTransform.AngleProperty, a);
  //    this.loginButton.Visibility = Visibility.Hidden;
  //}));

               
               
                ForceValidation();

                if (!Validation.GetHasError(passwordText) && !Validation.GetHasError(userNameText))
                {
                    string userName = userNameText.Text.Trim();
                    string password = passwordText.Text.Trim();

                    string[] userInfo = { userName, password };
                    BackgroundWorker worker = new BackgroundWorker();
                    worker.WorkerReportsProgress = true;
                    worker.DoWork += worker_DoWork;
                    worker.ProgressChanged += worker_ProgressChanged;
                    worker.RunWorkerCompleted += worker_RunWorkerCompleted;
                    worker.RunWorkerAsync(userInfo);

                    //if (BLL.UserBLL.ValidatedUserLogin(userName, password))
                    //{
                    //    canvas2.Visibility = Visibility.Collapsed;
                    //    this.DialogResult = true;
                    //}
                    //else
                    //{
                    //    loginValidation.Text = "User name or password is not valid";
                    //}
                }

                //canvas2.Visibility = Visibility.Collapsed;
               

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void ForceValidation()
        {
            passwordText.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            userNameText.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }

        void drawCanvas()
        {
            for (int i = 0; i < 12; i++)
            {
                Line line = new Line()
                {
                    X1 = 15,
                    X2 = 15,
                    Y1 = 0,
                    Y2 = 6,
                    StrokeThickness = 5,
                    Stroke = Brushes.Gray,
                    Width = 30,
                    Height = 30
                };
                line.VerticalAlignment = VerticalAlignment.Center;
                line.HorizontalAlignment = HorizontalAlignment.Center;
                line.RenderTransformOrigin = new Point(.5, .5);
                line.RenderTransform = new RotateTransform(i * 30);
                line.Opacity = (double)i / 12;

                canvas1.Children.Add(line);

            }
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                bool result = false;
                string[] userInfo = (string[])e.Argument;

                string userName = userInfo[0];// userNameText.Text.Trim();
                string password = userInfo[1];//passwordText.Text.Trim();
                (sender as BackgroundWorker).ReportProgress(1, true);
                if (BLL.UserBLL.ValidatedUserLogin(userName, password))
                {
                   
                    result = true;
                }
                else
                {
                    result = false;

                }

                //  (sender as BackgroundWorker).ReportProgress(0, false);

                e.Result = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //pbCalculationProgress.Value = e.ProgressPercentage;
            if (e.UserState != null && (bool)e.UserState==true)
            {
                drawCanvas();
                this.canvas2.Visibility = Visibility.Visible;
                DoubleAnimation a = new DoubleAnimation();
                a.From = 0;
                a.To = 360;
                a.RepeatBehavior = RepeatBehavior.Forever;
                a.SpeedRatio = 1;

                this.spin.BeginAnimation(RotateTransform.AngleProperty, a);
                this.loginButton.Visibility = Visibility.Hidden;
            }
            else
            {
                canvas2.Visibility = Visibility.Collapsed;
            }
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
               // this.DialogResult = true;
                canvas2.Visibility = Visibility.Collapsed;
                if (e.Result != null)
                {
                    if ((bool)e.Result == true)
                        this.DialogResult = true;
                    else
                    {
                        this.loginButton.Visibility = Visibility.Visible;
                        loginValidation.Text = "User name or password is not valid";
                    }
                }
            }
            catch(Exception ex)
            {
                this.loginButton.Visibility = Visibility.Visible;
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
