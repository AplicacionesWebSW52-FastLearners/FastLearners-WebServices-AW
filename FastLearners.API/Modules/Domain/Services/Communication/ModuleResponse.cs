using FastLearners.API.Modules.Domain.Models.Modules;

namespace FastLearners.API.Modules.Domain.Services.Communication;

public class ModuleResponse : BaseResponse
{
    public Module Module { get; private set; }

    private ModuleResponse(bool success, string message, Module module) : base(success, message)
    {
        Module = module;
    }

    public ModuleResponse(Module module) : this(true, string.Empty, module)
    { }

    public ModuleResponse(string message) : this(false, message, null)
    { }
}
