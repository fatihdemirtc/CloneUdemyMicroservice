using MassTransit;
using UdemyNewMicroservice.Basket.Api.Features.Baskets;

namespace UdemyNewMicroservice.Basket.API.Consumers
{
    public class OrderCreatedEventConsumer(IServiceProvider serviceProvider) : IConsumer<OrderCreatedEvent>
    {
        public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
        {
            using var scope = serviceProvider.CreateScope();
            var basketService = scope.ServiceProvider.GetRequiredService<BasketService>();
            await basketService.DeleteBasket(context.Message.UserId);
        }
    }
}
