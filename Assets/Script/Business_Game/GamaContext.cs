public class GamaContext {


    public AssetsContext assetsContext;

    public HomeRepository homeRepository;

    public int homeID;

    public GamaContext() {

        homeRepository = new HomeRepository();
        homeID = 0;
    }

    public void Inject(AssetsContext assetsContext) {
        this.assetsContext = assetsContext;
    }

}