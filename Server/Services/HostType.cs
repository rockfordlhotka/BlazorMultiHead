using Ui.Services;

namespace Server.Services
{
  public class HostType : IHostType
  {
    string IHostType.HostType => "ASP.NET";
  }
}
