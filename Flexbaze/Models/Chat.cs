using Xamarin.Forms;

namespace Flexbaze.Models
{
    public class Chat
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string Date { get; set; }
        public string Hour { get; set; }
        public string Status { get; set; }
        public int QtyMsgNew { get; set; }
        public bool HasNewMessages { get; set; }
        public string Body { get; set; }
        public bool IsWriting { get; set; }
        public Color BodyColor { get; set; }
    }
}
