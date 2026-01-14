using System.Collections.Generic;
namespace ResumeApp.Models;

public record ResumeModel
{
    public ResumeBasicsModel Basics { get; set; } = default!;
    public List<ResumeEducationModel> Education { get; set; } = default!;
    public List<ResumeCertificationModel>? Certificates { get; set; }
    public List<ResumeLanguageModel> Languages { get; set; } = default!;
    public List<ResumeSkillModel>? Skills { get; set; }
    public List<ResumeWorkModel>? Work { get; set; }
}

public record ResumeWorkModel
{
    public string Company { get; set; } = default!;
    public string Position { get; set; } = default!;
    public DateOnly StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
    public string? Summary { get; set; }
}

public record ResumeSkillModel
{
    public string Name { get; set; } = default!;
    public List<ResumeSkillKeywordModel> Keywords { get; set; } = default!;
}

public record ResumeSkillKeywordModel
{
    public string Name { get; set; } = default!;
    public string? Icon { get; set; }
}

public record ResumeBasicsModel
{
    public string Name { get; set; } = default!;
    public string Label { get; set; } = default!;
    public string? Picture { get; set; }
    public string? Email { get; set; }
    public string? Repository { get; set; }
    public DateOnly BirthDate { get; set; }
}

public record ResumeEducationModel
{
    public string School { get; set; } = default!;
    public string Degree { get; set; } = default!;
    public bool Graduated { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
    public string? Description { get; set; }
}

public record ResumeCertificationModel
{
    public string Name { get; set; } = default!;
    public string Date { get; set; } = default!;
    public string Issuer { get; set; } = default!;
}

public record ResumeLanguageModel
{
    public string Name { get; set; } = default!;
    public string Level { get; set; } = default!;
}