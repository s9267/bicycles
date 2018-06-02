using System;
namespace bicycles.Services
{
    public interface ISaveImageServices
    {
        void Save(string filename, byte[] image);
    }
}
