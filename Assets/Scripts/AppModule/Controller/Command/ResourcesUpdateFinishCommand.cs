using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

public class ResourcesUpdateFinishCommand : MacroCommand
{
    override protected void InitializeMacroCommand()
    {
        base.InitializeMacroCommand();

        AddSubCommand(typeof(StartLuaCommand));
    }
}