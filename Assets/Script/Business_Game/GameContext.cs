using UnityEngine;
public class GameContext {

    public PlayerEntity playerEntity;
    public AssetsContext assetsContext;

    public InputEntity inputEntity;

    public HomeRepository homeRepository;

    public BaseRepository baseRepository;

    public MstRepository mstRepository;

    public BulletRepository bulletRepository;

    public CellRepository cellRepository;

    public plantRepository plantRepository;

    public CartRepository cartRepository;
    public UIcontext uiContext;

    public TemplateContext templateContext;

    public Camera camera;


    public int MstID;

    public int homeID;
    public int baseID;

    public int bulletID;
    public int plantID;

    public int cellID;

    public int cartID;

    public GameContext() {
        playerEntity = new PlayerEntity();
        homeRepository = new HomeRepository();
        baseRepository = new BaseRepository();
        mstRepository = new MstRepository();
        bulletRepository = new BulletRepository();  
        cellRepository = new CellRepository();
        uiContext = new UIcontext();
        plantRepository = new plantRepository();
        inputEntity = new InputEntity();
        cartRepository = new CartRepository();

        baseID = 0;
        homeID = 0;
        MstID = 0;
        bulletID = 0;
        plantID = 0;
        cellID = 0;
        cartID = 0;
    }

    public void Inject(AssetsContext assetsContext, UIcontext uiContext, TemplateContext templateContext, Camera camera) {
        this.assetsContext = assetsContext;
        this.uiContext = uiContext;
        this.templateContext = templateContext;
        this.camera = camera;

    }

}