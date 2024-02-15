using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainContext {
    public GamaContext gamaContext;
    public AssetsContext assetsContext;

    public UIcontext uiContext;




    public MainContext() {
        gamaContext = new GamaContext();
        uiContext = new UIcontext();
    }

    public void Inject(Canvas canvas,AssetsContext assetsContext) {
        this.assetsContext = assetsContext;
        gamaContext.Inject(assetsContext);
        uiContext.Inject(assetsContext,canvas);
    }
}


