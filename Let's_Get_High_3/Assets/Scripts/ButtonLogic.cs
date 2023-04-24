using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class ButtonLogic : MonoBehaviour
{
    bool pressed;

    private void OnEnable()
    {
        pressed = false;
    }

    void OnTouchDown()
    {
        pressed = true;
        Invoke(transform.name + "Downed", 0f);
    }

    void OnTouchExit()
    {
        if (pressed)
        {
            Invoke(transform.name + "Exited", 0f);
            pressed = false;
        }
    }

    void OnTouchUp()
    {
        if (pressed)
        {
            Invoke(transform.name + "Upd", 0f);
            pressed = false;
        }
    }


    #region Single Player Button
    void SinglePlayerButtonDowned()
    {
        GlobalNotifier.OnSinglePlayerButtonDowned();
    }
    void SinglePlayerButtonExited()
    {
        GlobalNotifier.OnSinglePlayerButtonExited();
    }
    void SinglePlayerButtonUpd()
    {
        GlobalNotifier.OnSinglePlayerButtonUpd();
    }
    #endregion

    #region Multiplayer Button
    void MultiplayerButtonDowned()
    {
        GlobalNotifier.OnMultiplayerButtonDowned();
    }
    void MultiplayerButtonExited()
    {
        GlobalNotifier.OnMultiplayerButtonExited();
    }
    void MultiplayerButtonUpd()
    {
        GlobalNotifier.OnMultiplayerButtonUpd();
    }
    #endregion

    #region Options Button
    void OptionsButtonDowned()
    {
        GlobalNotifier.OnOptionsButtonDowned();
    }
    void OptionsButtonExited()
    {
        GlobalNotifier.OnOptionsButtonExited();
    }
    void OptionsButtonUpd()
    {
        GlobalNotifier.OnOptionsButtonUpd();
    }
    #endregion

    #region Main Menu Back Button
    void MainMenuBackButtonDowned()
    {
        GlobalNotifier.OnMainMenuBackButtonDowned();
    }
    void MainMenuBackButtonExited()
    {
        GlobalNotifier.OnMainMenuBackButtonExited();
    }
    void MainMenuBackButtonUpd()
    {
        GlobalNotifier.OnMainMenuBackButtonUpd();
    }
    #endregion

    #region Story Button
    void StoryButtonDowned()
    {
        GlobalNotifier.OnStoryButtonDowned();
    }
    void StoryButtonExited()
    {
        GlobalNotifier.OnStoryButtonExited();
    }
    void StoryButtonUpd()
    {
        GlobalNotifier.OnStoryButtonUpd();
    }
    #endregion

    #region Endless Button
    void EndlessButtonDowned()
    {
        GlobalNotifier.OnEndlessButtonDowned();
    }
    void EndlessButtonExited()
    {
        GlobalNotifier.OnEndlessButtonExited();
    }
    void EndlessButtonUpd()
    {
        GlobalNotifier.OnEndlessButtonUpd();
    }
    #endregion

    #region Single Player Back Button
    void SinglePlayerBackButtonDowned()
    {
        GlobalNotifier.OnSinglePlayerBackButtonDowned();
    }
    void SinglePlayerBackButtonExited()
    {
        GlobalNotifier.OnSinglePlayerBackButtonExited();
    }
    void SinglePlayerBackButtonUpd()
    {
        GlobalNotifier.OnSinglePlayerBackButtonUpd();
    }
    #endregion

    #region Endless Play Button
    void EndlessPlayButtonDowned()
    {
        GlobalNotifier.OnEndlessPlayButtonDowned();
    }
    void EndlessPlayButtonExited()
    {
        GlobalNotifier.OnEndlessPlayButtonExited();
    }
    void EndlessPlayButtonUpd()
    {
        GlobalNotifier.OnEndlessPlayButtonUpd();
    }
    #endregion

    #region Endless End Screen Play Again Button
    void EndlessEndScreenPlayAgainButtonDowned()
    {
        GlobalNotifier.OnEndlessEndScreenPlayAgainButtonDowned();
    }
    void EndlessEndScreenPlayAgainButtonExited()
    {
        GlobalNotifier.OnEndlessEndScreenPlayAgainButtonExited();
    }
    void EndlessEndScreenPlayAgainButtonUpd()
    {
        GlobalNotifier.OnEndlessEndScreenPlayAgainButtonUpd();
    }
    #endregion

    #region Endless End Screen Home Button
    void EndlessEndScreenHomeButtonDowned()
    {
        GlobalNotifier.OnEndlessEndScreenHomeButtonDowned();
    }
    void EndlessEndScreenHomeButtonExited()
    {
        GlobalNotifier.OnEndlessEndScreenHomeButtonExited();
    }
    void EndlessEndScreenHomeButtonUpd()
    {
        GlobalNotifier.OnEndlessEndScreenHomeButtonUpd();
    }
    #endregion

    #region Endless Back Button
    void EndlessBackButtonDowned()
    {
        GlobalNotifier.OnEndlessBackButtonDowned();
    }
    void EndlessBackButtonExited()
    {
        GlobalNotifier.OnEndlessBackButtonExited();
    }
    void EndlessBackButtonUpd()
    {
        GlobalNotifier.OnEndlessBackButtonUpd();
    }
    #endregion

    #region Pass 'N Play Button
    void PassNPlayButtonDowned()
    {
        GlobalNotifier.OnPassNPlayButtonDowned();
    }
    void PassNPlayButtonExited()
    {
        GlobalNotifier.OnPassNPlayButtonExited();
    }
    void PassNPlayButtonUpd()
    {
        GlobalNotifier.OnPassNPlayButtonUpd();
    }
    #endregion

    #region Multiplayer Back Button
    void MultiplayerBackButtonDowned()
    {
        GlobalNotifier.OnMultiplayerBackButtonDowned();
    }
    void MultiplayerBackButtonExited()
    {
        GlobalNotifier.OnMultiplayerBackButtonExited();
    }
    void MultiplayerBackButtonUpd()
    {
        GlobalNotifier.OnMultiplayerBackButtonUpd();
    }
    #endregion

    #region Two Button
    void TwoButtonDowned()
    {
        GlobalNotifier.OnTwoButtonDowned();
    }
    void TwoButtonExited()
    {
        GlobalNotifier.OnTwoButtonExited();
    }
    void TwoButtonUpd()
    {
        GlobalNotifier.OnTwoButtonUpd();
    }
    #endregion

    #region Three Button
    void ThreeButtonDowned()
    {
        GlobalNotifier.OnThreeButtonDowned();
    }
    void ThreeButtonExited()
    {
        GlobalNotifier.OnThreeButtonExited();
    }
    void ThreeButtonUpd()
    {
        GlobalNotifier.OnThreeButtonUpd();
    }
    #endregion

    #region Four Button
    void FourButtonDowned()
    {
        GlobalNotifier.OnFourButtonDowned();
    }
    void FourButtonExited()
    {
        GlobalNotifier.OnFourButtonExited();
    }
    void FourButtonUpd()
    {
        GlobalNotifier.OnFourButtonUpd();
    }
    #endregion

    #region Five Button
    void FiveButtonDowned()
    {
        GlobalNotifier.OnFiveButtonDowned();
    }
    void FiveButtonExited()
    {
        GlobalNotifier.OnFiveButtonExited();
    }
    void FiveButtonUpd()
    {
        GlobalNotifier.OnFiveButtonUpd();
    }
    #endregion

    #region Six Button
    void SixButtonDowned()
    {
        GlobalNotifier.OnSixButtonDowned();
    }
    void SixButtonExited()
    {
        GlobalNotifier.OnSixButtonExited();
    }
    void SixButtonUpd()
    {
        GlobalNotifier.OnSixButtonUpd();
    }
    #endregion

    #region Seven Button
    void SevenButtonDowned()
    {
        GlobalNotifier.OnSevenButtonDowned();
    }
    void SevenButtonExited()
    {
        GlobalNotifier.OnSevenButtonExited();
    }
    void SevenButtonUpd()
    {
        GlobalNotifier.OnSevenButtonUpd();
    }
    #endregion

    #region Eight Button
    void EightButtonDowned()
    {
        GlobalNotifier.OnEightButtonDowned();
    }
    void EightButtonExited()
    {
        GlobalNotifier.OnEightButtonExited();
    }
    void EightButtonUpd()
    {
        GlobalNotifier.OnEightButtonUpd();
    }
    #endregion

    #region Player Count Back Button
    void PlayerCountBackButtonDowned()
    {
        GlobalNotifier.OnPlayerCountBackButtonDowned();
    }
    void PlayerCountBackButtonExited()
    {
        GlobalNotifier.OnPlayerCountBackButtonExited();
    }
    void PlayerCountBackButtonUpd()
    {
        GlobalNotifier.OnPlayerCountBackButtonUpd();
    }
    #endregion

    #region Ok Button
    void OkButtonDowned()
    {
        GlobalNotifier.OnOkButtonDowned();
    }
    void OkButtonExited()
    {
        GlobalNotifier.OnOkButtonExited();
    }
    void OkButtonUpd()
    {
        GlobalNotifier.OnOkButtonUpd();
    }
    #endregion

    #region Options Back Button
    void OptionsBackButtonDowned()
    {
        GlobalNotifier.OnOptionsBackButtonDowned();
    }
    void OptionsBackButtonExited()
    {
        GlobalNotifier.OnOptionsBackButtonExited();
    }
    void OptionsBackButtonUpd()
    {
        GlobalNotifier.OnOptionsBackButtonUpd();
    }
    #endregion

    #region Apply Button
    void ApplyButtonDowned()
    {
        GlobalNotifier.OnApplyButtonDowned();
    }
    void ApplyButtonExited()
    {
        GlobalNotifier.OnApplyButtonExited();
    }
    void ApplyButtonUpd()
    {
        GlobalNotifier.OnApplyButtonUpd();
    }
    #endregion

    #region Play Again Button
    void PlayAgainButtonDowned()
    {
        GlobalNotifier.OnPlayAgainButtonDowned();
    }
    void PlayAgainButtonExited()
    {
        GlobalNotifier.OnPlayAgainButtonExited();
    }
    void PlayAgainButtonUpd()
    {
        GlobalNotifier.OnPlayAgainButtonUpd();
    }
    #endregion

    #region PostGameBack Button
    void PostGameBackButtonDowned()
    {
        GlobalNotifier.OnPostGameBackButtonDowned();
    }
    void PostGameBackButtonExited()
    {
        GlobalNotifier.OnPostGameBackButtonExited();
    }
    void PostGameBackButtonUpd()
    {
        GlobalNotifier.OnPostGameBackButtonUpd();
    }
    #endregion

    #region Player Story Button
    void PlayStoryButtonDowned()
    {
        GlobalNotifier.OnPlayStoryButtonDowned();
    }
    void PlayStoryButtonExited()
    {
        GlobalNotifier.OnPlayStoryButtonExited();
    }
    void PlayStoryButtonUpd()
    {
        GlobalNotifier.OnPlayStoryButtonUpd();
    }
    #endregion

    #region Home Story Button
    void HomeStoryButtonDowned()
    {
        GlobalNotifier.OnHomeStoryButtonDowned();
    }
    void HomeStoryButtonExited()
    {
        GlobalNotifier.OnHomeStoryButtonExited();
    }
    void HomeStoryButtonUpd()
    {
        GlobalNotifier.OnHomeStoryButtonUpd();
    }
    #endregion

    #region Settings Story Button
    void SettingsStoryButtonDowned()
    {
        GlobalNotifier.OnSettingsStoryButtonDowned();
    }
    void SettingsStoryButtonExited()
    {
        GlobalNotifier.OnSettingsStoryButtonExited();
    }
    void SettingsStoryButtonUpd()
    {
        GlobalNotifier.OnSettingsStoryButtonUpd();
    }
    #endregion
}
