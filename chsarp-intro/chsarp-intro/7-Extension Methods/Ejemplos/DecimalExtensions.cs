namespace chsarp_intro._7_Extension_Methods
{
    public static class DecimalExtensions
    {
        public static string MiFormato(this decimal value) => $"{value:N2}";
    }
}
