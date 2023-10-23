using CriminalsCloudApp.Models;

namespace CriminalsCloudApp.Interfaces
{
    public interface ICriminalInterface
    {
        List<Criminal> GetAllCriminals();
        List<Criminal> SelectByAttributes(string name, string sex, string hair, string eyes, string height, string build, string fingerPrint, string glasses);

    }
}
