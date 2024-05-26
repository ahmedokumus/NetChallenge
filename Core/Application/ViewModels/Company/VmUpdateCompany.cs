namespace Application.ViewModels.Company;

public class VmUpdateCompany
{
    public Guid Id { get; set; }
    public bool Status { get; set; }
    public TimeSpan OrderPermitStartTime { get; set; }
    public TimeSpan OrderPermitFinishTime { get; set; }
}