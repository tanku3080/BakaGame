using UnityEngine;
using UnityEditor;

public class ObjectsAddComponent : MonoBehaviour
{
    [MenuItem("Editor/AddBLD")]

    //特定のTag(build)を探して指定のコンポーネントをアタッチ
    private static void AddObj()
    {
        foreach (var item in SearchObj())
        {
            if (!item.GetComponent<ObjController>())
            {
                item.AddComponent<ObjController>();
            }
        }
    }

    private static GameObject[] SearchObj()
    {
        return GameObject.FindGameObjectsWithTag("build");
    }
    [MenuItem("Editor/DeletgBLD")]
    //特定のTagを探して指定のコンポーネントを削除
    private static void DeletObj()
    {
        foreach (var item in SearchObj())
        {
            if (item.GetComponent<ObjController>())
            {
                DestroyImmediate(item.GetComponent<ObjController>());
            }
        }
    }

    [MenuItem("Editor/AddColision")]
    private static void AddColision()
    {
        foreach (var item in SearchObj())
        {
            if (!item.GetComponent<BoxCollider>())
            {
                item.AddComponent<BoxCollider>();
            }
        }
    }

    [MenuItem("Editor/Test")]

    private static void Test()
    {
        foreach (var item in SearchObj())
        {
            DestroyImmediate(item.GetComponent<Particle>());
        }
    }

    [MenuItem("Editor/RigitBody/Add")]
    private static void AddRd()
    {
        foreach (var item in SearchObj())
        {
            if (!item.GetComponent<Rigidbody>())
            {
                item.AddComponent<Rigidbody>();
            }
        }
    }
    [MenuItem("Editor/RigitBody/Remove")]
    private static void RemoveSetting()
    {
        foreach (var item in SearchObj())
        {
            if (item.GetComponent<Rigidbody>())
            {
                DestroyImmediate(item.GetComponent<Rigidbody>());
            }
        }
    }

    [MenuItem("Editor/RigitBody/useGravity_false")]
    private static void Setting()
    {
        foreach (var item in SearchObj())
        {
            if (!item.GetComponent<Rigidbody>().useGravity == false)
            {
                item.GetComponent<Rigidbody>().useGravity = false;
            }
        }
    }
    [MenuItem("Editor/ObjLayerSet")]
    private static void LayerSet()
    {
        foreach (var item in SearchObj())
        {
            item.layer = 9;
        }
    }
}
