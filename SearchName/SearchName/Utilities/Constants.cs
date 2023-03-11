namespace SearchName.Utilities
{
    public class Constants
    {
        public const string DatabaseFile = "Names.db";
        public const string NameSearchEndpoint = "https://nume.ottomotor.ro/get_nume.json?zoom=7&nw_lat=49.51807644873301&nw_lng=20.247802734375004&se_lat=42.261049162113856&se_lng=29.838867187500004&search=";
        public const string LocationResolveEndpoint = "https://nominatim.openstreetmap.org/reverse.php?lat={0}&lon={1}&zoom=18&format=jsonv2&email=inemedi@ie.ase.ro";

    }
}
