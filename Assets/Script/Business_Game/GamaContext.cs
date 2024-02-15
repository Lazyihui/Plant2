public class GamaContext {


    public AssetsContext assetsContext;

    public GamaContext(){

    }

    public void Inject(AssetsContext assetsContext){
        this.assetsContext = assetsContext;
    }

}