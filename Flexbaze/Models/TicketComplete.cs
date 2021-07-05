using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Flexbaze.Models
{
    public class TicketComplete
    {
        public string Id { get; set; }
        public CellType Cell { get; set; }
        public MachineType Machine { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime EndedAtCommitment { get; set; }
        public DateTime EndedAt { get; set; }
        public string Status { get; set; }
        public UserType ReportedBy { get; set; }
        public UserType AssignedTo { get; set; }
        public string Description { get; set; }
        public List<TicketEventType> Events { get; set; }
        public ImageSource ImgStatus { get; set; }
        public string Hour { get; set; }
        public string TextButton { get; set; }
        public string ButtonBorder { get; set; }
        public Rectangle Progress { get; set; }
        public bool IsSelected { get; set; }
        public string CmdName { get; set; }
        public Command CmdAssign { get; set; }
        public Command CmdViewDetails { get; set; }
    }
}
