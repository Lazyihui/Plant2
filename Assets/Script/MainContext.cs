public class MainContext {
    public GamaContext gamaContext;
    public AssetsContext assetsContext;




    public MainContext() {
        gamaContext = new GamaContext();
    }

    public void Inject(AssetsContext assetsContext) {
        this.assetsContext = assetsContext;
        gamaContext.Inject(assetsContext);
    }
}


