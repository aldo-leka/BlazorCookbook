namespace Chapter_5_Managing_Application_State.Client.Recipe03;

public abstract record StateArgs;
public record SuccessArgs : StateArgs;
public record FailureArgs : StateArgs;