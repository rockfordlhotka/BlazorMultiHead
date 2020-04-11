using Ui.Services;

namespace Client.Services
{
  public class HostType : IHostType
  {
    string IHostType.HostType => "WebAssembly";
  }
}
