using StyletLoginDesign.Pages;
using Stylet;
using StyletIoC;
using StyletLoginDesign.Services;
using Stylet.Logging;

namespace StyletLoginDesign
{
    public class Bootstrapper : Bootstrapper<SplashViewModel>
    {
        protected override void ConfigureIoC(IStyletIoCBuilder builder)
        {
            // Configure the IoC container in here
            builder.Bind<ILogger>().To<LoggerService>();
            builder.Bind<ILogService>().To<LogService>();
            builder.Bind<ILangService>().To<LangService>();
        }

        protected override void Configure()
        {

        }

        protected override void OnStart()
        {
            Stylet.Logging.LogManager.Enabled = true;
        }
    }
}
