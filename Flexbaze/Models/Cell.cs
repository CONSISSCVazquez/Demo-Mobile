using Xamarin.Forms;

namespace Flexbaze.Models
{
    public class Cell
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string OEE { get; set; }
        public string Status { get; set; }
        public Rectangle Progress { get; set; }
        public Metrics Metrics { get; set; }
    }
}
