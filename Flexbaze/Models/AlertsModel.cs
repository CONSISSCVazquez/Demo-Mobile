using Newtonsoft.Json;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Flexbaze.Models
{
    class AlertsModel
    {
        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; set; }
        [JsonProperty("msg", NullValueHandling = NullValueHandling.Ignore)]
        public string Msg { get; set; }
        [JsonProperty("result", NullValueHandling = NullValueHandling.Ignore)]
        public List<Alerts> Result { get; set; } = new List<Alerts>();
    }
    public class Alerts
    {
        [JsonProperty("hora", NullValueHandling = NullValueHandling.Ignore)]
        public string Hora { get; set; }
        [JsonProperty("fecha", NullValueHandling = NullValueHandling.Ignore)]
        public string Fecha { get; set; }
        [JsonProperty("actualizado", NullValueHandling= NullValueHandling.Ignore)]
        public string Actualizado { get; set; }
        [JsonProperty("msgCard", NullValueHandling = NullValueHandling.Ignore)]
        public string MsgCard { get; set; }
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status {get;set;}
        [JsonProperty("stampFin", NullValueHandling = NullValueHandling.Ignore)]
        public string StampFin { get; set; }
        [JsonProperty("stampIni", NullValueHandling = NullValueHandling.Ignore)]
        public string StampIni { get; set; }
        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }
        [JsonProperty("node", NullValueHandling = NullValueHandling.Ignore)]
        public string Node { get; set; }
        [JsonProperty("timeLapse", NullValueHandling = NullValueHandling.Ignore)]
        public string TimeLapse { get; set; }
        [JsonProperty("activo", NullValueHandling = NullValueHandling.Ignore)]
        public string Activo { get; set; }
        [JsonProperty("icon", NullValueHandling = NullValueHandling.Ignore)]
        public string Icon { get; set; }
        [JsonProperty("responsable", NullValueHandling = NullValueHandling.Ignore)]
        public string Responsable { get; set; }
        [JsonProperty("responsableNode", NullValueHandling = NullValueHandling.Ignore)]
        public string ResponsableNode { get; set; }
        [JsonProperty("isNew", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsNew { get; set; }
        [JsonProperty("listaEnviados", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> listaEnviados { get; set; }
        [JsonProperty("listaLeidos", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> listaLeidos { get; set; }
        public Command GetDetail { get; set; }
        public Command CmdSwipe { get; set; }
        [JsonProperty("msgCount", NullValueHandling = NullValueHandling.Ignore)]
        public string MsgCount { get; set; }
        [JsonIgnore]
        public bool HasMessages { get; set; }
    }
}
