using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Serivices.Notifications
{
    public class ErrorNotification : INotification
    {
        public string Error { get; set; }
        public string Stack { get; set; }
    }
}
