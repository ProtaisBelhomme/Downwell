using UnityEngine;
using NaughtyAttributes;

public class ShaderLink : MonoBehaviour
{
    protected Renderer render = null;
    private MaterialPropertyBlock propBlock = null;

    protected virtual void Awake() => render = GetComponent<Renderer>();

    // Récupère les données du Renderer et les stocke dans le MaterialPropertyBlock
    private void GetData(Renderer render, ref MaterialPropertyBlock propBlock)
    {
        // Permet de modifier les paramètres sans modifier le matériau ou créer une instance
        propBlock = new MaterialPropertyBlock();
        // Récupère les données
        render.GetPropertyBlock(propBlock, 0);
    }

    // Envoie les données stockées dans le MaterialPropertyBlock au Renderer
    private void SendData() => render.SetPropertyBlock(propBlock, 0);

    // Met à jour les propriétés de type float dans le MaterialPropertyBlock
    public void UpdateProperty((string key, float value)[] shadersData)
    {
        GetData(render, ref propBlock);
        foreach (var shaderData in shadersData)
        {
            propBlock.SetFloat(shaderData.key, shaderData.value);
        }
        SendData();
    }

    // Met à jour les propriétés de type Texture2D dans le MaterialPropertyBlock
    public void UpdateProperty((string key, Texture2D value)[] shadersData)
    {
        GetData(render, ref propBlock);
        foreach (var shaderData in shadersData)
        {
            propBlock.SetTexture(shaderData.key, shaderData.value);
        }
        SendData();
    }

    // Met à jour les propriétés de type Vector4 dans le MaterialPropertyBlock
    public void UpdateProperty((string key, Vector4 value)[] shadersData)
    {
        GetData(render, ref propBlock);
        foreach (var shaderData in shadersData)
        {
            propBlock.SetVector(shaderData.key, shaderData.value);
        }
        SendData();
    }

    public void UpdateProperty((string key, float value) shaderData) => UpdateProperty(new (string, float)[1] { shaderData });
    public void UpdateProperty((string key, Texture2D value) shaderData) => UpdateProperty(new (string, Texture2D)[1] { shaderData });
    public void UpdateProperty((string key, Vector2 value) shaderData) => UpdateProperty(new (string, Vector4)[1] { shaderData });
    public void UpdateProperty((string key, Vector3 value) shaderData) => UpdateProperty(new (string, Vector4)[1] { shaderData });
    public void UpdateProperty((string key, Vector4 value) shaderData) => UpdateProperty(new (string, Vector4)[1] { shaderData });
}
