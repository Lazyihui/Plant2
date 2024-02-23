using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public static class AsstesInfra {

    public static void Load(AssetsContext ctx) {
        {

            AssetLabelReference labelReference = new AssetLabelReference();
            labelReference.labelString = "Entities";
            IList<GameObject> all = Addressables.LoadAssetsAsync<GameObject>(labelReference, null).WaitForCompletion();
            for (int i = 0; i < all.Count; i++) {
                GameObject entity = all[i];
                ctx.entities.Add(entity.name, entity);
            }
        }
        {

            AssetLabelReference labelReference = new AssetLabelReference();
            labelReference.labelString = "Panels";
            IList<GameObject> all = Addressables.LoadAssetsAsync<GameObject>(labelReference, null).WaitForCompletion();
            for (int i = 0; i < all.Count; i++) {
                GameObject entity = all[i];
                Debug.Log(all[i].name);
                ctx.panels.Add(entity.name, entity);
            }
        }
    }
}
