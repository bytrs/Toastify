using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Toastify : MonoBehaviour
{

    private const string RESOURCES_PATH = "Prefabs/UI";

    private const string SMALL_TOAST_NAME = "Toastify_Small";
    private const string MEDIUM_TOAST_NAME = "Toastify_Medium";
    private const string LARGE_TOAST_NAME = "Toastify_Large";


    public static void ThrowSmallToast(string message, Direction direction = Direction.Up, Transform parent = null)
    {
        var go = Resources.Load<GameObject>(Path.Combine(RESOURCES_PATH, SMALL_TOAST_NAME));
        ThrowToast(go, message, direction, parent);
    }

    public static void ThrowMediumToast(string message, Direction direction = Direction.Up, Transform parent = null)
    {
        var go = Resources.Load<GameObject>(Path.Combine(RESOURCES_PATH, MEDIUM_TOAST_NAME));
        ThrowToast(go, message, direction, parent);
    }

    public static void ThrowLargeToast(string message, Direction direction = Direction.Up, Transform parent = null)
    {
        var go = Resources.Load<GameObject>(Path.Combine(RESOURCES_PATH, LARGE_TOAST_NAME));
        ThrowToast(go, message, direction, parent);
    }

    private static void ThrowToast(GameObject toastGo, string message, Direction direction, Transform parent)
    {
        if (parent is null)
            parent = FindObjectOfType<Canvas>().transform;

        var toast = Instantiate(toastGo, parent).GetComponent<Toast>();
        toast.Play(message, direction);
    }
}