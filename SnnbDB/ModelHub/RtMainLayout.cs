namespace SnnbDB.ModelExt;
public class RtMainLayout
{
    public DateTime DateTimeStamp { get; set; } = DateTime.Now;
    public bool AutoSwitch { get; set; } = false;

    public static RtMainLayout GetRtLayout(RtSnapShot rtStatus)
    {
        return new RtMainLayout() { DateTimeStamp = rtStatus.DateTimeStamp } ;
    }
}
