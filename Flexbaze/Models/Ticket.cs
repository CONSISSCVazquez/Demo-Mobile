using Xamarin.Forms;

namespace Flexbaze.Models
{
    public class Ticket
    {
        public string Id { get; set; }
        public string Status { get; set; }
        public ImageSource ImgStatus { get; set; }
        public string Description { get; set; }
        public string Hour { get; set; }
        public string Machine { get; set; }
        public string OEE { get; set; }
        public string Cell { get; set; }
        public string TextButton { get; set; }
        public string ButtonBorder { get; set; }
        public Rectangle Progress { get; set; }
        public bool IsSelected { get; set; }
        public string CmdName { get; set; }
        public Command CmdButton { get; set; }
    }
}
