using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainContext {
    public GameContext gamaContext;
    public AssetsContext assetsContext;

    public UIcontext uiContext;




    public MainContext() {
        gamaContext = new GameContext();
        uiContext = new UIcontext();
    }

    public void Inject(Canvas canvas,AssetsContext assetsContext) {
        this.assetsContext = assetsContext;
        gamaContext.Inject(assetsContext);
        uiContext.Inject(assetsContext,canvas);
    }
}


