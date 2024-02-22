public class GameContext {

    public PlayerEntity playerEntity;
    public AssetsContext assetsContext;

    public HomeRepository homeRepository;

    public BaseRepository baseRepository;

    public MstRepository mstRepository;
    public UIcontext uiContext;
    public int MstID;

    public int homeID;
    public int baseID;
    public GameContext() {
        playerEntity = new PlayerEntity();
        homeRepository = new HomeRepository();
        baseRepository = new BaseRepository();
        mstRepository = new MstRepository();
        uiContext = new UIcontext();

        baseID = 0;
        homeID = 0;
        MstID = 0;
    }

    public void Inject(AssetsContext assetsContext, UIcontext uiContext) {
        this.assetsContext = assetsContext;
        this.uiContext = uiContext;
    }

}