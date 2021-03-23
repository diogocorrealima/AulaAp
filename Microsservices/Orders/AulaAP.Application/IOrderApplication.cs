using AulaAP.Application.ViewModels;
using System.Threading.Tasks;

namespace AulaAP.Application
{
    public interface IOrderApplication
    {
        Task CreateOrder(OrderCreateViewModel orderCreateViewModel);
    }
}