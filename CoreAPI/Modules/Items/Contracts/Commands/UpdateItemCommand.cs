using MediatR;


namespace CoreAPI.Modules.Items
{
    public class UpdateItemCommand : IRequest<Unit>
    {
        public UpdateItemCommand(int id, string nazwa, string kolor, int cena)
        {
            Nazwa = nazwa;
            Kolor = kolor;
            Cena = cena;
            Id = id;
        }
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Kolor { get; set; }
        public int Cena { get; set; }
    }
}
