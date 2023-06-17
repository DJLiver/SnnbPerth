 namespace SnnbFailover.Server.Models.SNNBStatus;

public class SNNBStatus
{
    public DateTime DateTime { get; set; }
    public List<Site1Status> Site1Status { get; set; }
    public List<Site2Status> Site2Status { get; set; }
    public List<SiteAttrLimit> SiteAttrLimit { get; set; }
}
