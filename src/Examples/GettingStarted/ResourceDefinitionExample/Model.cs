using JsonApiDotNetCore.Models;

namespace GettingStarted.ResourceDefinitionExample
{
    public class Model : Identifiable
    {
        [Attr]
        public string DoNotExpose { get; set; }
    }
}
