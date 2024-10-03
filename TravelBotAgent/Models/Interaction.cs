using System;
using System.Collections.Generic;

namespace TravelBotAgent.Models;

public partial class Interaction
{
    public int Id { get; set; }

    public string? MobileNumber { get; set; }

    public string? IncomingMessage { get; set; }

    public string? OutGoingMessage { get; set; }
}
