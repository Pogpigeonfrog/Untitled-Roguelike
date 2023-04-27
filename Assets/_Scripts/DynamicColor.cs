using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicColor : MonoBehaviour
{

    void OnEnable() {
        if (TryGetComponent<SpriteRenderer>(out SpriteRenderer sprite))
        {
            sprite.color = DynamicColorManager.Instance.Color;
        } else if (TryGetComponent<ParticleSystem>(out ParticleSystem particles))
        {
            ParticleSystem.MainModule main =  particles.main;
            main.startColor = DynamicColorManager.Instance.Color;
        } else if (TryGetComponent<LineRenderer>(out LineRenderer line))
        {
            line.startColor = DynamicColorManager.Instance.Color;
            line.endColor = DynamicColorManager.Instance.Color;
        } else if (TryGetComponent<Image>(out Image image))
        {
            image.color = DynamicColorManager.Instance.Color;
        } else if (TryGetComponent<RawImage>(out RawImage rawImage))
        {
            rawImage.color = DynamicColorManager.Instance.Color;
        } else if (TryGetComponent<TrailRenderer>(out TrailRenderer trail))
        {
            trail.startColor = DynamicColorManager.Instance.Color;
            trail.endColor = DynamicColorManager.Instance.Color;
        }
    }

}
