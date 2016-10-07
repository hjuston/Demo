using UnityEngine;

public static class Helper
{
    public static GUIManager GetGUIManager()
    {
        GUIManager manager = null;

        GameObject guiManagerObj = GameObject.FindGameObjectWithTag(CONST.GUIManagerTag);
        if(guiManagerObj != null)
        {
            manager = guiManagerObj.GetComponent<GUIManager>();
        } 

        return manager;
    }
}