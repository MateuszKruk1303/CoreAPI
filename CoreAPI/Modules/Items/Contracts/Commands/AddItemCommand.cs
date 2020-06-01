using MediatR;


namespace CoreAPI.Modules.Items 
{
    public class AddItemCommand : IRequest<Unit>
    {
        public AddItemCommand(string nazwa, string kolor, int cena)
        {
            Nazwa = nazwa;
            Kolor = kolor;
            Cena = cena;
        }
        public string Nazwa { get; set; }
        public string Kolor { get; set; }
        public int Cena { get; set; }
    }
}
