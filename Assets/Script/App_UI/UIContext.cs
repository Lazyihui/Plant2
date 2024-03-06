using UnityEngine;
public class UIcontext {

    public UIEvents events;

    public Panel_Login panel_Login;

    public AssetsContext assetsContext;

    public Canvas canvas;

    public Panel_PlantManifest panel_PlantManifest;

    public Panel_Sun panel_Sun;

    public Panel_Shovel panel_Shovel;

    public Panel_Select panel_Select;



    public UIcontext() {
        events = new UIEvents();
    }

    public void Inject(AssetsContext assetsContext, Canvas canvas) {
        this.assetsContext = assetsContext;
        this.canvas = canvas;
    }
}