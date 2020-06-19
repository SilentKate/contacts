namespace UI.LoadingHandlers
{
    public class GameObjectLoadingHandler : UILoadingHandler
    {
        public override void SetIsLoading(bool value)
        {
            this.gameObject.SetActive(value);
        }
    }
}