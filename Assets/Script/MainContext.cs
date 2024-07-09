using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainContext {
    public GameContext gamaContext;
    public AssetsContext assetsContext;

    public UIcontext uiContext;

    public TemplateContext templateContext;

    public MainContext() {
        gamaContext = new GameContext();
        uiContext = new UIcontext();
        templateContext = new TemplateContext();
        assetsContext = new AssetsContext();
    }

    public void Inject(Canvas canvas,Camera mainCamera) {
        gamaContext.Inject(assetsContext, uiContext, templateContext,mainCamera);
        uiContext.Inject(assetsContext, canvas);
    }
}


