namespace Application.ViewModels.Company;

public class VmCreateCompany
{
    public string Name { get; set; }
    public bool Status { get; set; }
    public TimeSpan OrderPermitStartTime { get; set; }
    public TimeSpan OrderPermitFinishTime { get; set; }
}