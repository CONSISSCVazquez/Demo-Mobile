using Xamarin.Forms;

namespace Flexbaze.Models
{
    public class Flexbaze_Colors
    {
        //Verde: #7DCB85
        //Rojo: #E12F3C
        //Amarillo: #F2D358
        //Gris/Celeste: #D1E0EF
        //Fondo: #EEEEEE
        public string _verde { get; private set; } = "#7dcb85";
        public string _rojo { get; private set; } = "#e12f3c";
        public string _amarillo { get; private set; } = "#f2d358";
        public string _gris { get; private set; } = "#e4e4e4";
        public string _grisVersion { get; private set; } = "#b2b2b2";
        public string _grisFondo { get;  private set; } = "#eeeeee";
        public string _grisDark { get; private set; } = "#333333";
        public string _grisOscuro { get; private set; } = "#606060";
        public string _grisClaro { get; private set; } = "#393939";
        public string _azul { get; private set; } = "#00509e";
        public Color Verde { get; private set; }
        public Color Rojo { get; private set; }
        public Color Amarillo { get; private set; }
        public Color Gris { get; private set; }
        public Color GrisFondo { get; private set; }
        public Color GrisDark { get; private set; }
        public Color GrisOscuro { get; private set; }
        public Color Azul { get; private set; }
        public Color GrisClaro { get; private set; }
        public Color GrisVersion { get; private set; }
        public Flexbaze_Colors()
        {
            Verde= Color.FromHex(_verde);
            Rojo = Color.FromHex(_rojo);
            Amarillo = Color.FromHex(_amarillo);
            Gris = Color.FromHex(_gris);
            GrisFondo= Color.FromHex(_grisFondo);
            GrisDark= Color.FromHex(_grisDark);
            GrisOscuro = Color.FromHex(_grisOscuro);
            Azul= Color.FromHex(_azul); 
            GrisClaro= Color.FromHex(_grisClaro);
            GrisVersion = Color.FromHex(_grisVersion);
        }
    }
}