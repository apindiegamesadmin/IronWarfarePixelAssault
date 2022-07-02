using UnityEngine;

public static class MenuManager
{
    public static bool IsInitialised { get; private set; }
    public static GameObject mainMenu, settingsMenu, creditsMenu;

    public static void Init()
    {
        GameObject canvas = GameObject.Find("Canvas");
        mainMenu = canvas.transform.Find("MainMenuPanel").gameObject;
        settingsMenu = canvas.transform.Find("SettingsMenuPanel").gameObject;
        //settingsMenu = canvas.transform.Find("SettingsMenuPanel").gameObject;
        IsInitialised = true;
    }

    public static void OpenMenu(Menu menu, GameObject callingMenu)
    {
        if (!IsInitialised)
        {
            Init();
        }

        switch (menu)
        {
            case Menu.MAIN_MENU:
                mainMenu.SetActive(true);
                break;
            case Menu.SETTINGS:
                settingsMenu.SetActive(true);
                break;
            case Menu.CREDITS:
                creditsMenu.SetActive(true);
                break;
        }
        callingMenu.SetActive(false);
    }
}
