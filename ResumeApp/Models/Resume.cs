using System.Collections.Generic;
namespace ResumeApp.Models;

public record ResumeModel
{
    public ResumeBasicsModel Basics { get; set; }
    public List<ResumeEducationModel> Education { get; set; }
    public List<ResumeCertificationModel>? Certificates { get; set; }
    public List<ResumeLanguageModel> Languages { get; set; }
}

public record ResumeBasicsModel
{
    public string Name { get; set; }
    public string Label { get; set; }
    public string? Picture { get; set; }
    public string? Email { get; set; }
    public DateOnly BirthDate { get; set; }
}

public record ResumeEducationModel
{
    public string School { get; set; }
    public string Degree { get; set; }
    public bool Graduated { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
    public string? Description { get; set; }
}

public record ResumeCertificationModel
{
    public string Name { get; set; }
    public string Date { get; set; }
    public string Issuer { get; set; }
}

public record ResumeLanguageModel
{
    public string Name { get; set; }
    public string Level { get; set; }
}