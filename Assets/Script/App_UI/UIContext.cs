using UnityEngine;
public class UIcontext {

    public Panel_Login panel_Login;

    public AssetsContext assetsContext;

    public Canvas canvas;


    public UIcontext() {
    }

    public void Inject(AssetsContext assetsContext, Canvas canvas) {
        this.assetsContext = assetsContext;
        this.canvas = canvas;
    }
}