using System.Text.Json;

namespace Exadel.Compreface.Helpers
{

    public class SnakeCaseToCamelCaseNamingPolicy : JsonNamingPolicy
    {
        public static SnakeCaseToCamelCaseNamingPolicy Policy { get; } = new SnakeCaseToCamelCaseNamingPolicy();

        public override string ConvertName(string name)
        {
            return name.ToSnakeCase();
        }
    }
}