# Documentation

### MonoBehaviour

MonoBehaviour is the base class from which every Unity script derives.

When you use C#, you must explicitly derive from MonoBehaviour.

[MonoBehaviour](https://docs.unity3d.com/ScriptReference/MonoBehaviour.html)

### MonoBehaviour.Start()

Start is called on the frame when a script is enabled just before any of the Update methods are called the first time.

Like the Awake function, Start is called exactly once in the lifetime of the script. However, Awake is called when the script object is initialised, regardless of whether or not the script is enabled. Start may not be called on the same frame as Awake if the script is not enabled at initialisation time.

[MonoBehaviour.Start()](https://docs.unity3d.com/ScriptReference/MonoBehaviour.Start.html)

### MonoBehaviour.Update()

Update is called every frame, if the MonoBehaviour is enabled.

Update is the most commonly used function to implement any kind of game script. Not every MonoBehaviour script needs Update.

[MonoBehaviour.Update()](https://docs.unity3d.com/ScriptReference/MonoBehaviour.Update.html)

### MonoBehaviour.FixedUpdate()

Frame-rate independent MonoBehaviour.FixedUpdate message for physics calculations.

[MonoBehaviour.FixedUpdate()](https://docs.unity3d.com/ScriptReference/MonoBehaviour.FixedUpdate.html)

### MonoBehaviour.LateUpdate()

LateUpdate is called every frame, if the Behaviour is enabled.

LateUpdate is called after all Update functions have been called. This is useful to order script execution. For example a follow camera should always be implemented in LateUpdate because it tracks objects that might have moved inside Update.

[MonoBehaviour.Awake()](https://docs.unity3d.com/ScriptReference/MonoBehaviour.Awake.html)

### MonoBehaviour.OnGUI()

OnGUI is called for rendering and handling GUI events.

OnGUI is the only function that can implement the "Immediate Mode" GUI (IMGUI) system for rendering and handling GUI events. Your OnGUI implementation might be called several times per frame (one call per event). For more information on GUI events see the Event reference. If the MonoBehaviour's enabled property is set to false, OnGUI() will not be called.

[MonoBehaviour.OnGUI()](https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnGUI.html)

### MonoBehaviour.OnDisable()

This function is called when the behaviour becomes disabled.

This is also called when the object is destroyed and can be used for any cleanup code. When scripts are reloaded after compilation has finished, OnDisable will be called, followed by an OnEnable after the script has been loaded.

[MonoBehaviour.OnDisable()](https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnDisable.html)

### MonoBehaviour.OnEnable()

This function is called when the object becomes enabled and active.

[MonoBehaviour.OnEnable()](https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnEnable.html)

### MonoBehaviour.Awake()

Awake is called when the script instance is being loaded.

Awake is called either when an active GameObject that contains the script is initialized when a Scene loads, or when a previously inactive GameObject is set to active, or after a GameObject created with Object.Instantiate is initialized. Use Awake to initialize variables or states before the application starts.

[MonoBehaviour.Awake()](https://docs.unity3d.com/ScriptReference/MonoBehaviour.Awake.html)


