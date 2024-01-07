using UnityEngine;

public class SelectionHighlight : MonoBehaviour
{
    public Material highlightMaterial;
    private Material[] originalMaterials;
    Color originalColour;
    Color highlightColour;
    Color targetColour;
    float duration = 2.0f;
    float elapsedTime;

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        originalMaterials = renderer.materials.Clone() as Material[];

        originalColour = originalMaterials[1].color;
        highlightColour = new Color(highlightMaterial.color.r, highlightMaterial.color.g, highlightMaterial.color.b, 1);

        targetColour = highlightColour; //white
    }

    private void Update() {
        GraduallyHighlight();
    }

    void GraduallyHighlight()
    {
        elapsedTime += Time.deltaTime/duration;

        originalMaterials[1].color = Color.Lerp(originalMaterials[1].color, targetColour, elapsedTime);
        if(originalMaterials[1].color == targetColour)
        {
            elapsedTime = 0;
            if(originalMaterials[1].color == originalColour)
            {
                targetColour = highlightColour;
            }
            else{
                targetColour = originalColour;
            }
        }
    }
}
