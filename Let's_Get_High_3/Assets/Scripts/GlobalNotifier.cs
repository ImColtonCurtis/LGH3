using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalNotifier : MonoBehaviour
{
    public delegate void SinglePlayerButtonDown();
    public static event SinglePlayerButtonDown OnSinglePlayerButtonDown;
    public delegate void SinglePlayerButtonExit();
    public static event SinglePlayerButtonExit OnSinglePlayerButtonExit;
    public delegate void SinglePlayerButtonUp();
    public static event SinglePlayerButtonUp OnSinglePlayerButtonUp;

    public delegate void MultiplayerButtonDown();
    public static event MultiplayerButtonDown OnMultiplayerButtonDown;
    public delegate void MultiplayerButtonExit();
    public static event MultiplayerButtonExit OnMultiplayerButtonExit;
    public delegate void MultiplayerButtonUp();
    public static event MultiplayerButtonUp OnMultiplayerButtonUp;

    public delegate void OptionsButtonDown();
    public static event OptionsButtonDown OnOptionsButtonDown;
    public delegate void OptionsButtonExit();
    public static event OptionsButtonExit OnOptionsButtonExit;
    public delegate void OptionsButtonUp();
    public static event OptionsButtonUp OnOptionsButtonUp;

    public delegate void MainMenuBackButtonDown();
    public static event MainMenuBackButtonDown OnMainMenuBackButtonDown;
    public delegate void MainMenuBackButtonExit();
    public static event MainMenuBackButtonExit OnMainMenuBackButtonExit;
    public delegate void MainMenuBackButtonUp();
    public static event MainMenuBackButtonUp OnMainMenuBackButtonUp;

    public delegate void StoryButtonDown();
    public static event StoryButtonDown OnStoryButtonDown;
    public delegate void StoryButtonExit();
    public static event StoryButtonExit OnStoryButtonExit;
    public delegate void StoryButtonUp();
    public static event StoryButtonUp OnStoryButtonUp;

    public delegate void EndlessButtonDown();
    public static event EndlessButtonDown OnEndlessButtonDown;
    public delegate void EndlessButtonExit();
    public static event EndlessButtonExit OnEndlessButtonExit;
    public delegate void EndlessButtonUp();
    public static event EndlessButtonUp OnEndlessButtonUp;

    public delegate void SinglePlayerBackButtonDown();
    public static event SinglePlayerBackButtonDown OnSinglePlayerBackButtonDown;
    public delegate void SinglePlayerBackButtonExit();
    public static event SinglePlayerBackButtonExit OnSinglePlayerBackButtonExit;
    public delegate void SinglePlayerBackButtonUp();
    public static event SinglePlayerBackButtonUp OnSinglePlayerBackButtonUp;

    public delegate void EndlessPlayButtonDown();
    public static event EndlessPlayButtonDown OnEndlessPlayButtonDown;
    public delegate void EndlessPlayButtonExit();
    public static event EndlessPlayButtonExit OnEndlessPlayButtonExit;
    public delegate void EndlessPlayButtonUp();
    public static event EndlessPlayButtonUp OnEndlessPlayButtonUp;

    public delegate void EndlessBackButtonDown();
    public static event EndlessBackButtonDown OnEndlessBackButtonDown;
    public delegate void EndlessBackButtonExit();
    public static event EndlessBackButtonExit OnEndlessBackButtonExit;
    public delegate void EndlessBackButtonUp();
    public static event EndlessBackButtonUp OnEndlessBackButtonUp;

    public delegate void EndlessEndScreenPlayAgainButtonDown();
    public static event EndlessEndScreenPlayAgainButtonDown OnEndlessEndScreenPlayAgainButtonDown;
    public delegate void EndlessEndScreenPlayAgainButtonExit();
    public static event EndlessEndScreenPlayAgainButtonExit OnEndlessEndScreenPlayAgainButtonExit;
    public delegate void EndlessEndScreenPlayAgainButtonUp();
    public static event EndlessEndScreenPlayAgainButtonUp OnEndlessEndScreenPlayAgainButtonUp;

    public delegate void EndlessEndScreenHomeButtonDown();
    public static event EndlessEndScreenHomeButtonDown OnEndlessEndScreenHomeButtonDown;
    public delegate void EndlessEndScreenHomeButtonExit();
    public static event EndlessEndScreenHomeButtonExit OnEndlessEndScreenHomeButtonExit;
    public delegate void EndlessEndScreenHomeButtonUp();
    public static event EndlessEndScreenHomeButtonUp OnEndlessEndScreenHomeButtonUp;

    public delegate void PassNPlayButtonDown();
    public static event PassNPlayButtonDown OnPassNPlayButtonDown;
    public delegate void PassNPlayButtonExit();
    public static event PassNPlayButtonExit OnPassNPlayButtonExit;
    public delegate void PassNPlayButtonUp();
    public static event PassNPlayButtonUp OnPassNPlayButtonUp;

    public delegate void MultiplayerBackButtonDown();
    public static event MultiplayerBackButtonDown OnMultiplayerBackButtonDown;
    public delegate void MultiplayerBackButtonExit();
    public static event MultiplayerBackButtonExit OnMultiplayerBackButtonExit;
    public delegate void MultiplayerBackButtonUp();
    public static event MultiplayerBackButtonUp OnMultiplayerBackButtonUp;

    public delegate void TwoButtonDown();
    public static event TwoButtonDown OnTwoButtonDown;
    public delegate void TwoButtonExit();
    public static event TwoButtonExit OnTwoButtonExit;
    public delegate void TwoButtonUp();
    public static event TwoButtonUp OnTwoButtonUp;

    public delegate void ThreeButtonDown();
    public static event ThreeButtonDown OnThreeButtonDown;
    public delegate void ThreeButtonExit();
    public static event ThreeButtonExit OnThreeButtonExit;
    public delegate void ThreeButtonUp();
    public static event ThreeButtonUp OnThreeButtonUp;

    public delegate void FourButtonDown();
    public static event FourButtonDown OnFourButtonDown;
    public delegate void FourButtonExit();
    public static event FourButtonExit OnFourButtonExit;
    public delegate void FourButtonUp();
    public static event FourButtonUp OnFourButtonUp;

    public delegate void FiveButtonDown();
    public static event FiveButtonDown OnFiveButtonDown;
    public delegate void FiveButtonExit();
    public static event FiveButtonExit OnFiveButtonExit;
    public delegate void FiveButtonUp();
    public static event FiveButtonUp OnFiveButtonUp;

    public delegate void SixButtonDown();
    public static event SixButtonDown OnSixButtonDown;
    public delegate void SixButtonExit();
    public static event SixButtonExit OnSixButtonExit;
    public delegate void SixButtonUp();
    public static event SixButtonUp OnSixButtonUp;

    public delegate void SevenButtonDown();
    public static event SevenButtonDown OnSevenButtonDown;
    public delegate void SevenButtonExit();
    public static event SevenButtonExit OnSevenButtonExit;
    public delegate void SevenButtonUp();
    public static event SevenButtonUp OnSevenButtonUp;

    public delegate void EightButtonDown();
    public static event EightButtonDown OnEightButtonDown;
    public delegate void EightButtonExit();
    public static event EightButtonExit OnEightButtonExit;
    public delegate void EightButtonUp();
    public static event EightButtonUp OnEightButtonUp;

    public delegate void PlayerCountBackButtonDown();
    public static event PlayerCountBackButtonDown OnPlayerCountBackButtonDown;
    public delegate void PlayerCountBackButtonExit();
    public static event PlayerCountBackButtonExit OnPlayerCountBackButtonExit;
    public delegate void PlayerCountBackButtonUp();
    public static event PlayerCountBackButtonUp OnPlayerCountBackButtonUp;

    public delegate void OkButtonDown();
    public static event OkButtonDown OnOkButtonDown;
    public delegate void OkButtonExit();
    public static event OkButtonExit OnOkButtonExit;
    public delegate void OkButtonUp();
    public static event OkButtonUp OnOkButtonUp;

    public delegate void OptionsBackButtonDown();
    public static event OptionsBackButtonDown OnOptionsBackButtonDown;
    public delegate void OptionsBackButtonExit();
    public static event OptionsBackButtonExit OnOptionsBackButtonExit;
    public delegate void OptionsBackButtonUp();
    public static event OptionsBackButtonUp OnOptionsBackButtonUp;

    public delegate void ApplyButtonDown();
    public static event ApplyButtonDown OnApplyButtonDown;
    public delegate void ApplyButtonExit();
    public static event ApplyButtonExit OnApplyButtonExit;
    public delegate void ApplyButtonUp();
    public static event ApplyButtonUp OnApplyButtonUp;

    public delegate void PlayAgainButtonDown();
    public static event PlayAgainButtonDown OnPlayAgainButtonDown;
    public delegate void PlayAgainButtonExit();
    public static event PlayAgainButtonExit OnPlayAgainButtonExit;
    public delegate void PlayAgainButtonUp();
    public static event PlayAgainButtonUp OnPlayAgainButtonUp;

    public delegate void PostGameBackButtonDown();
    public static event PostGameBackButtonDown OnPostGameBackButtonDown;
    public delegate void PostGameBackButtonExit();
    public static event PostGameBackButtonExit OnPostGameBackButtonExit;
    public delegate void PostGameBackButtonUp();
    public static event PostGameBackButtonUp OnPostGameBackButtonUp;

    public delegate void PlayStoryButtonDown();
    public static event PlayStoryButtonDown OnPlayStoryButtonDown;
    public delegate void PlayStoryButtonExit();
    public static event PlayStoryButtonExit OnPlayStoryButtonExit;
    public delegate void PlayStoryButtonUp();
    public static event PlayStoryButtonUp OnPlayStoryButtonUp;

    public delegate void HomeStoryButtonDown();
    public static event HomeStoryButtonDown OnHomeStoryButtonDown;
    public delegate void HomeStoryButtonExit();
    public static event HomeStoryButtonExit OnHomeStoryButtonExit;
    public delegate void HomeStoryButtonUp();
    public static event HomeStoryButtonUp OnHomeStoryButtonUp;

    public delegate void SettingsStoryButtonDown();
    public static event SettingsStoryButtonDown OnSettingsStoryButtonDown;
    public delegate void SettingsStoryButtonExit();
    public static event SettingsStoryButtonExit OnSettingsStoryButtonExit;
    public delegate void SettingsStoryButtonUp();
    public static event SettingsStoryButtonUp OnSettingsStoryButtonUp;

    #region Single Player Button
    public static void OnSinglePlayerButtonDowned()
    {
        OnSinglePlayerButtonDown?.Invoke();
    }

    public static void OnSinglePlayerButtonExited()
    {
        OnSinglePlayerButtonExit?.Invoke();
    }

    public static void OnSinglePlayerButtonUpd()
    {
        OnSinglePlayerButtonUp?.Invoke();
    }
    #endregion

    #region Multiplayer Button
    public static void OnMultiplayerButtonDowned()
    {
        OnMultiplayerButtonDown?.Invoke();
    }

    public static void OnMultiplayerButtonExited()
    {
        OnMultiplayerButtonExit?.Invoke();
    }

    public static void OnMultiplayerButtonUpd()
    {
        OnMultiplayerButtonUp?.Invoke();
    }
    #endregion

    #region Options Button
    public static void OnOptionsButtonDowned()
    {
        OnOptionsButtonDown?.Invoke();
    }

    public static void OnOptionsButtonExited()
    {
        OnOptionsButtonExit?.Invoke();
    }

    public static void OnOptionsButtonUpd()
    {
        OnOptionsButtonUp?.Invoke();
    }
    #endregion

    #region Main Menu Back Button
    public static void OnMainMenuBackButtonDowned()
    {
        OnMainMenuBackButtonDown?.Invoke();
    }

    public static void OnMainMenuBackButtonExited()
    {
        OnMainMenuBackButtonExit?.Invoke();
    }

    public static void OnMainMenuBackButtonUpd()
    {
        OnMainMenuBackButtonUp?.Invoke();
    }
    #endregion

    #region Story Button
    public static void OnStoryButtonDowned()
    {
        OnStoryButtonDown?.Invoke();
    }

    public static void OnStoryButtonExited()
    {
        OnStoryButtonExit?.Invoke();
    }

    public static void OnStoryButtonUpd()
    {
        OnStoryButtonUp?.Invoke();
    }
    #endregion

    #region Endless Button
    public static void OnEndlessButtonDowned()
    {
        OnEndlessButtonDown?.Invoke();
    }

    public static void OnEndlessButtonExited()
    {
        OnEndlessButtonExit?.Invoke();
    }

    public static void OnEndlessButtonUpd()
    {
        OnEndlessButtonUp?.Invoke();
    }
    #endregion

    #region Endless End Screen Play Again Button
    public static void OnEndlessEndScreenPlayAgainButtonDowned()
    {
        OnEndlessEndScreenPlayAgainButtonDown?.Invoke();
    }

    public static void OnEndlessEndScreenPlayAgainButtonExited()
    {
        OnEndlessEndScreenPlayAgainButtonExit?.Invoke();
    }

    public static void OnEndlessEndScreenPlayAgainButtonUpd()
    {
        OnEndlessEndScreenPlayAgainButtonUp?.Invoke();
    }
    #endregion

    #region Endless End Screen Home Button
    public static void OnEndlessEndScreenHomeButtonDowned()
    {
        OnEndlessEndScreenHomeButtonDown?.Invoke();
    }

    public static void OnEndlessEndScreenHomeButtonExited()
    {
        OnEndlessEndScreenHomeButtonExit?.Invoke();
    }

    public static void OnEndlessEndScreenHomeButtonUpd()
    {
        OnEndlessEndScreenHomeButtonUp?.Invoke();
    }
    #endregion

    #region Single Player Back Button
    public static void OnSinglePlayerBackButtonDowned()
    {
        OnSinglePlayerBackButtonDown?.Invoke();
    }

    public static void OnSinglePlayerBackButtonExited()
    {
        OnSinglePlayerBackButtonExit?.Invoke();
    }

    public static void OnSinglePlayerBackButtonUpd()
    {
        OnSinglePlayerBackButtonUp?.Invoke();
    }
    #endregion

    #region Endless Play Button
    public static void OnEndlessPlayButtonDowned()
    {
        OnEndlessPlayButtonDown?.Invoke();
    }

    public static void OnEndlessPlayButtonExited()
    {
        OnEndlessPlayButtonExit?.Invoke();
    }

    public static void OnEndlessPlayButtonUpd()
    {
        OnEndlessPlayButtonUp?.Invoke();
    }
    #endregion

    #region Endless Back Button
    public static void OnEndlessBackButtonDowned()
    {
        OnEndlessBackButtonDown?.Invoke();
    }

    public static void OnEndlessBackButtonExited()
    {
        OnEndlessBackButtonExit?.Invoke();
    }

    public static void OnEndlessBackButtonUpd()
    {
        OnEndlessBackButtonUp?.Invoke();
    }
    #endregion

    #region Pass 'N Play Button
    public static void OnPassNPlayButtonDowned()
    {
        OnPassNPlayButtonDown?.Invoke();
    }

    public static void OnPassNPlayButtonExited()
    {
        OnPassNPlayButtonExit?.Invoke();
    }

    public static void OnPassNPlayButtonUpd()
    {
        OnPassNPlayButtonUp?.Invoke();
    }
    #endregion

    #region Multiplayer Back Button
    public static void OnMultiplayerBackButtonDowned()
    {
        OnMultiplayerBackButtonDown?.Invoke();
    }

    public static void OnMultiplayerBackButtonExited()
    {
        OnMultiplayerBackButtonExit?.Invoke();
    }

    public static void OnMultiplayerBackButtonUpd()
    {
        OnMultiplayerBackButtonUp?.Invoke();
    }
    #endregion

    #region Two Button
    public static void OnTwoButtonDowned()
    {
        OnTwoButtonDown?.Invoke();
    }

    public static void OnTwoButtonExited()
    {
        OnTwoButtonExit?.Invoke();
    }

    public static void OnTwoButtonUpd()
    {
        OnTwoButtonUp?.Invoke();
    }
    #endregion

    #region Three Button
    public static void OnThreeButtonDowned()
    {
        OnThreeButtonDown?.Invoke();
    }

    public static void OnThreeButtonExited()
    {
        OnThreeButtonExit?.Invoke();
    }

    public static void OnThreeButtonUpd()
    {
        OnThreeButtonUp?.Invoke();
    }
    #endregion

    #region Four Button
    public static void OnFourButtonDowned()
    {
        OnFourButtonDown?.Invoke();
    }

    public static void OnFourButtonExited()
    {
        OnFourButtonExit?.Invoke();
    }

    public static void OnFourButtonUpd()
    {
        OnFourButtonUp?.Invoke();
    }
    #endregion

    #region Five Button
    public static void OnFiveButtonDowned()
    {
        OnFiveButtonDown?.Invoke();
    }

    public static void OnFiveButtonExited()
    {
        OnFiveButtonExit?.Invoke();
    }

    public static void OnFiveButtonUpd()
    {
        OnFiveButtonUp?.Invoke();
    }
    #endregion

    #region Six Button
    public static void OnSixButtonDowned()
    {
        OnSixButtonDown?.Invoke();
    }

    public static void OnSixButtonExited()
    {
        OnSixButtonExit?.Invoke();
    }

    public static void OnSixButtonUpd()
    {
        OnSixButtonUp?.Invoke();
    }
    #endregion

    #region Seven Button
    public static void OnSevenButtonDowned()
    {
        OnSevenButtonDown?.Invoke();
    }

    public static void OnSevenButtonExited()
    {
        OnSevenButtonExit?.Invoke();
    }

    public static void OnSevenButtonUpd()
    {
        OnSevenButtonUp?.Invoke();
    }
    #endregion

    #region Eight Button
    public static void OnEightButtonDowned()
    {
        OnEightButtonDown?.Invoke();
    }

    public static void OnEightButtonExited()
    {
        OnEightButtonExit?.Invoke();
    }

    public static void OnEightButtonUpd()
    {
        OnEightButtonUp?.Invoke();
    }
    #endregion

    #region Player Count Back Button
    public static void OnPlayerCountBackButtonDowned()
    {
        OnPlayerCountBackButtonDown?.Invoke();
    }

    public static void OnPlayerCountBackButtonExited()
    {
        OnPlayerCountBackButtonExit?.Invoke();
    }

    public static void OnPlayerCountBackButtonUpd()
    {
        OnPlayerCountBackButtonUp?.Invoke();
    }
    #endregion

    #region Ok Button
    public static void OnOkButtonDowned()
    {
        OnOkButtonDown?.Invoke();
    }

    public static void OnOkButtonExited()
    {
        OnOkButtonExit?.Invoke();
    }

    public static void OnOkButtonUpd()
    {
        OnOkButtonUp?.Invoke();
    }
    #endregion

    #region Options Back Button
    public static void OnOptionsBackButtonDowned()
    {
        OnOptionsBackButtonDown?.Invoke();
    }

    public static void OnOptionsBackButtonExited()
    {
        OnOptionsBackButtonExit?.Invoke();
    }

    public static void OnOptionsBackButtonUpd()
    {
        OnOptionsBackButtonUp?.Invoke();
    }
    #endregion

    #region Apply Button
    public static void OnApplyButtonDowned()
    {
        OnApplyButtonDown?.Invoke();
    }

    public static void OnApplyButtonExited()
    {
        OnApplyButtonExit?.Invoke();
    }

    public static void OnApplyButtonUpd()
    {
        OnApplyButtonUp?.Invoke();
    }
    #endregion

    #region Play Again Button
    public static void OnPlayAgainButtonDowned()
    {
        OnPlayAgainButtonDown?.Invoke();
    }

    public static void OnPlayAgainButtonExited()
    {
        OnPlayAgainButtonExit?.Invoke();
    }

    public static void OnPlayAgainButtonUpd()
    {
        OnPlayAgainButtonUp?.Invoke();
    }
    #endregion

    #region Post Game Back Button
    public static void OnPostGameBackButtonDowned()
    {
        OnPostGameBackButtonDown?.Invoke();
    }

    public static void OnPostGameBackButtonExited()
    {
        OnPostGameBackButtonExit?.Invoke();
    }

    public static void OnPostGameBackButtonUpd()
    {
        OnPostGameBackButtonUp?.Invoke();
    }
    #endregion

    #region Play Story Button
    public static void OnPlayStoryButtonDowned()
    {
        OnPlayStoryButtonDown?.Invoke();
    }

    public static void OnPlayStoryButtonExited()
    {
        OnPlayStoryButtonExit?.Invoke();
    }

    public static void OnPlayStoryButtonUpd()
    {
        OnPlayStoryButtonUp?.Invoke();
    }
    #endregion

    #region Home Story Button
    public static void OnHomeStoryButtonDowned()
    {
        OnHomeStoryButtonDown?.Invoke();
    }

    public static void OnHomeStoryButtonExited()
    {
        OnHomeStoryButtonExit?.Invoke();
    }

    public static void OnHomeStoryButtonUpd()
    {
        OnHomeStoryButtonUp?.Invoke();
    }
    #endregion

    #region Settings Story Button
    public static void OnSettingsStoryButtonDowned()
    {
        OnSettingsStoryButtonDown?.Invoke();
    }

    public static void OnSettingsStoryButtonExited()
    {
        OnSettingsStoryButtonExit?.Invoke();
    }

    public static void OnSettingsStoryButtonUpd()
    {
        OnSettingsStoryButtonUp?.Invoke();
    }
    #endregion
}

