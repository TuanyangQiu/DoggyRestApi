using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Stateless;
using Stateless.Graph;

namespace DoggyRestApi.Models
{
    public class Order
    {
        public Order()
        {
            _stateMachine = new StateMachine<OrderStatusEnum, OrderStatusTriggerEnum>(
                () => OrderStatus,
                s => OrderStatus = s);

            _stateMachine.Configure(OrderStatusEnum.Pending).
                          Permit(OrderStatusTriggerEnum.PlaceOrder, OrderStatusEnum.Processing).
                          Permit(OrderStatusTriggerEnum.Cancel, OrderStatusEnum.CustomerCancelled);

            _stateMachine.Configure(OrderStatusEnum.Processing).
                          Permit(OrderStatusTriggerEnum.Approve, OrderStatusEnum.PaymentApproved).
                          Permit(OrderStatusTriggerEnum.Reject, OrderStatusEnum.PaymentDeclined);

            _stateMachine.Configure(OrderStatusEnum.PaymentApproved).
                          Permit(OrderStatusTriggerEnum.Refund, OrderStatusEnum.Refund);

            _stateMachine.Configure(OrderStatusEnum.PaymentDeclined).
                          Permit(OrderStatusTriggerEnum.PlaceOrder, OrderStatusEnum.Processing);

        }

        [Key]
        public Guid Id { get; set; }

        [ForeignKey("OwnerId")]
        public string OwnerId { get; set; } = string.Empty;

        public ProjectIdentityUser Owner { get; set; }


        [Required]
        public List<OrderedItem> OrderItems { get; set; }

        [Required]
        public OrderStatusEnum OrderStatus { get; set; }

        [Required]
        public DateTime OrderCreationDateTime { get; set; }

        [Required]
        public string TransactionMetaData { get; set; } = string.Empty;

        private StateMachine<OrderStatusEnum, OrderStatusTriggerEnum> _stateMachine { get; set; }

        public void StartProcessPayment() =>
            _stateMachine.Fire(OrderStatusTriggerEnum.PlaceOrder);

        public void ProcessApprovedPayment() =>
            _stateMachine.Fire(OrderStatusTriggerEnum.Approve);


        public void ProcessRejectedPayment() =>
            _stateMachine.Fire(OrderStatusTriggerEnum.Reject);


    }

    public enum OrderStatusEnum
    {
        /// <summary>
        /// The order has been generated, and waiting for customer to pay
        /// </summary>
        Pending,

        /// <summary>
        /// customer has paied, and is waiting for banks to process 
        /// </summary>
        Processing,

        /// <summary>
        /// the bank approved the payment 
        /// </summary>
        PaymentApproved,

        /// <summary>
        /// the bank declined the payment
        /// </summary>
        PaymentDeclined,

        /// <summary>
        /// the customer cancelled the order
        /// </summary>
        CustomerCancelled,

        /// <summary>
        /// the payment amount has been refunded to the customer
        /// </summary>
        Refund
    }


    public enum OrderStatusTriggerEnum
    {
        /// <summary>
        /// the customer places an order
        /// </summary>
        PlaceOrder,

        /// <summary>
        /// the bank approves the payment
        /// </summary>
        Approve,

        /// <summary>
        /// the bank rejects the payment
        /// </summary>
        Reject,

        /// <summary>
        /// the customer cancels the order
        /// </summary>
        Cancel,

        /// <summary>
        /// the customer asks for a refund
        /// </summary>
        Refund
    }
}
