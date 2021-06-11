using Xamarin.Forms;

namespace Flexbaze.Models
{
    public class ChatDetailMessages
    {
        public string Id { get; set; }
        public string Message { get; set; }
        public string Date { get; set; }
        public string Hour { get; set; }
        public bool IsMyMessage { get; set; }
        public Color FrameColor { get; set; }
    }
}
