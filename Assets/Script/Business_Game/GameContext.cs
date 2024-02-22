public class GameContext {


    public AssetsContext assetsContext;

    public HomeRepository homeRepository;

    public BaseRepository baseRepository;

    public MstRepository mstRepository;
    public int MstID;

    public int homeID;
    public int baseID;
    public GameContext() {

        homeRepository = new HomeRepository();
        baseRepository = new BaseRepository();
        mstRepository = new MstRepository();

        baseID = 0;
        homeID = 0;
        MstID = 0;
    }

    public void Inject(AssetsContext assetsContext) {
        this.assetsContext = assetsContext;
    }

}