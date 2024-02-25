using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class TemplateInfra {

    public static void Load(TemplateContext ctx) {
        {

            AssetLabelReference labelReference = new AssetLabelReference();
            labelReference.labelString = "TM_Mst";
            IList<MstTM> all = Addressables.LoadAssetsAsync<MstTM>(labelReference, null).WaitForCompletion();

            for (int i = 0; i < all.Count; i++) {
                MstTM mst = all[i];
                ctx.mst.Add(mst.TypeID, mst);
            }
        }
        {
            AssetLabelReference labelReference = new AssetLabelReference();
            labelReference.labelString = "TM_Bases";
            IList<BasesTM> all = Addressables.LoadAssetsAsync<BasesTM>(labelReference, null).WaitForCompletion();

            for (int i = 0; i < all.Count; i++) {
                BasesTM bases = all[i];
                ctx.bases.Add(bases.TypeID, bases);
            }
        }
        {
            AssetLabelReference labelReference = new AssetLabelReference();
            labelReference.labelString = "TM_Home";
            IList<HomeTM> all = Addressables.LoadAssetsAsync<HomeTM>(labelReference, null).WaitForCompletion();

            for (int i = 0; i < all.Count; i++) {
                HomeTM home = all[i];
                ctx.homes.Add(home.TypeID, home);
            }


        }
        {
            AssetLabelReference labelReference = new AssetLabelReference();
            labelReference.labelString = "TM_Plant";
            IList<PlantTM> all = Addressables.LoadAssetsAsync<PlantTM>(labelReference, null).WaitForCompletion();

            for (int i = 0; i < all.Count; i++) {
                PlantTM plant = all[i];
                ctx.plants.Add(plant.typeID, plant);
            }
        }
        {
            AssetLabelReference labelReference = new AssetLabelReference();
            labelReference.labelString = "TM_GameConfig";
            GameConfigTM tm = Addressables.LoadAssetAsync<GameConfigTM>(labelReference).WaitForCompletion();
            ctx.gameConfig = tm;
            
        }


    }



}