namespace Boozio.Appify.Core.Models
{
    public class Whiskey
    {
        public Whiskey(
            ulong id,
            string name,
            string distiller,
            uint abv,
            Type type,
            byte[] image
        )
        {
            Id = id;
            Name = name;
            Distiller = distiller;
            Abv = abv;
            Type = type;
            Image = image;
        }

        public ulong Id { get; }
        public string Name { get; }
        public string Distiller { get; }
        public uint Abv { get; }
        public Type Type { get; }
        public byte[] Image { get; }
    }
}
