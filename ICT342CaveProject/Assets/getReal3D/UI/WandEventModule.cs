
// This class is deprecated. GenericWandEventModule should be used instead.
public class WandEventModule : WandEventModuleBase {

    // name of button to use for click/submit
    public string submitButtonName = "WandButton";

    protected override bool GetSubmitButtonDown()
    {
        return getReal3D.Input.GetButtonDown(submitButtonName);
    }

    protected override bool GetSubmitButtonUp()
    {
        return getReal3D.Input.GetButtonUp(submitButtonName);
    }
}
