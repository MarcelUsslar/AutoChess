using UniRx;
using _Scripts.Shop;
using _Scripts.Utility;

namespace _Scripts.Hud
{
    public class HudShopController
    {
        public HudShopController(HudView hudView, IEventBus eventBus, IDisposer disposer)
        {
            hudView.ShopButton.OnClickAsObservable()
                .SubscribeBlind(() => eventBus.Publish(new OpenShopCommand()))
                .AddToDisposer(disposer);
        }
    }
}