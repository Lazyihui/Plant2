public class GamaContext {


    public AssetsContext assetsContext;

    public HomeRepository homeRepository;

    public BaseRepository baseRepository;

    public int homeID;
    public int baseID;
    public GamaContext() {

        homeRepository = new HomeRepository();
        baseRepository = new BaseRepository();

        baseID = 0;
        homeID = 0;
    }

    public void Inject(AssetsContext assetsContext) {
        this.assetsContext = assetsContext;
    }

}