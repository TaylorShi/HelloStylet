using System.Diagnostics;
using System;
using System.Security.Claims;
using Stylet;

namespace HelloStyletClient.Pages
{
    public class ShellViewModel : Screen
    {
        // /// <summary>
        // /// 欢迎词
        // /// </summary>
        // /// <value></value>
        // public string WelcomeWord { get; set; } = "Hello Stylet!";

        // /// <summary>
        // /// 能否提交
        // /// </summary>
        // /// <value></value>
        // public bool IsCanSubmitMe => !string.IsNullOrEmpty(CurrentWorkRecord.WelcomeWord);

        /// <summary>
        /// 当前工作记录
        /// </summary>
        /// <returns></returns>
        public WorkRecord CurrentWorkRecord { get; set; } = new WorkRecord();

        /// <summary>
        /// 提交事件
        /// </summary>
        public void SubmitMe(string argument)
        {
            CurrentWorkRecord.WelcomeWord += $" {argument}";
        }

        /// <summary>
        /// 欢迎词变更事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void WelcomeWordTextChanged(object sender, EventArgs e)
        {
           Debug.WriteLine(((System.Windows.Controls.TextBox)sender)?.Text ?? string.Empty);
        }
    }

    /// <summary>
    /// 工作记录
    /// </summary>
    public class WorkRecord : PropertyChangedBase
    {
        /// <summary>
        /// 欢迎词
        /// </summary>
        /// <value></value>
        public string WelcomeWord { get; set; } = "Hello Stylet!";

        /// <summary>
        /// 能否提交
        /// </summary>
        /// <value></value>
        public bool IsCanSubmitMe => !string.IsNullOrEmpty(WelcomeWord);
    }
}
