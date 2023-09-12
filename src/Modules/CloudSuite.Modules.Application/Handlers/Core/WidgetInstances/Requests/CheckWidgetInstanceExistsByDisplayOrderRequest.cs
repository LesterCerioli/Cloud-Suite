using CloudSuite.Modules.Application.Handlers.Core.WidgetInstances.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.WidgetInstances.Requests
{
  public class CheckWidgetInstanceExistsByDisplayOrderRequest : IRequest<CheckWidgetInstanceExistsByDisplayOrderResponse>
  {
    public Guid Id { get; private set; }

    public int? DisplayOrder { get; set; }

    public CheckWidgetInstanceExistsByDisplayOrderRequest(int? displayOrder)
    {
      Id = Guid.NewGuid();
      DisplayOrder = displayOrder;
    }
  }
}