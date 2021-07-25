using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using Stylet;
using StyletIoC;
using StyletLoginDesign.Helper;
using StyletLoginDesign.Models.Message;
using StyletLoginDesign.Services;

namespace StyletLoginDesign.Pages
{
    /// <summary>
    /// 启动界面
    /// </summary>
    public class SplashViewModel : Screen, IHandle<UpdateSplashStatusDescriptionEvent>
    {
        /// <summary>
        /// 窗口管理
        /// </summary>
        private IWindowManager _windowManager;

        /// <summary>
        /// Ioc容器
        /// </summary>
        private readonly IContainer _container;

        /// <summary>
        /// 事件集线器
        /// </summary>
        private readonly IEventAggregator _eventAggregator;

        /// <summary>
        /// 语言服务
        /// </summary>
        private readonly ILangService _langService;

        /// <summary>
        /// 日志服务
        /// </summary>
        private readonly ILogService _logService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="windowManager"></param>
        /// <param name="container"></param>
        public SplashViewModel(IWindowManager windowManager, IContainer container, IEventAggregator eventAggregator, ILangService langService, ILogService logService)
        {
            _windowManager = windowManager;
            _container = container;
            _eventAggregator = eventAggregator;
            _langService = langService;
            _logService = logService;
        }

        /// <summary>
        /// 页面标题
        /// </summary>
        public string Title { get; set; } = "启动页面";

        /// <summary>
        /// 状态描述
        /// </summary>
        public string StatusDescription { get; set; } = "Loading...";

        /// <summary>
        /// 响应鼠标左键按下的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // 让窗体随着拖拽移动
            ((System.Windows.Window)sender).DragMove();
        }

        /// <summary>
        /// 窗体加载完毕
        /// </summary>
        protected override void OnViewLoaded()
        {
            LanguageContextService.Instance().Provider = System.Windows.Application.Current.TryFindResource("Lang") as XmlDataProvider;

            var lanSourcePath = $"Languages/Languages.{"en-US"}.xml";
            var lanUri = new Uri(lanSourcePath, UriKind.Relative);
            LanguageContextService.Instance().Provider.Source = lanUri;
            LanguageContextService.Instance().Provider.Refresh();

            // 开始状态更新
            StartStatusUpdate();


        }

        /// <summary>
        /// 开始状态更新
        /// </summary>
        private void StartStatusUpdate()
        {
            // 订阅消息
            _eventAggregator.Subscribe(this);

            var Splash_StatusDescription = _langService.GetXmlLocalizedString("Splash_StatusDescription");

            // 异步线程通知更新
            Task.Factory.StartNew(async () => {
                for (var i = 0; i <= 99; i++)
                {
                    await Task.Delay(TimeSpan.FromMilliseconds(12.5));

                    // 发送消息
                    _eventAggregator.Publish(new UpdateSplashStatusDescriptionEvent
                    {
                        StatusDescription = $"{Splash_StatusDescription}({i + 1}%)..."
                    }); ;
                }

                Execute.OnUIThread(()=> {

                    var loginViewModel = _container.Get<LoginViewModel>();
                    _windowManager.ShowWindow(loginViewModel);
                    RequestClose();
                });
            });
        }

        /// <summary>
        /// 接收来自更新启动状态描述的消息
        /// </summary>
        /// <param name="message"></param>
        public void Handle(UpdateSplashStatusDescriptionEvent message)
        {
            StatusDescription = message.StatusDescription;
            _logService.LogDo("rizhi", "", GetType(), null);
        }
    }
}
