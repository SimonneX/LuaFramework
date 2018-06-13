using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

public class ResourcesUpdateCommand : MacroCommand
{
    override protected void InitializeMacroCommand()
    {
        base.InitializeMacroCommand();

        AddSubCommand(typeof(ShowResourcesUpdateCommand));
        AddSubCommand(typeof(StartCheckResourcesCommand));
    }
}