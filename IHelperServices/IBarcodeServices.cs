namespace IHelperServices
{
    public interface IBarcodeServices : _IHelperService
    {
        byte[] GetBarcode(string input, int? width = 100, int? height = 100, string format = "CODE_128");
    }
}