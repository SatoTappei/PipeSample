using VContainer;
using VContainer.Unity;
using MessagePipe;

/// <summary>
/// ‚à‚Ì‚Ñ‚ğŒp³‚µ‚½ê‡‚ÌMessagePipeg—p—á:‚ç‚¢‚Ó‚·‚±[‚Õ
/// </summary>
public class DefaultLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        MessagePipeOptions options = builder.RegisterMessagePipe();
        builder.RegisterMessageBroker<int>(options);
    }
}
