using Stylet;

namespace HelloStyletClient.Pages
{
    public class ShellViewModel : Screen
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

        /// <summary>
        /// 提交事件
        /// </summary>
        public void SubmitMe()
        {
            WelcomeWord += " 提交";
        }
    }
}
