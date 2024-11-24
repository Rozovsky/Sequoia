using Newtonsoft.Json;

namespace Sequoia.Interfaces;

[JsonObject(MemberSerialization.OptIn)]
public interface IKernelException
{
    [JsonProperty]
    public int Code { get; }

    [JsonProperty]
    public string Type { get; }

    [JsonProperty]
    public string Description { get; }

    [JsonProperty]
    public dynamic Details { get; set; }
}