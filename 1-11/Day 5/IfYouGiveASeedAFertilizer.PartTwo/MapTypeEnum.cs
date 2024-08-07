using System.ComponentModel;

namespace IfYouGiveASeedAFertilizer.PartTwo
{
    internal enum MapType
    {
        [Description("seed-to-soil")]
        SeedToSoil,
        [Description("soil-to-fertilizer")]
        SoilToFertilizer,
        [Description("fertilizer-to-water")]
        FertilizerToWater,
        [Description("water-to-light")]
        WaterToLight,
        [Description("light-to-temperature")]
        LightToTemperature,
        [Description("temperature-to-humidity")]
        TemperatureToHumidity,
        [Description("humidity-to-location")]
        HumidityToLocation
    }

    internal static class MapTypeEnum
    {
        internal static MapType ParseToMapType(this string mapType)
        {
            return mapType switch
            {
                "seed-to-soil" => MapType.SeedToSoil,
                "soil-to-fertilizer" => MapType.SoilToFertilizer,
                "fertilizer-to-water" => MapType.FertilizerToWater,
                "water-to-light" => MapType.WaterToLight,
                "light-to-temperature" => MapType.LightToTemperature,
                "temperature-to-humidity" => MapType.TemperatureToHumidity,
                "humidity-to-location" => MapType.HumidityToLocation,
                _ => throw new System.Exception("Invalid map type")
            };
        }

        internal static bool IsMapType(this string mapType)
        {
            return mapType switch
            {
                "seed-to-soil" => true,
                "soil-to-fertilizer" => true,
                "fertilizer-to-water" => true,
                "water-to-light" => true,
                "light-to-temperature" => true,
                "temperature-to-humidity" => true,
                "humidity-to-location" => true,
                _ => false
            };
        }
    }
}
