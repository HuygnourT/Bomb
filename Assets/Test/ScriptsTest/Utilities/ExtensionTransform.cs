using UnityEngine;

public static class Transforms
{
    public static void DestroyChildren(this Transform t, bool destroyImediately = false)
    {
        foreach(Transform child in t)
        {
            if (destroyImediately)
                MonoBehaviour.DestroyImmediate(child.gameObject);
            else 
                MonoBehaviour.Destroy(child.gameObject);
        }
    }


}