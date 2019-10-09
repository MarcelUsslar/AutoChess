using _Scripts.Shop;
using _Scripts.Utility;

namespace _Scripts.Hud
{
    public class HudController
    {
        public HudController(IHudView hudView, IEventBus eventBus, IDisposer disposer)
        {
            eventBus.OnEvent<OpenShopCommand>().SubscribeBlind(hudView.Close).AddToDisposer(disposer);
            eventBus.OnEvent<CloseShopEvent>().SubscribeBlind(hudView.Open).AddToDisposer(disposer);
        }
    }
}