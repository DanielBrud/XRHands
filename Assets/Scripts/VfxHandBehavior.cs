using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;



public class VfxHandBehavior : MonoBehaviour
{
    [SerializeField] private GameObject handVisualizer;    
    [SerializeField] private VisualEffect handsVFX;
    

    private SkinnedMeshRenderer[] handsSkinnedMeshList;
    private SkinnedMeshRenderer leftHandSkinndMesh;
    private SkinnedMeshRenderer rightHandSkinndMesh;

    private readonly int leftHandSkinnedMeshVFXID = Shader.PropertyToID("LeftHand");
    private readonly int rightHandSkinnedMeshVFXID = Shader.PropertyToID("RightHand");
    private readonly int startSkinnedMeshVFXID = Shader.PropertyToID("StartFollowHands");

    private VFXEventAttribute eventAttribute;
        


    private void OnEnable()
    {
        Invoke("GetHandsSkinnedMeshRender", 2f);
        eventAttribute = handsVFX.CreateVFXEventAttribute();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void GetHandsSkinnedMeshRender()
    {
        Debug.Log(handVisualizer.transform.childCount.ToString());
        if (handVisualizer.transform.childCount > 0)
        {
            handsSkinnedMeshList = handVisualizer.GetComponentsInChildren<SkinnedMeshRenderer>();

            leftHandSkinndMesh = handsSkinnedMeshList[0];
            rightHandSkinndMesh = handsSkinnedMeshList[1];
            Debug.Log(leftHandSkinndMesh.sharedMesh.ToString());
            Debug.Log(rightHandSkinndMesh.sharedMesh.ToString());
            handsVFX.SetSkinnedMeshRenderer(leftHandSkinnedMeshVFXID, leftHandSkinndMesh);
            handsVFX.SetSkinnedMeshRenderer(rightHandSkinnedMeshVFXID, rightHandSkinndMesh);
            handsVFX.SendEvent(startSkinnedMeshVFXID, eventAttribute);
        }


    }
}
