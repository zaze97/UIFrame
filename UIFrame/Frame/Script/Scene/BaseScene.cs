public interface IBaseScene
{
    /// <summary>
    /// 场景进入时侯执行的操作
    /// </summary>
    void OnEnter();
    /// <summary>
    /// 场景退出时执行的操作
    /// </summary>
    void OnExit();
}
/// <summary>
/// 场景状态
/// </summary>
public abstract class BaseScene: IBaseScene
{

    public abstract void OnEnter();
    public abstract void OnExit();


}
