using VContainer;
using VContainer.Unity;
using MessagePipe;

/// <summary>
/// リクエスト/レスポンス/オールのMessagePipe使用例:らいふすこーぷ
/// </summary>
public class RRALifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        // パイプのオプション
        MessagePipeOptions options = builder.RegisterMessagePipe();
        // メッセージの型、返答の型、なんか処理して返答するメソッド(Invoke)が
        // 書かれたクラスを登録する
        builder.RegisterRequestHandler<int, bool, RRARequestHandler>(options);
        // エントリーポイントとしてPresenterを
        builder.RegisterEntryPoint<RRAPresenter>(Lifetime.Scoped);
    }
}
