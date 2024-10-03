using System;
using System.Collections.Generic;

namespace TravelBotAgent.Models;

public partial class Session
{
    public int Id { get; set; }

    public string? MobileNumber { get; set; }

    public int? QuestionId { get; set; }

    public bool? IsActive { get; set; }
}
