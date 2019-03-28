using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonPanelController : BasePanelController {

    public Text clickCounterText;
    public Image soundImg;

    public void Start()
    {
        if (PlayerDataUtil.playerData.soundEnabled)
        {
            soundImg.sprite = SpriteManager.Instance.spriteAtlas.GetSprite("sound_on");
        }
        else
        {
            soundImg.sprite = SpriteManager.Instance.spriteAtlas.GetSprite("sound_off");
        }
    }

    public void MainMenuBtnClick()
    {
        SceneManager.LoadScene((int)SceneEnum.MenuScene);
    }

    public void LevelSelectBtnClick()
    {
        SceneManager.LoadScene((int)SceneEnum.LevelSelectScene);
    }

    public void ReplayBtnClick(bool withBackup = false)
    {
        ControllerUtil.coreController.Refresh(withBackup);
    }

    public void toogleSound()
    {
        PlayerDataUtil.playerData.soundEnabled = !PlayerDataUtil.playerData.soundEnabled;
        if (PlayerDataUtil.playerData.soundEnabled)
        {
            BackgroundMusicController.Instance.bgMusic.Play();
            soundImg.sprite = SpriteManager.Instance.spriteAtlas.GetSprite("sound_on");
        } else
        {
            BackgroundMusicController.Instance.bgMusic.Pause();
            soundImg.sprite = SpriteManager.Instance.spriteAtlas.GetSprite("sound_off");
        }
        PlayerDataUtil.SavePlayerData();
    }   
}
