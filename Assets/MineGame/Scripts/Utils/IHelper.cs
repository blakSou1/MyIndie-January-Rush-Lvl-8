using UnityEngine;

[CreateAssetMenu(fileName = "IHelper", menuName = "IHelper")]
public class IHelper : ScriptableObject
{
    float modifVolume = 0;

    public void SetRu()
    {
        G.LocSystem.SetLaungie(LocSystem.LANG_RU);
        UpdateLan();
    }
    public void SetEn()
    {
        G.LocSystem.SetLaungie(LocSystem.LANG_EN);
        UpdateLan();
    }
    private void UpdateLan()
    {
        G.LocSystem.UpdateTexts();
    }

    public void LoadScene(string line)
    {
        G.SceneLoader.Load(line);
    }

    public void ShowSettingPanel()
    {
        G.pausePanel.UpdatePanels();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void StartMusic(AudioClip clip)
    {
        G.AudioManager.PlayMusic(clip);
    }

    public void SetModVolume(float volume)
    {
        modifVolume = volume;
    }

    public void PlaySound(AudioClip clip)
    {
        clip.PlayAsSound(modifVolume: modifVolume);
        modifVolume = 0;
    }
}
