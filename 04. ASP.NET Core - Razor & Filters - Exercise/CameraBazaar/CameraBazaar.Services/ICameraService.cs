namespace CameraBazaar.Services
{
    using Data.Models;
    using System.Collections.Generic;

    public interface ICameraService
    {
        void Create(
            CameraMake make, 
            string model,
            decimal price,
            int quantity,
            int minShutterSpeed,
            int maxShutterSpeed,
            MinISO minISO,
            int maxISO,
            bool isFullFrame,
            string videoResolution,
            IEnumerable<LightMetering> lightMeterings,
            string description, 
            string imageUrl,
            string userId);
    }
}