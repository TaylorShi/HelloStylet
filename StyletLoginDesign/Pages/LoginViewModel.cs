using Stylet;

namespace StyletLoginDesign.Pages
{
    public class LoginViewModel : Screen
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ((System.Windows.Window)sender).DragMove();
        }

        /// <summary>
        /// ¥ÌŒÛÃ· æ
        /// </summary>
        public string ErrorMessage { get; set; }

        public void Close()
        {
            RequestClose();
        }
    }
}
