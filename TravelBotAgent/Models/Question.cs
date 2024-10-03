using System;
using System.Collections.Generic;

namespace TravelBotAgent.Models;

public partial class Question
{
    public int Id { get; set; }

    public string? QuestionData { get; set; }

    public int? Respones { get; set; }

    public int? Respones1 { get; set; }

    public int? Respones2 { get; set; }
}
